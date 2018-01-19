using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActivitEE_bibliotheque.Models;

namespace ActivitEE_bibliotheque.Controllers
{
    public class RechercherController : Controller
    {
        // GET: Rechercher
        private readonly IDal _dal = new Dal();
        public ActionResult Livre(string filtre)
        {
            ViewData["Livres"] = _dal.RechercherLivre(filtre);
            return View("ListeLivres");
        }
    }
}