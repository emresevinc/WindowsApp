using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("HaberListesi","haberler/liste",new { controller="News", action="GetList" });
            routes.MapRoute("HaberDetay", "haberler/{haberId}", new { controller = "News", action = "GetDetails" });
        }
    }
}
