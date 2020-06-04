using Net4Logger;
using System;
using System.IO;

namespace MDCDataCollectService_Winform
{
    public class CustomLogManager : ILogManager
    {
        public delegate void LogChanged(string message);

        public event LogChanged LogChangedEvent;

        private static CustomLogManager _instance;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static CustomLogManager GetInstance()
        {
            return _instance ?? (_instance = new CustomLogManager());
        }

        private CustomLogManager()
        {
        }

        public void Debug(string message)
        {
            Log.Debug(message);
            LogChangedEvent?.Invoke(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
            LogChangedEvent?.Invoke(message);
        }

        public void Info(string message)
        {
            Log.Info(message);
            LogChangedEvent?.Invoke(message);
        }

        public void Warn(string message)
        {
            Log.Warn(message);
            LogChangedEvent?.Invoke(message);
        }

        public void WriteLogToFile(string log)
        {
            var folder = "Logs\\" + DateTime.Now.ToString("yyyy-MM-dd");
            if (!Directory.Exists(folder))
            {
                //创建根目录
                Directory.CreateDirectory(folder);
            }
            else
            {
                File.AppendAllText(folder + "\\" + DateTime.Now.ToString("yyyy-MM-dd HH") + ".txt", log);
            }
        }
    }
}
