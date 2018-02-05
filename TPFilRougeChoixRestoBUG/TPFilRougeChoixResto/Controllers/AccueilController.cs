using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPFilRougeChoixResto.Models;
using TPFilRougeChoixResto.ViewModels;

namespace TPFilRougeChoixResto.Controllers
{
    public class AccueilController : Controller
    {
        // GET: Accueil
        public ActionResult Index()
        {
            //détermination de l'utilisateur via le navigateur
            //IDal dal=new Dal();
            //ViewData["navigateur"] = Request.Browser.Browser;
            //var utilisateur= dal.ObtenirUtilisateur(Request.Browser.Browser);
            //ViewData["utilisateur"] = utilisateur.Prenom;//
            //ViewData["id"] = utilisateur.Id;
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost()
        {

            IDal dal = new Dal();
           // ViewData["navigateur"] = Request.Browser.Browser;
            var utilisateur = dal.ObtenirUtilisateur(Request.Browser.Browser);
            if (utilisateur == null)
                return new HttpUnauthorizedResult();
            // ViewData["utilisateur"] = utilisateur.Prenom;//
            //ViewData["id"] = utilisateur.Id;
            //int idSondage = dal.CreerUnSondage();
            return RedirectToAction("Index", "Vote", new { id = utilisateur.Id });
        }
    }
}