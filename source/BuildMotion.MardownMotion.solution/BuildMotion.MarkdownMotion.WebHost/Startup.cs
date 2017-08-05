using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using BuildMotion.MarkdownMotion.WebHost;
using BuildMotion.Services.Common;
using BuildMotion.Web.Security.OAuth;
//using BuildMotion.Web.Security.OAuth;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace BuildMotion.MarkdownMotion.WebHost
{
    //REMEMBER TO SET THIS --> [assembly: OwinStartup(typeof (Startup))]
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            #region OWIN Middleware

            //appBuilder.Use<AuthorizationOwinMiddleware>();

            #endregion

            #region OAuth Configuration

            var allowInsecureHttp = true;
            if (ConfigurationManager.AppSettings["AllowInsecureHttp"].IsNotNull())
            {
                allowInsecureHttp = Convert.ToBoolean(ConfigurationManager.AppSettings["AllowInsecureHttp"].ToLower());
            }
            else
            {
                throw new Exception("The AllowInsecureHttp web.config appSetting is missing or invalid. Configure using a boolean value.");
            }

            //Add package: Microsoft.Owin.Security.OAuth
            appBuilder.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = allowInsecureHttp,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(8),
                Provider = new OAuthProvider()
            });

            appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                AuthenticationType = "Bearer",
                AuthenticationMode = AuthenticationMode.Active
            });

            #endregion

            #region Configuration

            var config = new HttpConfiguration();

            // The magic happen here to load external/reference assemblies with Web API Controller(s);
            config.Services.Replace(typeof(IAssembliesResolver), new WebApiHttpControllerTypeResolver());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
                );

            config.EnsureInitialized();

            #endregion

            #region JSON Formatting

            // Note: http://james.newtonking.com/json/help/index.html?topic=html/SerializationSettings.htm
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());

            #endregion

            appBuilder.UseWebApi(config);
        }
    }
}