using FileCenter.App_Start;
using FileCenter.Common;
using FileCenter.Filters;
using System;
using System.Net;
using System.Web.Http;

namespace FileCenter
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            LogHelper.Info("Application_Start");

            #region 注册WebApi路由
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Filters.Add(new TimingActionFilter());
            GlobalConfiguration.Configuration.Filters.Add(new WebApiExceptionFilter());
            #endregion

            #region 配置定时任务
            if (AppConfig.EnableJob)
            {
                JobManager.GetInstance().Enable();
            }

            #endregion
        }

        protected void Application_End(object sender, EventArgs e)
        {
            LogHelper.Info("Application_End");
        }

        private void Reboot()
        {
            try
            {
                LogHelper.Info("Application_Rebooting...");

                var request = (HttpWebRequest)WebRequest.Create(AppConfig.FileCenterDomain);
                var response = (HttpWebResponse)request.GetResponse();


                LogHelper.Info($"Application_Rebooted:{response.StatusDescription}");
            }
            catch (Exception ex)
            {
                LogHelper.Info($"Application_Rebooting_Error:{ex.Message}");
            }
        }
    }
}