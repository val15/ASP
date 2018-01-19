using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActivitEE_bibliotheque.Models;

namespace ActivitEE_bibliotheque.Controllers
{
    public class AfficherController : Controller
    {
        // GET: Afficher
        //public ActionResult Index()
        //{
        //    return View();
        //}
        private readonly IDal _dal = new Dal();

        public string Index()
        {
            return "Afficher";
        }

        public ActionResult ListeLivres()
        {

            ViewData["Livres"] = _dal.ObtenirListeLivre(); //on lie la liste
            return View();
        }

        //Afficher/Auteurs
        public ActionResult Auteurs()
        {
            
            ViewData["Auteurs"] = _dal.ObtenirListesAuteur();
            return View();
          

        }

        //Afficher/Auteur/2
        public ActionResult Auteur(int id)
        {
            if (id >= _dal.ObtenirListesAuteur().Count || id <= 0)
                return View("Error");
            else
            {
                ViewData["Nom auteur"] = _dal.ObtenirAuteur(id).Nom;
                ViewData["Livres"] = _dal.ObtenirListeLivreDeLAuteur(id); //on lie la liste
                return View();
            }
           
        }

        //Afficher/Livre/3
        public ActionResult Livre(int id)
        {
            if (id >= _dal.ObtenirListeLivre().Count || id <= 0 )
                return View("Error");
            else
            {
                var livre = _dal.ObtenirLivre(id);
                ViewData["Titre"] = livre.Titre;
                ViewData["Date de parrution"] = livre.DateDeParution;
                var emprunteur = _dal.ObtenirEmprunteurDuLivre(id);
                if (emprunteur == null)
                    ViewData["Emprunteur"] = "pas emprunté";
                else
                {
                    ViewData["Emprunteur"] = emprunteur.Nom;
                }
                return View();
            }

            

        }
    }
}