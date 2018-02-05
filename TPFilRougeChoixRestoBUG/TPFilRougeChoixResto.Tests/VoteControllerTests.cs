using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TPFilRougeChoixResto.Controllers;
using TPFilRougeChoixResto.Models;
using TPFilRougeChoixResto.ViewModels;

namespace TPFilRougeChoixResto.Tests
{
    [TestClass]
    public class VoteControllerTests
    {
        private IDal dal;
        private int idSondage;
        private VoteController controleur;


        [TestInitialize]
        public void Init()
        {
            dal = new DalEnDur();
            idSondage = dal.CreerUnSondage();
            Mock<ControllerContext> controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(p => p.HttpContext.Request.Browser.Browser).Returns("1");

            controleur = new VoteController(dal);
            controleur.ControllerContext = controllerContext.Object;
        }

        [TestCleanup]
        public void Clean()
        {
            dal.Dispose();
        }


        [TestMethod]
        public void Index_AvecSondageNormalMaisSansUtilisateur_RenvoiLeBonViewModelEtAfficheLaVue()
        {
            ViewResult view = (ViewResult)controleur.Index(idSondage);

            RestaurantVoteViewModel viewModel = (RestaurantVoteViewModel)view.Model;
            Assert.AreEqual(3, viewModel.ListeDesResto.Count);
            Assert.AreEqual(1, viewModel.ListeDesResto[0].Id);
            Assert.IsFalse(viewModel.ListeDesResto[0].EstSelectionne);
          //  Assert.AreEqual("Resto pinambour (0102030405)", viewModel.ListeDesResto[0].NomEtTelephone);
        }

        [TestMethod]
        public void Index_AvecSondageNormalAvecUtilisateurNayantPasVote_RenvoiLeBonViewModelEtAfficheLaVue()
        {
            dal.AjouterUtilisateur("Nico", "1234");
            dal.AjouterUtilisateur("Jérémie", "1234");

            ViewResult view = (ViewResult)controleur.Index(idSondage);

            RestaurantVoteViewModel viewModel = (RestaurantVoteViewModel)view.Model;
            Assert.AreEqual(3, viewModel.ListeDesResto.Count);
            Assert.AreEqual(1, viewModel.ListeDesResto[0].Id);
            Assert.IsFalse(viewModel.ListeDesResto[0].EstSelectionne);
            Assert.AreEqual("Resto pinambour (0102030405)", viewModel.ListeDesResto[0].NomEtTelephone);
        }
    }
}
