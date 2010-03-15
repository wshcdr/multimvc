﻿using System.Web.Routing;
using BA.MultiMVC.Framework.Ressources;

namespace BA.MultiMVC.Framework.Core.MultiMVC.Sample
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            ApplicationHelpers.ConfigureRoutes(
                routes, 
                "Default",
                "Home",
                "BA.MultiTenantMVC.Sample.Controllers",
                "en",
                true
                );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            Bootstrapper.ConfigureStructureMap(Bootstrapper.ExtensionPath);
            ApplicationHelpers.ApplicationStart();
        }
    }
}