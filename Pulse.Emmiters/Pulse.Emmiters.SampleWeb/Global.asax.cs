using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Pulse.Domain;

namespace Pulse.Emmiters.SampleWeb
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            PulseManager.Init("keyyy21312312312", new FileSystemQueue(@"c:\temp\sample_observations\"));
            PulseManager.RegisterDefaults(DefaultObservation.WindowsCore, DefaultObservation.Mvc);
            
            RegisterRoutes(RouteTable.Routes);
        }
    }
}