﻿using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFilRougeChoixResto.Controllers;

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

        [TestMethod]
        public void AccueilController_AfficheDate_RenvoiVueIndexEtViewData()
        {
            AccueilController controller = new AccueilController();

            ViewResult resultat = (ViewResult)controller.AfficheDate("Nicolas");

            Assert.AreEqual("Index", resultat.ViewName);
            Assert.AreEqual(new DateTime(2012, 4, 28), resultat.ViewData["date"]);
            Assert.AreEqual("Bonjour Nicolas !", resultat.ViewBag.Message);
        }
    }
}
