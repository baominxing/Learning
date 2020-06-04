﻿using System;
using System.Web;
using System.Web.UI;
using Web_ProcessRequest.Modules;

namespace Web_ProcessRequest.Handlers
{
    public class MyHandler : IHttpHandler
    {
        /// <summary>  
        /// 您将需要在网站的 Web.config 文件中配置此处理程序   
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，  
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007  
        /// </summary>  
        #region IHttpHandler Members  
        public bool IsReusable
        {
            // 如果无法为其他请求重用托管处理程序，则返回 false。  
            // 如果按请求保留某些状态信息，则通常这将为 false。  
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            MyModule.WriteLog("Handler:" + DateTime.Now.ToString("yyyy-MM-dd"));

            //context.Response.Write("    Handler:" + DateTime.Now.ToString("yyyy-MM-dd"));
        }
        #endregion
    }
}