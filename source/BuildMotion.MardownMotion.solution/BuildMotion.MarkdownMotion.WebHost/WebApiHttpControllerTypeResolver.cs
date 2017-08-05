using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http.Dispatcher;
using BuildMotion.Services.Common;
using BuildMotion.Services.Diagnostics;

namespace BuildMotion.MarkdownMotion.WebHost
{
    public class WebApiHttpControllerTypeResolver : DefaultAssembliesResolver
    {
        public override ICollection<Assembly> GetAssemblies()
        {
            var assemblies = new List<Assembly>();
            try
            {
                var controllerAssembly = ConfigurationManager.AppSettings["webApiController"];
                if (controllerAssembly.IsValidString())
                {
                    var baseAssemblies = base.GetAssemblies();
                    if (baseAssemblies.Any())
                    {
                        assemblies.AddRange(baseAssemblies);
                        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", controllerAssembly);
                        if (File.Exists(path))
                        {
                            var controllersAssembly = Assembly.LoadFrom(path);
                            if (controllersAssembly.IsNotNull())
                                baseAssemblies.Add(controllersAssembly);
                        }
                        else
                        {
                            throw new ApplicationException("Failed to find web API controller assembly.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Tracing.Trace("nSpire.Decision.Web", TraceEventType.Error, ex.FormatException());
                throw new ApplicationException("Failed to load the external web api controller assembly.", ex);
            }
            return assemblies;
        }
    }
}