using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFilRougeChoixResto.Controllers;
using TPFilRougeChoixResto.Models;

namespace TPFilRougeChoixResto.Tests
{
    [TestClass]
    public class AccueilControllerTests
    {
        [TestMethod]
        public void AccueilController_Index_RenvoiVueParDefaut()
        {
            AccueilController controller = new AccueilController();
            ViewResult resultat = (ViewResult)controller.Index();
            Assert.AreEqual(string.Empty, resultat.ViewName);


        }

        //[TestMethod]
        //public void AccueilController_IndexPost_RenvoiActionVote()
        //{
        //    using (IDal dal = new DalEnDur())
        //    {
        //        AccueilController controller = new AccueilController();

        //        RedirectToRouteResult resultat = (RedirectToRouteResult)controller.IndexPost(1);

        //        Assert.AreEqual("Index", resultat.RouteValues["action"]);
        //        Assert.AreEqual("Vote", resultat.RouteValues["controller"]);
        //        List<Resultats> resultats = dal.ObtenirLesResultats(1);
        //        Assert.IsNotNull(resultats);
        //    }
        //}


    }
}
