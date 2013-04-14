﻿namespace StudioDonder.PrisonersDilemma.Website
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using StudioDonder.PrisonersDilemma.Website.App_Start;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}