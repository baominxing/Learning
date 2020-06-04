using FileCenter.Common;
using FileCenter.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FileCenter.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class TimingActionFilter : ActionFilterAttribute
    {
        private const string Key = "__action_duration__";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (SkipLogging(actionContext))
            {
                return;
            }
            var stopWatch = new Stopwatch();
            actionContext.Request.Properties[Key] = stopWatch;
            stopWatch.Start();

            var actionName = actionContext.ActionDescriptor.ActionName;
            var controllerName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var paramString = GetParamString(actionContext.ActionArguments);

            LogHelper.Info($"[Execution of {controllerName} - {actionName} Starting, Parameters Are {paramString.ToString()}]");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (!actionExecutedContext.Request.Properties.ContainsKey(Key))
            {
                return;
            }

            var stopWatch = actionExecutedContext.Request.Properties[Key] as Stopwatch;

            if (stopWatch != null)
            {
                stopWatch.Stop();

                var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
                var controllerName = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;

                LogHelper.Info($"[Execution of {controllerName} - {actionName} Done.Totally Took {stopWatch.Elapsed}] Seconds");
            }

        }

        private string GetParamString(Dictionary<string, object> actionArguments)
        {
            var paramString = new StringBuilder();

            try
            {
                foreach (var item in actionArguments)
                {
                    var propertiesString = new StringBuilder();
                    var value = item.Value.ToString();

                    if (item.Value.GetType().IsClass
                        && item.Value.GetType() != typeof(string))
                    {
                        value = Newtonsoft.Json.JsonConvert.SerializeObject(item.Value);
                    }

                    paramString.Append($"{item.Key}:({value}),");
                }
            }
            catch (Exception ex)
            {
                paramString.Append($"An error occurs when trying get params : {ex.Message}");
            }

            return paramString.ToString();
        }

        private static bool SkipLogging(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<NoLogAttribute>().Any() ||
                    actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<NoLogAttribute>().Any();
        }

    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true)]
    public class NoLogAttribute : Attribute
    {

    }
}