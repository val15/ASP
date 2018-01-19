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
                Resto = new Resto {Nom = "La bonne fourchette", Telephone = "1234"},

                ListeDesRestos = new List<Resto>
                {
                    new Resto {Nom = "Resto pinambour", Telephone = "1234"},
                    new Resto {Nom = "Resto tologie", Telephone = "1234"},
                    new Resto {Nom = "Resto ride", Telephone = "5678"},
                    new Resto {Nom = "Resto toro", Telephone = "555"},
                },
            };//par VM

            //pour une liste dérolante : 
            List<Models.Resto> listeDesRestos = new List<Resto>
            {
                new Resto { Id = 1, Nom = "Resto pinambour", Telephone = "1234" },
                new Resto { Id = 2, Nom = "Resto tologie", Telephone = "1234" },
                new Resto { Id = 5, Nom = "Resto ride", Telephone = "5678" },
                new Resto { Id = 9, Nom = "Resto toro", Telephone = "555" },
            };

            ViewBag.ListeDesRestos = new SelectList(listeDesRestos, "Id", "Nom",5);
            return View(vm);
            }


            //return View();

    }
}