﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AppHarborSample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_BeginRequest()
        //{
        //    if (!Context.Request.IsSecureConnection)
        //        Response.Redirect(Context.Request.Url.ToString().Replace("http:", "https:"));
        //}
    }

    public class SSLFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsSecureConnection)
            {
                var url = filterContext.HttpContext.Request.Url.ToString().Replace("http:", "https:");
                filterContext.Result = new RedirectResult(url);
            }
        }
    }
}
