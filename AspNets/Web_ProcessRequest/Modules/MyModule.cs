using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Web_ProcessRequest.Modules
{
    public class MyModule : IHttpModule
    {
        public static StringBuilder stringBuilder = new StringBuilder();

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            stringBuilder.Clear();

            // 下面是如何处理 LogRequest 事件并为其   
            // 提供自定义日志记录实现的示例  
            context.LogRequest += new EventHandler(OnLogRequest);
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);
            context.AcquireRequestState += new EventHandler(context_AcquireRequestState);
            context.AuthorizeRequest += new EventHandler(context_AuthorizeRequest);
            context.Disposed += new EventHandler(context_Disposed);
            context.Error += new EventHandler(context_Error);
            context.EndRequest += new EventHandler(context_EndRequest);
            context.MapRequestHandler += new EventHandler(context_MapRequestHandler);
            context.PostAcquireRequestState += new EventHandler(context_PostAcquireRequestState);
            context.PostAuthenticateRequest += new EventHandler(context_PostAuthenticateRequest);
            context.PostAuthorizeRequest += new EventHandler(context_PostAuthorizeRequest);
            context.PostLogRequest += new EventHandler(context_PostLogRequest);
            context.PostReleaseRequestState += new EventHandler(context_PostReleaseRequestState);
            context.PostRequestHandlerExecute += new EventHandler(context_PostRequestHandlerExecute);
            context.PostResolveRequestCache += new EventHandler(context_PostResolveRequestCache);
            context.PostUpdateRequestCache += new EventHandler(context_PostUpdateRequestCache);
            context.ReleaseRequestState += new EventHandler(context_ReleaseRequestState);
            context.RequestCompleted += new EventHandler(context_RequestCompleted);
            context.ResolveRequestCache += new EventHandler(context_ResolveRequestCache);
            context.UpdateRequestCache += new EventHandler(context_UpdateRequestCache);
            context.PreRequestHandlerExecute += new EventHandler(context_PreRequestHandlerExecute);
            context.PreSendRequestContent += new EventHandler(context_PreSendRequestContent);
            context.PreSendRequestHeaders += new EventHandler(context_PreSendRequestHeaders);
            context.PostMapRequestHandler += new EventHandler(context_PostMapRequestHandler);


        }

        void context_Error(object sender, EventArgs e)
        {
            WriteLog("Error");
            //HttpContext.Current.Response.Write("Error<br />");  
        }

        void context_UpdateRequestCache(object sender, EventArgs e)
        {
            WriteLog("UpdateRequestCache");
            //HttpContext.Current.Response.Write("UpdateRequestCache<br />");  
        }

        void context_ResolveRequestCache(object sender, EventArgs e)
        {
            WriteLog("ResolveRequestCache");
            // HttpContext.Current.Response.Write("ResolveRequestCache<br />");  
        }

        void context_RequestCompleted(object sender, EventArgs e)
        {
            WriteLog("RequestCompleted");
            // HttpContext.Current.Response.Write("RequestCompleted<br />");  
        }

        void context_ReleaseRequestState(object sender, EventArgs e)
        {
            WriteLog("ReleaseRequestState");
            //HttpContext.Current.Response.Write("ReleaseRequestState<br />");  
        }

        void context_PostUpdateRequestCache(object sender, EventArgs e)
        {
            WriteLog("PostUpdateRequestCache");
            //HttpContext.Current.Response.Write("PostUpdateRequestCache<br />");  
        }

        void context_PostResolveRequestCache(object sender, EventArgs e)
        {
            WriteLog("PostResolveRequestCache");
            //HttpContext.Current.Response.Write("PostResolveRequestCache<br />");  
        }

        void context_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            WriteLog("PostRequestHandlerExecute");
            //HttpContext.Current.Response.Write("PostRequestHandlerExecute<br />");  
        }

        void context_PostReleaseRequestState(object sender, EventArgs e)
        {
            WriteLog("PostReleaseRequestState");
            //HttpContext.Current.Response.Write("PostReleaseRequestState<br />");  
        }

        void context_PostLogRequest(object sender, EventArgs e)
        {
            WriteLog("PostLogRequest");
            //HttpContext.Current.Response.Write("PostLogRequest<br />");  
        }

        void context_PostAuthorizeRequest(object sender, EventArgs e)
        {
            WriteLog("PostAuthorizeRequest");
            //HttpContext.Current.Response.Write("PostAuthorizeRequest<br />");  
        }

        void context_PostAuthenticateRequest(object sender, EventArgs e)
        {
            WriteLog("PostAuthenticateRequest");
            //HttpContext.Current.Response.Write("PostAuthenticateRequest<br />");  
        }

        void context_PostAcquireRequestState(object sender, EventArgs e)
        {
            WriteLog("PostAcquireRequestState");
            //HttpContext.Current.Response.Write("PostAcquireRequestState<br />");  
        }

        void context_MapRequestHandler(object sender, EventArgs e)
        {
            WriteLog("MapRequestHandler");
            //HttpContext.Current.Response.Write("MapRequestHandler<br />");  
        }

        void context_Disposed(object sender, EventArgs e)
        {
            WriteLog("Disposed");
            //HttpContext.Current.Response.Write("Disposed<br />");  
        }

        void context_AuthorizeRequest(object sender, EventArgs e)
        {
            WriteLog("AuthorizeRequest");
            //HttpContext.Current.Response.Write("AuthorizeRequest<br />");  
        }

        void context_AcquireRequestState(object sender, EventArgs e)
        {
            WriteLog("AcquireRequestState");
            //HttpContext.Current.Response.Write("AcquireRequestState<br />");  
        }


        void context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            WriteLog("PreSendRequestHeaders");
            //HttpContext.Current.Response.Write("PreSendRequestHeaders<br />");  
        }

        void context_PreSendRequestContent(object sender, EventArgs e)
        {
            WriteLog("PreSendRequestContent");
            //HttpContext.Current.Response.Write("PreSendRequestContent<br />");  
        }

        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            WriteLog("PreRequestHandlerExecute");
            //HttpContext.Current.Response.Write("PreRequestHandlerExecute<br />");  
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            WriteLog("EndRequest");

            HttpContext.Current.Response.Write(stringBuilder.ToString());


        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            WriteLog("*******************************************************************************");
            HttpApplication app = sender as HttpApplication;
            WriteLog(app.Context.Request.Path);
            WriteLog("BeginRequest");
            //HttpContext.Current.Response.Write("BeginRequest<br />");  
        }

        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            WriteLog("AuthenticateRequest");
            //HttpContext.Current.Response.Write("AuthenticateRequest<br />");  
        }

        public void OnLogRequest(Object source, EventArgs e)
        {
            //可以在此处放置自定义日志记录逻辑  
            WriteLog("OnLogRequest");
            //HttpContext.Current.Response.Write("OnLogRequest<br />");  
        }

        public void context_PostMapRequestHandler(object sender, EventArgs e)
        {
            WriteLog("PostMapRequestHandler");
            //HttpContext.Current.Response.Write("PostMapRequestHandler<br />");  
        }

        public static void WriteLog(string message)
        {
            stringBuilder.Append(message + "</br>");
            stringBuilder.Append("<hr>");
        }
    }
}