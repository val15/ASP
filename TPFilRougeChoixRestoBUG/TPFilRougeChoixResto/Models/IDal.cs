using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFilRougeChoixResto.Models
{
    public interface IDal : IDisposable
    {
        #region Resto
        void CreerRestaurant(string nom, string telephone);
        void ModifierRestaurant(int id, string nom, string telephone,string email);
        List<Resto> ObtientTousLesRestaurants();
        bool RestaurantExiste(string nomResto);

        #endregion

        #region Utilisateur
        Utilisateur ObtenirUtilisateur(int id);
       // Utilisateur ObtenirUtilisateur(string prenom);
        Utilisateur ObtenirUtilisateur(string idStr);//bidoulle pour le TP2
        Utilisateur CreeOuRecupere(string nom, string motDePasse);//bidoulle pour le TP2

        int AjouterUtilisateur(string prenom, string motDePasse);

        Utilisateur Authentifier(string prenom, string motDePasse);

        #endregion

        #region Sondage

        bool ADejaVote(int idSondage, int id);
        int CreerUnSondage();
        bool SondageExist();
        int ObtenirIdDernierSondage();
        List<Resultats> ObtenirLesResultats(int idSondage);


        #endregion

        #region Vote

        int AjouterVote(int idSondage, int idResto, int idUtilisateur);

        #endregion

    }
}