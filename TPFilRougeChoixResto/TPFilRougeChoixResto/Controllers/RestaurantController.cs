using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPFilRougeChoixResto.Models;

namespace TPFilRougeChoixResto.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant

        private IDal dal;

        public RestaurantController() : this(new Dal())//injection de dépendace avec un constructeur par defaut
        {
        }

        public RestaurantController(IDal dalIoc)
        {
            dal = dalIoc;
        }
        public ActionResult Index()
        {
            
                List<Resto> listeDesRestaurants = dal.ObtientTousLesRestaurants();
                return View(listeDesRestaurants);
           
            
        }


        #region Encienne méthode
        //public ActionResult ModifierRestaurant(int? id)
        //{

        //    OU
        //    string idStr = Request.QueryString["id"];
        //    int id;
        //    if (int.TryParse(idStr, out id))
        //    {
        //        ViewBag.Id = id;
        //        return View();
        //    }
        //    else
        //        return View("Error");


        //    if (id.HasValue)
        //    {
        //        using (IDal dal = new Dal())
        //        {

        //            if (Request.HttpMethod == "POST")//si la methode est "POST" on medifie dirrectement la base
        //            {
        //                string nouveauNom = Request.Form["Nom"];
        //                string nouveauTelephone = Request.Form["Telephone"];
        //                dal.ModifierRestaurant(id.Value, nouveauNom, nouveauTelephone);
        //            }


        //            Resto restaurant = dal.ObtientTousLesRestaurants().FirstOrDefault(r => r.Id == id.Value);
        //            if (restaurant == null)
        //                return View("Error");
        //            return View(restaurant);//envoi restaurant comme parametre à la view
        //        }
        //    }
        //    else
        //        return View("Error");
        //}
        #endregion
        #region Nouvelle méthode avec validation des données

        public ActionResult ModifierRestaurant(int? id)//pour le "GET" affin d'obtenir les info sur le résto en question
        {
            if (id.HasValue)
            {
                
                    Resto restaurant = dal.ObtientTousLesRestaurants().FirstOrDefault(r => r.Id == id.Value);
                    if (restaurant == null)
                        return View("Error");
                    return View(restaurant);
                
            }
            else
                return HttpNotFound();
        }

        [HttpPost]
        public ActionResult ModifierRestaurant(Resto resto)//avec validation des données
        {
            if (!ModelState.IsValid)
                return View(resto);
            
                dal.ModifierRestaurant(resto.Id, resto.Nom, resto.Telephone,resto.Email);
                return RedirectToAction("Index");
           
        }


        public ActionResult CreerRestaurant()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreerRestaurant(Resto resto)
        {
            
                if (dal.RestaurantExiste(resto.Nom))
                {
                    ModelState.AddModelError("Nom", "Ce nom de restaurant existe déjà");//ajout l'erreur
                    return View(resto);
                }
                if (!ModelState.IsValid)//verifie si le model est bien valide
                    return View(resto);
                dal.CreerRestaurant(resto.Nom, resto.Telephone);
                return RedirectToAction("Index");
            
        }

        #endregion




    }
}