using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookstoreMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "BookDetails",
                url: "book-{id}.html",
                defaults: new { controller = "Shop", action = "Details" },
                constraints: new { id = @"[\d]+" }
                );

            routes.MapRoute(
                name: "StaticPages",
                url: "site/{viewname}.html",
                defaults: new { controller = "Home", action = "StaticContent" }
                );

            routes.MapRoute(
                name: "BookList",
                url: "type/{booktype}",
                defaults: new { controller = "Shop", action = "List" },
                constraints: new { booktype = @"[\w& ]+" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
