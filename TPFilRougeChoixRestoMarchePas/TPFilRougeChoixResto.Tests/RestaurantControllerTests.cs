using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFilRougeChoixResto.Controllers;
using TPFilRougeChoixResto.Models;

namespace TPFilRougeChoixResto.Tests
{
    [TestClass]
    public class RestaurantControllerTests
    {
        [TestMethod]
        public void RestaurantController_Index_LeControleurEstOk()
        {
            using (IDal dal = new DalEnDur())//grace à l'ingection de dépendance, on instancie notre IDal de test
            {
                RestaurantController controller = new RestaurantController(dal);//avec un parametre sur le constructeur

                ViewResult resultat = (ViewResult)controller.Index();

                List<Resto> modele = (List<Resto>)resultat.Model;
                Assert.AreEqual("Resto pinambour", modele[0].Nom);
            }
        }

        [TestMethod]
        public void RestaurantController_ModifierRestaurantAvecRestoInvalide_RenvoiVueParDefaut()
        {
            using (IDal dal = new DalEnDur())
            {
                RestaurantController controller = new RestaurantController(dal);
                //il faut simuler une erreur car au debut "ModelState.IsValid  vaudra toujours true" car le binding
                //est fait avant d’instancier l’action du contrôleur
                controller.ModelState.AddModelError("Nom", "Le nom du restaurant doit être saisi");

                ViewResult resultat = (ViewResult)controller.ModifierRestaurant(new Resto { Id = 1, Nom = null, Telephone = "0102030405" });

                Assert.AreEqual(string.Empty, resultat.ViewName);
                Assert.IsFalse(resultat.ViewData.ModelState.IsValid);
            }
        }

        [TestMethod]
        public void RestaurantController_ModifierRestaurantAvecRestoInvalideEtBindingDeModele_RenvoiVueParDefaut()
        {
            RestaurantController controller = new RestaurantController(new DalEnDur());
            Resto resto = new Resto { Id = 1, Nom = null, Telephone = "0102030405" };
            controller.ValideLeModele(resto);

            ViewResult resultat = (ViewResult)controller.ModifierRestaurant(resto);

            Assert.AreEqual(string.Empty, resultat.ViewName);
            Assert.IsFalse(resultat.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void RestaurantController_ModifierRestaurantAvecRestoValide_CreerRestaurantEtRenvoiVueIndex()
        {
            using (IDal dal = new DalEnDur())
            {
                RestaurantController controller = new RestaurantController(dal);
                Resto resto = new Resto { Id = 1, Nom = "Resto mate", Telephone = "0102030405" };
                controller.ValideLeModele(resto);

                RedirectToRouteResult resultat = (RedirectToRouteResult)controller.ModifierRestaurant(resto);

                Assert.AreEqual("Index", resultat.RouteValues["action"]);
                Resto restoTrouve = dal.ObtientTousLesRestaurants().First();
                Assert.AreEqual("Resto mate", restoTrouve.Nom);
            }
        }
    }
}
