using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Routes.Controllers
{
    public class CalculateurController : Controller
    {
        // GET: Calculateur
        public string Ajouter(int valeur1, int valeur2)
        {
            var resultat = valeur1 + valeur2;
            return resultat.ToString();
        }

        public string Soustraire(int valeur1, int valeur2)
        {
            return (valeur1 - valeur2).ToString();
        }
    }
}