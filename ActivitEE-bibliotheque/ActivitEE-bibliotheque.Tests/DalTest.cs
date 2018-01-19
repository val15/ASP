using System;
using System.Collections.Generic;
using System.Data.Entity;
using ActivitEE_bibliotheque.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActivitEE_bibliotheque.Tests
{
    [TestClass]
    public class DalTest
    {
        private IDal _dal;

        [TestInitialize] //cette "décoration" permet de dénir une methode qui sera executée avant chaque teste
        public void Init_AvantChaqueTest()
        {
            //   reinitialisation de la base avant le teste
            IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new BddContext());

            _dal = new Dal();
        }

        [TestMethod]
        public void CreerAuteur_AvecUnNouveauAuteur_ObtientTousLesAuteursRenvoitBienLAuteur()
        {
            _dal.CreerAuteur("AuteurAnnonime");
            var auteurs = _dal.ObtenirListesAuteur();
            Assert.IsNotNull(auteurs);
            Assert.AreEqual(1, auteurs.Count);
            Assert.AreEqual("AuteurAnnonime", auteurs[0].Nom);
        }

        [TestMethod]
        public void
            CreeLivre_CreeUnNouveauAuteurEtLivre_ObtenirUnAuteur_CreuUnNouveauLivre_ObtientLivre_ObtientTousLesLivreRenvoitBienLeLivre()
        {
            _dal.CreerAuteur("AuteurAnnonime");
            _dal.CreerLivre("LivreTest", DateTime.Now, _dal.ObtenirAuteur("AuteurAnnonime"));
            var livre = _dal.ObtenirLivre("LivreTest");
            Assert.IsNotNull(livre);

            var lstLivre = _dal.ObtenirListeLivre();

            Assert.IsNotNull(lstLivre);
            Assert.AreEqual(1, lstLivre.Count);
            Assert.AreEqual("LivreTest", lstLivre[0].Titre);
        }

        [TestMethod]
        public void
            CreeCient_CreeUnNouveauAuteur_ObtenirUnAuteur_CreuUnNouveauLivre_CreerClient_OntenirLivre_AjouerLivreEmpuntEAuClient_RenvoitBienLEmprunteur()
        {
            _dal.CreerAuteur("AuteurAnnonime");
            _dal.CreerLivre("LivreTest", DateTime.Now, _dal.ObtenirAuteur("AuteurAnnonime"));
            var livre = _dal.ObtenirLivre("LivreTest");
            _dal.CreerClient("ClientTest","Test@test.test");
            var client = _dal.ObtenirClient("Test@test.test");
            _dal.AttribuerUnLivreAUnClient(client,livre);
             client = _dal.ObtenirClient("Test@test.test");
            Assert.AreEqual("ClientTest", client.Nom);
            Assert.AreEqual(livre, client.LivreEmpruntE);



        }
    }
}
