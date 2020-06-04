using System;
using System.Threading;
using System.Windows.Forms;

namespace MDCDataCollectService_Winform
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            CustomLogManager.GetInstance().WriteLogToFile(string.Empty.PadRight(6) + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " : " +"开始运行程序" + "\r\n");
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //处理未捕获的异常
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += Application_ThreadException;
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                //运行主程序
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                CustomLogManager.GetInstance().WriteLogToFile(string.Empty.PadRight(6) + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " : " + e.Message + "\r\n");
            }

        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            CustomLogManager.GetInstance().WriteLogToFile(string.Empty.PadRight(6) + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " : " + e.ExceptionObject + "\r\n");
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            CustomLogManager.GetInstance().WriteLogToFile(string.Empty.PadRight(6) + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " : " + e.Exception + "\r\n");
        }
    }
}
