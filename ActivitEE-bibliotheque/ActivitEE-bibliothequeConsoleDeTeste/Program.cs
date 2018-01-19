using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivitEE_bibliotheque.Models;

namespace ActivitEE_bibliothequeConsoleDeTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("console de teset");

            IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new BddContext());

            




            IDal _dal = new Dal();

            _dal.CreerAuteur("AuteurAnnonime0");
            _dal.CreerAuteur("AuteurAnnonime1");
            _dal.CreerAuteur("AuteurAnnonime2");

            _dal.CreerLivre("LivreTest0", DateTime.Now, _dal.ObtenirAuteur("AuteurAnnonime0"));
            _dal.CreerLivre("LivreTest1", DateTime.Now, _dal.ObtenirAuteur("AuteurAnnonime1"));
            _dal.CreerLivre("LivreTest2", DateTime.Now, _dal.ObtenirAuteur("AuteurAnnonime2"));
            _dal.CreerLivre("LivreTest3", DateTime.Now, _dal.ObtenirAuteur("AuteurAnnonime1"));
            _dal.CreerLivre("LivreTest4", DateTime.Now, _dal.ObtenirAuteur("AuteurAnnonime0"));



            



            _dal.CreerClient("ClientTest0", "Test0@test.test");
            _dal.CreerClient("ClientTest1", "Test1@test.test");
           

            _dal.AttribuerUnLivreAUnClient(_dal.ObtenirClient("Test0@test.test"),_dal.ObtenirLivre(1));
            _dal.AttribuerUnLivreAUnClient(_dal.ObtenirClient("Test1@test.test"), _dal.ObtenirLivre(2));
            _dal.AttribuerUnLivreAUnClient(_dal.ObtenirClient("Test1@test.test"), _dal.ObtenirLivre(3));

           
            


            Console.ReadLine();
        }
    }
}
