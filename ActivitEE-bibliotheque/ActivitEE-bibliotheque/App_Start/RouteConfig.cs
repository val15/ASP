using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ActivitEE_bibliotheque
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Rechercher",
                url: "{controller}/{action}/{filtre}",
                defaults: new { controller = "Rechercher", action = "Livre", filtre = "" }
            );
            //Auteur
            routes.MapRoute(
                name: "Auteur",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Afficher", action = "Auteur", id = 1}
            );
            routes.MapRoute(
                name: "Livre",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Afficher", action = "Livre", id = 1 }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Afficher", action = "ListeLivres", id = UrlParameter.Optional }
            );

            
        }
    }
}
