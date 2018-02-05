using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPFilRougeChoixResto.Models;
using TPFilRougeChoixResto.ViewModels;

namespace TPFilRougeChoixResto.Controllers
{
    public class VoteController : Controller
    {
        // GET: Vote
        private readonly IDal dal;

        public VoteController() : this(new Dal())
        {
        }

        public VoteController(IDal dalIoc)
        {
            dal = dalIoc;
        }

        public ActionResult Index(int id)
        {
            var utilisateur = dal.ObtenirUtilisateur(Request.Browser.Browser);
            if (utilisateur == null)
                return new HttpUnauthorizedResult();
            ViewData["id"] = utilisateur.Id;
            //test si il y a deja un sondage
            int idDerinerSondage = 0;
            idDerinerSondage = dal.SondageExist() ? dal.ObtenirIdDernierSondage() : dal.CreerUnSondage();
          


            if (dal.ADejaVote(idDerinerSondage, id))
                return RedirectToAction("AfficheResultat");


            RestaurantVoteViewModel restaurantVoteViewModel =new RestaurantVoteViewModel();
            List<Resto> lstRestos = dal.ObtientTousLesRestaurants();
            foreach (var resto in lstRestos)
            {
                restaurantVoteViewModel.ListeDesResto.Add(new RestaurantCheckBoxViewModel { Id=resto.Id, EstSelectionne = false, NomEtTelephone = resto.Nom +" ("+ resto.Telephone +") " });//NomEtTelephone = resto.Nom +" ("+resto.Telephone+")"});
            }

            return View(restaurantVoteViewModel);
        }

        [HttpPost]
        public ActionResult Index(RestaurantVoteViewModel restaurantVoteViewModel, int id)
        {

            if (!ModelState.IsValid)
                return View(restaurantVoteViewModel);
            var idSondage = dal.ObtenirIdDernierSondage();
            if (restaurantVoteViewModel != null)
            {
                foreach (var voteReso in restaurantVoteViewModel.ListeDesResto)
                {
                    if (voteReso.EstSelectionne)
                        dal.AjouterVote(idSondage, voteReso.Id,id);
                }
            }
            return RedirectToAction("AfficheResultat");
        }

        public ActionResult AfficheResultat()
        {
            //il faut afficher les resulta lier au sondage
            var listeResultat = dal.ObtenirLesResultats(1);
            return View(listeResultat);
        }
    }
}