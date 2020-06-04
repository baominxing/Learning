using System;
using System.Configuration;

namespace FileCenter
{
    public class AppConfig
    {
        /// <summary>
        /// FileCenter系统数据库连接
        /// </summary>
        public static readonly string FileDbConnectionString = ConfigurationManager.ConnectionStrings["FileCenterEntities"].ConnectionString;

        /// <summary>
        /// 文件上传根目录
        /// </summary>
        public static readonly string FileUploadRootDirectory = ConfigurationManager.AppSettings["FileUploadRootDirectory"];

        /// <summary>
        /// 文件压缩根目录
        /// </summary>
        public static readonly string FileCompressRootDirectory = ConfigurationManager.AppSettings["FileCompressRootDirectory"];

        /// <summary>
        /// 文件归档根目录
        /// </summary>
        public static readonly string FileArchiveRootDirectory = ConfigurationManager.AppSettings["FileArchiveRootDirectory"];

        /// <summary>
        /// 图片类型
        /// </summary>
        public static readonly string ImageExtension = ConfigurationManager.AppSettings["ImageExtension"].ToString();

        /// <summary>
        /// 需要进行图片处理的项目
        /// </summary>
        public static readonly string[] ImageCompressProjectList = ConfigurationManager.AppSettings["ImageCompressProjectList"].ToString().Split(',');

        /// <summary>
        /// 私钥存放路径
        /// </summary>
        public static readonly string PrivateKeyFilePath = ConfigurationManager.AppSettings["PrivateKeyFilePath"].ToString();

        /// <summary>
        /// 公钥存放路径
        /// </summary>
        public static readonly string PublicKeyFilePath = ConfigurationManager.AppSettings["PublicKeyFilePath"].ToString();

        /// <summary>
        /// 缓存过期时间
        /// </summary>
        public static readonly int AbsoluteExpiration = 60;

        public static readonly string FileCenterDomain = ConfigurationManager.AppSettings["FileCenterDomain"];

        public static readonly bool AllowDownloadOnce = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowDownloadOnce"]);

        /// <summary>
        /// 打包下载存放文件目录
        /// </summary>
        public static readonly string ZipFolder = ConfigurationManager.AppSettings["ZipFolder"].ToString();

        /// <summary>
        /// 零时存储上传大文件切分后的小文件路径
        /// </summary>
        public static readonly string BigFileTempStorage = ConfigurationManager.AppSettings["BigFileTempStorage"];

        /// <summary>
        /// 是否是测试
        /// </summary>
        public static readonly bool IsTest = Convert.ToBoolean(ConfigurationManager.AppSettings["IsTest"]);

        #region 定时任务运行表达式 字段格式固定为ScheduleExpressionOf{Job类名}
        /// <summary>
        /// 定时任务运行表达式
        /// </summary>
        public static readonly string ScheduleExpressionOfCompressJob = ConfigurationManager.AppSettings["ScheduleExpressionOfCompressJob"];

        /// <summary>
        /// 定时任务运行表达式
        /// </summary>
        public static readonly string ScheduleExpressionOfFileArchiveJob = ConfigurationManager.AppSettings["ScheduleExpressionOfFileArchiveJob"];

        /// <summary>
        /// 是否启用Job
        /// </summary>
        public static readonly bool EnableJob = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableJob"]);
        #endregion


        public class ReturnResult
        {
            public static readonly string Status_Success = "1";
            public static readonly string Status_Failure = "0";
            public static readonly string Message_Success = "SUCCESS";
        }
    }
}
