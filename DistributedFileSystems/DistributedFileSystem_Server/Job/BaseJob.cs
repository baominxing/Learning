using FileCenter.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FileCenter.Job
{
    public abstract class BaseJob
    {
        protected string GetFilePath(SystemFiles file)
        {
            var filePath = string.Empty;

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
    }

    public class JobIsIgnoredAttribute : Attribute
    {

    }
}