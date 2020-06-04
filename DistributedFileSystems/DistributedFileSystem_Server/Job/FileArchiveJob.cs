using Dapper;
using FileCenter.Common;
using FileCenter.Job;
using FileCenter.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCenter
{
    /// <summary>
    /// 归档任务，目的在于将处理图片压缩后的文件打包放入.zip文件里
    /// </summary>
    [JobIsIgnored]//如果需要启用该任务，去掉attribute
    public class FileArchiveJob : BaseJob, IJob
    {
        async Task IJob.Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                var st = DateTime.Now;

                LogHelper.Info("Archive File Starting.");

                var runningResult = EnumOperateResult.Failure;
                var archiveFileList = new List<string>();//产生的归档压缩文件
                var allFileInfoList = new List<FileInfo>();//此次归档所有的文件对象集合
                var systemFileList = this.GetUnArchivedFiles();

                using (var conn = new SqlConnection(AppConfig.FileDbConnectionString))
                {
                    conn.Open();

                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        //获取到的每个项目文件进行压缩
                        var projectNameList = systemFileList.Select(s => s.ProjectName).Distinct();

                        foreach (var projectName in projectNameList)
                        {
                            LogHelper.Info($"Archive File Start In Project - {projectName}.");

                            var projectFileList = systemFileList.Where(s => s.ProjectName == projectName).ToList();

                            var directoryPath = Path.Combine(AppConfig.FileArchiveRootDirectory, projectName, DateTime.Now.ToString("yyyyMM"));

                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            var archiveFileName = $"{Guid.NewGuid()}.zip";
                            var archiveFileNameFullPath = Path.Combine(directoryPath, archiveFileName);

                            if (!File.Exists(Path.Combine(archiveFileNameFullPath)))
                            {
                                using (File.Create(archiveFileNameFullPath)) { }
                            }

                            // 转换成FileInfo对象集合，方便操作
                            var fileInfoList = this.GetFileInfoList(projectFileList);

                            if (!fileInfoList.Any())
                            {
                                LogHelper.Info($"File Has Been Deleted Or Archived.");
                                continue;
                            }

                            // 压缩所选文件
                            ZipFileManager.CompressFileList(fileInfoList, archiveFileNameFullPath);

                            allFileInfoList.AddRange(fileInfoList);

                            archiveFileList.Add(archiveFileNameFullPath);

                            var relativeArchiveFileName = Path.Combine(projectName, DateTime.Now.ToString("yyyyMM"), $"{archiveFileName}");

                            // 在数据库中把正在归档 - 1 的记录设置成归档完成 - 2
                            this.SetFileToCompressed(fileInfoList, relativeArchiveFileName, conn, transaction);

                            LogHelper.Info($"Archive File Done In Project - {projectName}.");
                        }

                        LogHelper.Info($"Archive File All Done. Time Usage : {(DateTime.Now - st).TotalSeconds} Seconds.");

                        transaction.Commit();

                        runningResult = EnumOperateResult.Success;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        // 删除已经归档的压缩文件
                        foreach (var zipFile in archiveFileList)
                        {
                            if (File.Exists(zipFile))
                            {
                                File.Delete(zipFile);
                            }
                        }

                        LogHelper.Error($"Archive File Occurs Error : {ex.ToString()}.");
                    }
                }

                if (runningResult == EnumOperateResult.Success)
                {
                    // 删除已压缩的文件
                    //this.DeleteCompressedFileList(allFileInfoList);
                }
            });
        }

        private void DeleteCompressedFileList(List<FileInfo> fileInfoList)
        {
            foreach (var item in fileInfoList)
            {
                if (item.Exists)
                {
                    item.Delete();
                }
            }
        }

        private void SetFileToCompressed(List<FileInfo> fileInfoList, string destinationArchiveFileName, SqlConnection conn, SqlTransaction transaction)
        {
            var startDate = this.GetArchiveStartDate().Date;
            var endDate = startDate.AddDays(1).Date;
            var systemFilesList = new List<SystemFiles>();
            var executeSql = $@"
UPDATE SystemFiles
SET FileCompressStatus = @Compressed,
    ArchiveFileName = @ArchiveFileName,
    ArchiveDateTime = GETDATE()
WHERE IsDelete IS NULL AND CreateDate BETWEEN '{startDate.ToString("yyyy-MM-dd")}' AND '{endDate.ToString("yyyy-MM-dd")}';
";
            var parameters = new { EnumFileCompressStatus.Compressed, ArchiveFileName = destinationArchiveFileName };

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }

            conn.Execute(executeSql, parameters, transaction);
        }

        private List<SystemFiles> GetUnArchivedFiles()
        {
            var startDate = this.GetArchiveStartDate().Date;
            var endDate = startDate.AddDays(1).Date;
            var systemFilesList = new List<SystemFiles>();
            var executeSql = $@"
            SELECT [FileName],
                   [FileLongName],
                   [FileSize],
                   [FileExtension],
                   [FilePath],
                   [ProjectName],
                   [CreateDate]
            FROM SystemFiles
            WHERE IsDelete IS NULL AND CreateDate BETWEEN '{startDate.ToString("yyyy-MM-dd")}' AND '{endDate.ToString("yyyy-MM-dd")}';
            ";

            using (var conn = new SqlConnection(AppConfig.FileDbConnectionString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                systemFilesList = conn.Query<SystemFiles>(executeSql).ToList();
            }

            return systemFilesList;
        }

        private List<FileInfo> GetFileInfoList(List<SystemFiles> systemFileList)
        {
            var fileInfoList = new List<FileInfo>();

            foreach (var item in systemFileList)
            {
                if (fileInfoList.Any(s => s.FullName.Contains(item.FileLongName)))
                {
                    continue;
                }

                var filePath = this.GetFilePath(item);

                if (!File.Exists(filePath))
                {
                    LogHelper.Info($"{item.FilePath} Not Found.");
                    continue;
                }

                // 过滤那些可能被手动操作移除的文件，但是数据库里还有记录和已经在列表里的数据
                if (!fileInfoList.Any(s => s.FullName == filePath))
                {
                    var fInfo = new FileInfo(filePath);

                    if (fInfo.Length > 0)
                    {
                        fileInfoList.Add(fInfo);
                    }
                    else
                    {
                        LogHelper.Info($"{item.FilePath} is an empty file and is ignored.");
                    }
                }
            }

            return fileInfoList;
        }

        private DateTime GetArchiveStartDate()
        {
            return DateTime.Now.AddMonths(-1 * Convert.ToInt32(ConfigurationManager.AppSettings["MonthToBeCompressed"]));
        }
    }
}
