using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ZenS_Fontend_Test.Models;
using ZenS_Fontend_Test.Service;

namespace ZenS_Fontend_Test
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            if(DataProvider.Ins.DB.Jokes.Count() < 1)
            {
                JokeService.InitalJoke();
            }
        }
    }
}
