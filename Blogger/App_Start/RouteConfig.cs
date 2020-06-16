using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blogger
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //country
            routes.MapRoute("Country", "{type}/{meta}",
               new { controller = "Country", action = "Index", meta = UrlParameter.Optional },
               new RouteValueDictionary
               {
                    { "type","dia-diem"}
               },
               namespaces: new[] { "Blogger.Controllers" });
            //asia
                routes.MapRoute("Detail", "{type}/{meta}/{id}",
                new { controller = "Country", action = "Detail", id = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    { "type","dia-diem"}
                },
                namespaces: new[] { "Blogger.Controllers" });
            //countryEU
                 routes.MapRoute("countryEU", "{type}/{meta}",
                 new { controller = "countryEU", action = "Index", meta = UrlParameter.Optional },
                 new RouteValueDictionary
                {
                    { "type","dia-diemeu"}
                },
                namespaces: new[] { "Blogger.Controllers" });
            //EUR
                routes.MapRoute("DetailEU", "{type}/{meta}/{id}",
                new { controller = "CountryEU", action = "Detail", id = UrlParameter.Optional },
                new RouteValueDictionary
                {
                    { "type","dia-diemeu"}
                },
                namespaces: new[] { "Blogger.Controllers" });

                routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"Blogger.Controllers"}
            );
        }
    }
}
