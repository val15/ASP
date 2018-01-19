using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoTests.Tests
{
    [TestClass]
    public class MathTests
    {

        [TestMethod]
        public void Factorielle_AvecValeur0_Retourne1()
        {
            double resultat = MathHelper.Factorielle(0);
            Assert.AreEqual(1, resultat);
        }

        [TestMethod]
        public void Factorielle_AvecValeur3_Retourne6()
        {
            double resultat = MathHelper.Factorielle(3);
            Assert.AreEqual(6, resultat);
        }

        [TestMethod]
        public void Factorielle_AvecValeur15_Retourne1307674368000()
        {
            double resultat = MathHelper.Factorielle(15);
            Assert.AreEqual(1307674368000, resultat);
        }

        [TestMethod]
        public void ObtenirLaMeteoDuJour_AvecUnBouchon_RetourneSoleil()
        {
            Meteo fausseMeteo = new Meteo
            {
                Temperature = 25,
                Temps = Temps.Soleil
            };
            Mock<IDal> mock = new Mock<IDal>();
            mock.Setup(dal => dal.ObtenirLaMeteoDuJour()).Returns(fausseMeteo);

            IDal fausseDal = mock.Object;
            Meteo meteoDuJour = fausseDal.ObtenirLaMeteoDuJour();
            Assert.AreEqual(25, meteoDuJour.Temperature);
            Assert.AreEqual(Temps.Soleil, meteoDuJour.Temps);

        }

        [TestMethod]
        public void Generateur_AvecUnBouchon_Retourne5()
        {
            Mock<IGenerateur> mock = new Mock<IGenerateur>();
            mock.Setup(generateur => generateur.Valeur).Returns(5);

            Assert.AreEqual(5, mock.Object.Valeur);
        }

    }
}
