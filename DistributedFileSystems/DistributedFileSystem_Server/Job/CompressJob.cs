using FileCenter.Common;
using FileCenter.Job;
using FileCenter.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileCenter
{
    /// <summary>
    /// 图片压缩任务，目的在于处理N个月前上的图片附件，压缩原图片，释放空间
    /// </summary>
    public class CompressJob : BaseJob, IJob
    {
        async Task IJob.Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                var st = DateTime.Now;

                LogHelper.Info("Compress Image Starting.");

                try
                {
                    // 获取压缩的日期集合
                    var operateList = this.GetOperateList();

                    // 统计项目数量
                    var projectNameList = AppConfig.ImageCompressProjectList;

                    this.Compress(projectNameList, operateList);

                }
                catch (Exception ex)
                {
                    LogHelper.Error($"Throw Exception:{ex.ToString()}");
                }

                LogHelper.Info($"Compress Image Done.");
            });
        }

        private void Compress(IEnumerable<string> projectNameList, List<Operate> operateList)
        {
            var fileUploadRootDirectory = AppConfig.FileUploadRootDirectory;
            var fileCompressRootDirectory = AppConfig.FileCompressRootDirectory;

            foreach (var day in operateList)
            {
                foreach (var projectName in projectNameList)
                {

                    LogHelper.Info($"Starting Process Project - {projectName}/{day.StartDate.ToString("yyyyMMdd")}");

                    var processedFileList = new List<string>();
                    var sourceDirectory = Path.Combine(fileUploadRootDirectory, projectName, day.StartDate.ToString("yyyyMMdd"));
                    var targetDirectory = Path.Combine(fileCompressRootDirectory, projectName, day.StartDate.ToString("yyyyMMdd"));

                    if (!Directory.Exists(sourceDirectory))
                    {
                        LogHelper.Info($"{sourceDirectory} Not Exists");

                        continue;
                    }

                    // 目标目录不存在，创建
                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    var filePathList = Directory.GetFiles(sourceDirectory);
                    var originalFileCount = filePathList.Count();
                    var processedImageFileCount = 0;
                    var processedOtherFileCount = 0;

                    ParallelOptions options = new ParallelOptions
                    {
                        MaxDegreeOfParallelism = Environment.ProcessorCount
                    };

                    // 针对每个文件，如果是图片进行压缩处理，节省空间
                    ParallelLoopResult result = Parallel.ForEach(filePathList, options, (filePath, state, i) =>
                    {
                        var fileInfo = new FileInfo(filePath);
                        var targetFilePath = Path.Combine(targetDirectory, fileInfo.Name);

                        if (!fileInfo.Exists)
                        {
                            LogHelper.Info($"File Is Not Found:{fileInfo.FullName}");
                        }
                        else
                        {
                            // 如果不是图片，直接拷贝到目标文件
                            if (!AppConfig.ImageExtension.Contains(fileInfo.Extension.ToLower()))
                            {
                                //直接拷贝文件到目标文件夹
                                File.Copy(fileInfo.FullName, targetFilePath, true);
                                LogHelper.Info($"Copied Other File:{fileInfo.FullName}");

                                processedOtherFileCount++;
                            }
                            else
                            {
                                // 如果是图片，但是图片<100KB《直接拷贝到目标文件夹
                                if (fileInfo.Length < 1024 * 100)
                                {
                                    //直接拷贝文件到目标文件夹
                                    File.Copy(fileInfo.FullName, targetFilePath, true);
                                    LogHelper.Info($"Copied Other File:{fileInfo.FullName}");
                                }
                                else
                                {
                                    byte[] fileByteData = null;

                                    using (var fs = fileInfo.OpenRead())
                                    {
                                        fileByteData = new byte[fs.Length];

                                        fs.Read(fileByteData, 0, fileByteData.Length);
                                    }

                                    var imageSize = 500;

                                    if (fileByteData.Length > 1024 * 1000) // 如果是1MB以上的图片则，设置压缩大小为自身大小1/4以下就可以了，避免过度压缩导致失真
                                    {
                                        imageSize = fileByteData.Length / 1024 / 4;
                                    }

                                    var compressManager = new CompressManager();

                                    fileByteData = compressManager.CompressImage(fileByteData, size: imageSize);

                                    if (fileByteData == null) //返回null，说明压缩失败，直接拷贝该文件
                                    {
                                        //直接拷贝文件到目标文件夹
                                        File.Copy(fileInfo.FullName, targetFilePath, true);
                                    }
                                    else
                                    {
                                        if (File.Exists(targetFilePath))
                                        {
                                            File.Delete(targetFilePath);
                                        }

                                        using (FileStream fs = File.Create(targetFilePath))
                                        {
                                            fs.Write(fileByteData, 0, fileByteData.Length);
                                        }
                                    }

                                    fileByteData = null;
                                }

                                processedImageFileCount++;
                            }

                            processedFileList.Add(filePath);
                        }

                    });

                    LogHelper.Info($"Complete Compress Task In {projectName}, Origin File Count : {originalFileCount}");
                    LogHelper.Info($"Complete Compress Task In {projectName}, Image File Count : {processedImageFileCount}");
                    LogHelper.Info($"Complete Compress Task In {projectName}, Other File Count : {processedOtherFileCount}");
                    LogHelper.Info($"Complete Compress Task In {projectName}, Total File Count : {processedImageFileCount + processedOtherFileCount}");

                    //删除改文件夹下的原图片
                    if (originalFileCount == (processedImageFileCount + processedOtherFileCount))
                    {
                        // 删除文件
                        this.Delete(processedFileList);
                    }
                }

                // 记录完成的日期,存在的更新操作成功，新增的记录操作成功
                this.RecordOperatedDayToSuccess(day);
            }
        }

        /// <summary>
        /// 新增失败的月份为操作失败
        /// </summary>
        /// <param name="monthOperationList"></param>
        private void RecordOperatedDayToFailure(Operate operate)
        {
            using (var context = new FileCenterDbContext())
            {
                var entity = context.Operates.FirstOrDefault(s => s.Id == operate.Id);


                if (entity != null)
                {
                    entity.OperateResult = EnumOperateResult.Failure;
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// 记录完成的月份,存在的更新操作成功，新增的记录操作成功
        /// </summary>
        /// <param name="monthOperationList"></param>
        private void RecordOperatedDayToSuccess(Operate operate)
        {
            using (var context = new FileCenterDbContext())
            {
                var entity = context.Operates.FirstOrDefault(s => s.Id == operate.Id);

                if (entity != null)
                {
                    entity.OperateResult = EnumOperateResult.Success;
                }

                context.SaveChanges();
            }
        }

        private void Delete(List<string> filePathList)
        {
            foreach (var filePath in filePathList)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
        }

        /// <summary>
        /// 复制完整的目录
        /// </summary>
        /// <param name="rootSourceDirectory"></param>
        /// <param name="rootTargetDirectory"></param>
        private void CopyDirectories(string rootSourceDirectory, string rootTargetDirectory)
        {
            var rootDirectory = new DirectoryInfo(rootSourceDirectory);

            foreach (var directory in rootDirectory.GetDirectories())
            {
                var targetDirectory = Path.Combine(rootTargetDirectory, directory.Name);

                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }
            }
        }

        private List<Operate> GetOperateList()
        {
            // 预先将当前计划中的月份新增到数据库
            var dayOperationList = new List<Operate>();

            var startDate = GetCompressStartDate().Date;

            var endDate = startDate.AddDays(1).Date;

            using (var context = new FileCenterDbContext())
            {
                context.Operates.Add(new Operate
                {
                    CreationTime = DateTime.Now,
                    OperateResult = EnumOperateResult.Failure,
                    OperateType = EnumOperateType.ImageCompress,
                    StartDate = startDate,
                    EndDate = endDate
                });

                context.SaveChanges();
            }

            using (FileCenterDbContext fileCenterDbContext = new FileCenterDbContext())
            {
                dayOperationList = fileCenterDbContext.Operates.AsNoTracking().Where(s => s.OperateType == EnumOperateType.ImageCompress && s.OperateResult == EnumOperateResult.Failure).ToList();
            }

            return dayOperationList;
        }

        private DateTime GetCompressStartDate()
        {
            //return DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(-1 * Convert.ToInt32(ConfigurationManager.AppSettings["MonthToBeCompressed"]));
            return DateTime.Now.AddMonths(-1 * Convert.ToInt32(ConfigurationManager.AppSettings["MonthToBeCompressed"]));
        }
    }
}
