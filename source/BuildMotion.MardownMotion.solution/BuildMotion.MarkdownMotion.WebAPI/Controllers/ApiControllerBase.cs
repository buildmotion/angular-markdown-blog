using System.Diagnostics;
using System.Web;
using System.Web.Http;
using BuildMotion.Services.Diagnostics;

namespace BuildMotion.HybridMobileApp.Web.Controllers
{
    public class ApiControllerBase : ApiController
    {
        public ApiControllerBase()
        {
            Tracing.Trace("HybridMobileApp", TraceEventType.Information, "Starting new Web API request.");
            Tracing.Trace("HybridMobileApp", TraceEventType.Information, "Initializing new BHMAService for the Web API request.");
            //BHMAService = BHMAServiceBootstrapper.Initialize();
            //BHMAService.ServiceContext.Principal = HttpContext.Current.User;
            Tracing.Trace("HybridMobileApp", TraceEventType.Information, "Completed initialization of new BuildMotion.BHMAService for the Web API request.");
        }

        //public IBHMAService BHMAService { get; }
    }
}