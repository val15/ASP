﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TPFilRougeChoixResto.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();// la création du context entraine la création de la base et de ces table
        }


        #region Resto
        public List<Resto> ObtientTousLesRestaurants()
        {
            return bdd.Restos.ToList();
        }
        public void CreerRestaurant(string nom, string telephone)
        {
            bdd.Restos.Add(new Resto { Nom = nom, Telephone = telephone });
            bdd.SaveChanges();
          
        }

        public void ModifierRestaurant(int id, string nom, string telephone)
        {
            Resto restoTrouve = bdd.Restos.FirstOrDefault(resto => resto.Id == id);
            if (restoTrouve != null)
            {
                restoTrouve.Nom = nom;
                restoTrouve.Telephone = telephone;
                bdd.SaveChanges();
            }
        }

        public bool RestaurantExiste(string nomResto)
        {
            var restoTrouvE = bdd.Restos.FirstOrDefault(resto => resto.Nom == nomResto);
            if (restoTrouvE != null)
                return true;
            else
            {
                return false;
            }
        }
        #endregion

        #region Utilisateur
        public Utilisateur ObtenirUtilisateur(int id)
        {
            return bdd.Utilisateurs.FirstOrDefault(utilisateur => utilisateur.Id == id);
        }

        public Utilisateur ObtenirUtilisateur(string prenom)
        {
            return bdd.Utilisateurs.FirstOrDefault(utilisateur => utilisateur.Prenom == prenom);
        }

        public Utilisateur Authentifier(string prenom, string motDePasse)
        {
            string mdpHacher = EncodeMD5(motDePasse);
          //  Console.WriteLine(mdpHacher);
            return bdd.Utilisateurs.FirstOrDefault(utilisateur => utilisateur.Prenom == prenom && utilisateur.MotDePasse == mdpHacher);

        }
       

        public int AjouterUtilisateur(string prenom, string motDePasse)
        {
            string mdpHacher = EncodeMD5(motDePasse);
          //  Console.WriteLine(mdpHacher);
            bdd.Utilisateurs.Add(new Utilisateur { Prenom = prenom, MotDePasse = mdpHacher });
            bdd.SaveChanges();
            return bdd.Utilisateurs.ToList().Last().Id;
        }

        #endregion

        #region Sondages

        public bool ADejaVote(int id, string idUtilisateur)
        {
            var sondage = bdd.Sondages.FirstOrDefault(s => s.Id == id);
            if (sondage == null)
                return false;
            else
            {
                var votes = bdd.Votes.ToList();//on prend la liste de vote 
                var utilisateurExiste = votes.FirstOrDefault(v => v.Utilisateur.Id.ToString() == idUtilisateur);
                if (utilisateurExiste == null)
                    return false;
                else
                {
                    return true;
                }
            }
        }

        public int CreerUnSondage()
        {
            bdd.Sondages.Add(new Sondage{Date = DateTime.Now});
            bdd.SaveChanges();
            return bdd.Sondages.ToList().Last().Id;
        }

        #endregion

        #region Vote

        public int AjouterVote(int idSondage, int idResto, int idUtilisateur)
        {
            var restoAAjoutE = bdd.Restos.FirstOrDefault(rst => rst.Id == idResto);
            var utilisateurAAjoutE = bdd.Utilisateurs.FirstOrDefault(utl => utl.Id == idUtilisateur);
            var sondageAAjoutE = bdd.Sondages.FirstOrDefault(sdg => sdg.Id == idSondage);
            var nouveauVote = new Vote {Resto = restoAAjoutE, Utilisateur = utilisateurAAjoutE,Sondage = sondageAAjoutE};
            bdd.Votes.Add(nouveauVote);//ajout dans la base
            bdd.SaveChanges();
            
            return bdd.Votes.ToList().Last().Id;

        }


        #endregion

        public List<Resultats> ObtenirLesResultats(int idSondage)
        {
            var sondage = bdd.Sondages.FirstOrDefault(sdg => sdg.Id == idSondage);
            var lstVote = bdd.Votes.Where(vt => vt.Sondage.Id == idSondage).ToList();
            List<Resultats> lstResultatses=new List<Resultats>();
            // int nombreDeVotes = bdd.Votes.Where(vt => vt.Resto == vote.Resto).ToList().Count;
            var lstApresRegroupement = lstVote.GroupBy(vt => vt.Resto).ToList();
           // Console.WriteLine("GRP : "+lstApresRegroupement.GetType());
            
            foreach (var voteGrp in lstApresRegroupement)
           {
               lstResultatses.Add(new Resultats{Nom = voteGrp.First().Resto.Nom,Telephone = voteGrp.First().Resto.Telephone,NombreDeVotes = voteGrp.Count() });
           }
            return lstResultatses;
        }



        private string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "ChoixResto" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}