﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Routes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Meteo",
                url: "{controller}/{action}/{jour}/{mois}/{annee}",
                defaults: new { controller = "Meteo", action = "Afficher" },
                constraints: new { jour = @"\d+", mois = @"\d+", annee = @"\d{4}" });//ajout de contrainte grace au experssions réguliaires

            routes.MapRoute(
                name: "Calucaleur",
                url: "{controller}/{action}/{valeur1}/{valeur2}",
                defaults: new { controller = "Calculateur", action = "Ajouter"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
