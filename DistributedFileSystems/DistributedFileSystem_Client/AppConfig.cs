using System.Configuration;

namespace DistributedFileSystem_Client
{
    public class AppConfig
    {
        public static class FileCenter
        {
            public static string ServiceAddress = ConfigurationManager.AppSettings["FileCenterAddress"];

            public static string UploadFileMethodName = ConfigurationManager.AppSettings["UploadFileMethodName"];

            public static string DownloadFileMethodName = ConfigurationManager.AppSettings["DownloadFileMethodName"];
        }

        public static class FileSplitUpload
        {
            public static int FileBlockSize = 1024 * 1000 * 20;//1000KB
        }
    }
}
