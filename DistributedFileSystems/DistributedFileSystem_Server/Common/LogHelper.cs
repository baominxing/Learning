namespace FileCenter.Common
{
    public class LogHelper
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger("FileCenter");//获取一个日志记录器

        public static void Info(string message)
        {
            log.Info(message);
        }

        public static void Error(string message)
        {
            log.Error(message);
        }
    }
}