using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFilRougeChoixResto.Models;

namespace TPFilRougeChoixRestoConsoleDeTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("console de teset");
            
                IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
                Database.SetInitializer(init);
                init.InitializeDatabase(new BddContext());


           
            
            IDal dal=new Dal();

            dal.AjouterUtilisateur("Nouvel utilisateur", "12345");

            Utilisateur utilisateur = dal.Authentifier("Nouvel utilisateur", "12345");

           
            Console.ReadLine();
        }
    }
}
