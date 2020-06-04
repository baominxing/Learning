using FileCenter.Filters;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FileCenter.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //启用跨域
            // config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Filters.Add(new TimingActionFilter());
        }
    }
}