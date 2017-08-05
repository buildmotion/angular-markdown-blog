using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using BuildMotion.Services.Diagnostics;

namespace BuildMotion.MarkdownMotion.WebHost
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            Tracing.Trace("nSpireDecision.Web", TraceEventType.Information, "Preparing to create HTTP configuration to resolve web api controller assemblies.");

            // The magic happen here to load external/reference assemblies with Web API Controller(s);
            config.Services.Replace(typeof(IAssembliesResolver), new WebApiHttpControllerTypeResolver());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }
            );
        }
    }
}