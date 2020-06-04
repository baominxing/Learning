using FileCenter.Filters;
using FileCenter.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;

namespace FileCenter.Controller
{
    [TimingActionFilter]
    [WebApiExceptionFilter]
    public class BaseApiController : ApiController
    {
        protected FileCenterDbContext dbContext = new FileCenterDbContext();

        protected string GetFilePath(SystemFiles file)
        {
            var filePath = string.Empty;

            if (file.FileCompressStatus == Model.EnumFileCompressStatus.Compressed)
            {
                // 如果文件已经被归档，需要先将文件解压到初始根目录

                DepressFile(new List<int>() { file.Id });
            }

            // 在初始上传根目录上寻找文件
            filePath = Path.Combine(AppConfig.FileUploadRootDirectory, file.FilePath);

            if (File.Exists(filePath))
            {
                return filePath;
            }

            // 在图片压缩目录中寻找文件
            filePath = Path.Combine(AppConfig.FileCompressRootDirectory, file.FilePath);

            if (File.Exists(filePath))
            {
                return filePath;
            }

            throw new Exception($"{file.FileLongName}在服务器上找不到");
        }

        private void DepressFile(List<int> ids)
        {
            using (var _dbContext = new FileCenterDbContext())
            {
                var list = _dbContext.SystemFiles.Where(s => ids.Contains(s.Id)).ToList();

                foreach (var item in list)
                {
                    var fullPath = $"{AppConfig.FileUploadRootDirectory.Replace("\\", "/")}/{item.FilePath}";

                    if (!File.Exists(fullPath))
                    {
                        ZipFileManager.DepressFile(Path.Combine(AppConfig.FileArchiveRootDirectory, item.ArchiveFileName), item.FileLongName, fullPath);

                        item.FileCompressStatus = EnumFileCompressStatus.Uncompressed;
                        item.ArchiveFileName = string.Empty;
                        item.DecompressDateTime = DateTime.Now;
                        item.TobeArchiveDateTime = DateTime.Now.AddDays((int)EnumArchivePeriod.Quarter);
                    }
                }

                _dbContext.SaveChanges();
            }
        }
    }
}
