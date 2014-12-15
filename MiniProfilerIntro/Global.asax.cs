﻿using MiniProfilerIntro.Models;
using StackExchange.Profiling;
using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace MiniProfilerIntro
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=301868
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            MiniProfiler.Settings.Results_Authorize = IsUserAllowedToSeeMiniProfilerUI;
            MiniProfiler.Settings.Results_List_Authorize = IsUserAllowedToSeeMiniProfilerUI;
        }

        private bool IsUserAllowedToSeeMiniProfilerUI(HttpRequest httpRequest) {
            // Implement your own logic for who 
            // should be able to access ~/mini-profiler-resources/results-index
            var principal = httpRequest.RequestContext.HttpContext.User;
            return principal.IsInRole("Admin");
        }

        protected void Application_BeginRequest() {
            if (Request.IsLocal) {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest() {
            MiniProfiler.Stop();
        }

        //protected void Application_AuthenticateRequest(Object sender, EventArgs e) {
        //    if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated) {
        //        if (!HttpContext.Current.User.IsInRole("Admin")) {
        //            StackExchange.Profiling.MiniProfiler.Stop(discardResults: true);
        //        }
        //    } else {
        //        StackExchange.Profiling.MiniProfiler.Stop(discardResults: true);
        //    }   
        //}
    }
}