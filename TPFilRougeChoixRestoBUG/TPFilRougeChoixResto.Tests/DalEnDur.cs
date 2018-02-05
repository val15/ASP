﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFilRougeChoixResto.Models;

namespace TPFilRougeChoixResto.Tests
{
    //cette classe est comme DAL que nous avons déjà, à ceci près qu’il n’y a pas du tout d’utilisation d’Entity Framework et que tout est stocké dans des listes en mémoire.
    public class DalEnDur : IDal
    {
        private List<Resto> listeDesRestaurants;
        private List<Utilisateur> listeDesUtilisateurs;
        private List<Sondage> listeDessondages;

        public DalEnDur()
        {
            listeDesRestaurants = new List<Resto>
        {
            new Resto { Id = 1, Nom = "Resto pinambour", Telephone = "0102030405"},
            new Resto { Id = 2, Nom = "Resto pinière", Telephone = "0102030405"},
            new Resto { Id = 3, Nom = "Resto toro", Telephone = "0102030405"},
        };
            listeDesUtilisateurs = new List<Utilisateur>();
            listeDessondages = new List<Sondage>();
        }

        public List<Resto> ObtientTousLesRestaurants()
        {
            return listeDesRestaurants;
        }

        public void CreerRestaurant(string nom, string telephone)
        {
            int id = listeDesRestaurants.Count == 0 ? 1 : listeDesRestaurants.Max(r => r.Id) + 1;
            listeDesRestaurants.Add(new Resto { Id = id, Nom = nom, Telephone = telephone });
        }

        public void ModifierRestaurant(int id, string nom, string telephone,string email)
        {
            Resto resto = listeDesRestaurants.FirstOrDefault(r => r.Id == id);
            if (resto != null)
            {
                resto.Nom = nom;
                resto.Telephone = telephone;
                resto.Email = email;
            }
        }

        public bool RestaurantExiste(string nom)
        {
            return listeDesRestaurants.Any(resto => string.Compare(resto.Nom, nom, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        public int AjouterUtilisateur(string nom, string motDePasse)
        {
            int id = listeDesUtilisateurs.Count == 0 ? 1 : listeDesUtilisateurs.Max(u => u.Id) + 1;
            listeDesUtilisateurs.Add(new Utilisateur { Id = id, Prenom = nom, MotDePasse = motDePasse });
            return id;
        }

        public Utilisateur Authentifier(string nom, string motDePasse)
        {
            return listeDesUtilisateurs.FirstOrDefault(u => u.Prenom == nom && u.MotDePasse == motDePasse);
        }

        public Utilisateur ObtenirUtilisateur(int id)
        {
            return listeDesUtilisateurs.FirstOrDefault(u => u.Id == id);
        }

        //public Utilisateur ObtenirUtilisateur(string idStr)
        //{
        //    int id;
        //    if (int.TryParse(idStr, out id))
        //        return ObtenirUtilisateur(id);
        //    return null;
        //}

        public int CreerUnSondage()
        {
            int id = listeDessondages.Count == 0 ? 1 : listeDessondages.Max(s => s.Id) + 1;
            listeDessondages.Add(new Sondage { Id = id, Date = DateTime.Now, Votes = new List<Vote>() });
            return id;
        }

        public bool SondageExist()
        {
            if (listeDessondages.Count == 0)
                return false;
            else
            {
                return true;
            }
        }

        public int ObtenirIdDernierSondage()
        {

            return listeDessondages.Last().Id;
        }

        public int AjouterVote(int idSondage, int idResto, int idUtilisateur)
        {
            Vote vote = new Vote
            {
                Resto = listeDesRestaurants.First(r => r.Id == idResto),
                Utilisateur = listeDesUtilisateurs.First(u => u.Id == idUtilisateur)
            };
            Sondage sondage = listeDessondages.First(s => s.Id == idSondage);
            sondage.Votes.Add(vote);
            return sondage.Votes.ToList().Last().Id;
        }

        public bool ADejaVote(int idSondage, string idStr)
        {
            Utilisateur utilisateur = ObtenirUtilisateur(idStr);
            if (utilisateur == null)
                return false;
            Sondage sondage = listeDessondages.First(s => s.Id == idSondage);
            return sondage.Votes.Any(v => v.Utilisateur.Id == utilisateur.Id);
        }

        public bool ADejaVote(int idSondage, int id)//pour la bidouille du TP2
        {
            Utilisateur utilisateur = ObtenirUtilisateur(id);
            if (utilisateur == null)
                return false;
            Sondage sondage = listeDessondages.First(s => s.Id == idSondage);
            return sondage.Votes.Any(v => v.Utilisateur.Id == utilisateur.Id);

        }

        public List<Resultats> ObtenirLesResultats(int idSondage)
        {
            List<Resto> restaurants = ObtientTousLesRestaurants();
            List<Resultats> resultats = new List<Resultats>();
            Sondage sondage = listeDessondages.First(s => s.Id == idSondage);
            foreach (IGrouping<int, Vote> grouping in sondage.Votes.GroupBy(v => v.Resto.Id))
            {
                int idRestaurant = grouping.Key;
                Resto resto = restaurants.First(r => r.Id == idRestaurant);
                int nombreDeVotes = grouping.Count();
                resultats.Add(new Resultats { Nom = resto.Nom, Telephone = resto.Telephone, NombreDeVotes = nombreDeVotes });
            }
            return resultats;
        }

        public void Dispose()
        {
            listeDesRestaurants = new List<Resto>();
            listeDesUtilisateurs = new List<Utilisateur>();
            listeDessondages = new List<Sondage>();
        }

        #region Pour le TP2

        public Utilisateur ObtenirUtilisateur(string idStr)//bidoulle pour le TP2 affin de differention les utilisateur à partir du navigateur
        {
            switch (idStr)
            {
                case "Chrome":
                    return CreeOuRecupere("Nico", "1234");
                case "IE":
                    return CreeOuRecupere("Jérémie", "1234");
                case "Firefox":
                    return CreeOuRecupere("Delphine", "1234");
                default:
                    return CreeOuRecupere("Timéo", "1234");
            }
        }

        public Utilisateur CreeOuRecupere(string nom, string motDePasse)
        {
            Utilisateur utilisateur = Authentifier(nom, motDePasse);
            if (utilisateur == null)
            {
                int id = AjouterUtilisateur(nom, motDePasse);
                return ObtenirUtilisateur(id);
            }
            return utilisateur;
        }



        #endregion
    }
}