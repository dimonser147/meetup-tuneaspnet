using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TPD.Presentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            /*
            PRESENTATION: Only use the View Engines that you require
            */
            //ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(new RazorViewEngine());
            /*
            PRESENTATION: Remove asp.net mvc version header
            */
            //MvcHandler.DisableMvcResponseHeader = true;
        }
    }
}
