using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FileCenter.Common
{
    public class FileServiceFilterAttribute: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //如果用户方位的Action带有AllowAnonymousAttribute，则不进行授权验证
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                return;
            }
            if (!AppConfig.IsTest) return;//正式不验证


            LogHelper.Info($"FileServiceFilterAttribute At:{DateTime.Now}" + " connectapitoken:" + actionContext.Request.Headers.GetValues("connectapitoken").Count().ToString());
            if (actionContext.Request.Headers.GetValues("connectapitoken").Count() <= 0)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, new HttpError("connectapitoken 不正确"));
                return;
            }
            

            try
            {
                var connectapitoken = actionContext.Request.Headers.GetValues("connectapitoken").FirstOrDefault();
                LogHelper.Info($"FileServiceFilterAttribute At:{DateTime.Now}" + connectapitoken);

                //var verifyResult = MDS.Api.Auth.ClientCredentialsHelper.VerifyToken(connectapitoken, "fileservice");//业务系统accessToken

                //LogHelper.Info($"FileServiceFilterAttribute At:{DateTime.Now}" + verifyResult["fileservice"].ToString());
                //if (!verifyResult["fileservice"])
                //{
                //    //如果验证不通过，则返回401错误，并且Body中写入错误原因
                //    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, new HttpError("受权验证 未通过"));
                //    return;
                //}
            }
            catch(Exception ex)
            {
                LogHelper.Info($"FileServiceFilterAttribute At:{DateTime.Now}" + "受权验证 未通过");
                //如果验证不通过，则返回401错误，并且Body中写入错误原因
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, new HttpError("受权验证 未通过"));
            }
           


        }
    }
}


