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
            AccueilViewModel vm = new AccueilViewModel
            {
                Message = "Bonjour depuis le contrôleur",
                Date = DateTime.Now,
                Login = "val15",
                Resto = new Resto
                {
                    Nom = "La bonne fourchette", Telephone = "0336230447",
                    
                },
                
                ListeDesRestos = new List<Resto>
                {
                    new Resto { Id = 1, Nom = "Resto pinambour", Telephone = "0330257032" },
                    new Resto { Id = 2, Nom = "Resto tologie", Telephone = "0330257030" },
                    new Resto { Id = 5, Nom = "Resto ride", Telephone = "0330257034" },
                    new Resto { Id = 9, Nom = "Resto toro", Telephone = "0330257037" },
                },
            };//par VM

            //pour une liste dérolante : 
            List<Models.Resto> listeDesRestos = new List<Resto>
            {
                new Resto { Id = 1, Nom = "Resto pinambour", Telephone = "0330257032" },
                new Resto { Id = 2, Nom = "Resto tologie", Telephone = "0330257030" },
                new Resto { Id = 5, Nom = "Resto ride", Telephone = "0330257034" },
                new Resto { Id = 9, Nom = "Resto toro", Telephone = "0330257037" },
            };

            ViewBag.ListeDesRestos = new SelectList(listeDesRestos, "Id", "Nom",5);//selection par défaut
            return View(vm);
        
        }
        [ChildActionOnly] // indique que cette vue n'appelable qu'à partir de sa vue mére
        public ActionResult AfficheListeRestaurant()
        {
            List<Models.Resto> listeDesRestos = new List<Resto>
            {
                new Resto { Id = 1, Nom = "Resto pinambour", Telephone = "0330257032" },
                new Resto { Id = 2, Nom = "Resto tologie", Telephone = "0330257030" },
                new Resto { Id = 5, Nom = "Resto ride", Telephone = "0330257034" },
                new Resto { Id = 9, Nom = "Resto toro", Telephone = "0330257037" },
            };
            return PartialView(listeDesRestos);
        }

        public ActionResult AfficheDate(string id)//juste pour illister le teste
        {
            ViewBag.Message = "Bonjour " + id + " !";
            ViewData["Date"] = new DateTime(2012, 4, 28);
            return View("Index");
        }
    }


}