using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PresentacionMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Registros", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //"Default", "{controller}/",
            //new { controller = "Registros", action = "Index" }
            //);

            //routes.MapRoute("NuevaRuta", "{controller}/{id}", new { controller = "Registros", action = "Index", id = UrlParameter.Optional });
        }
    }
}
