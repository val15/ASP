using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TPFilRougeChoixResto.Models
{
    public class InitChoixRestoEtUnUtilisateur : DropCreateDatabaseAlways<BddContext>
    {
        protected override void Seed(BddContext context)
        {
            context.Restos.Add(new Resto { Id = 1, Nom = "Resto pinambour", Telephone = "0330556609" });
            context.Restos.Add(new Resto { Id = 2, Nom = "Resto pinière", Telephone = "0330556608" });
            context.Restos.Add(new Resto { Id = 3, Nom = "Resto toro", Telephone = "0330556644" });
           context.Utilisateurs.Add(new Utilisateur {Id=1, Prenom = "val15", MotDePasse= EncodeMD5("0000") });
            //context.SaveChanges();
          
            base.Seed(context);
        }

        private string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }
    }
}