using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivitEE_bibliotheque.Models
{
    public interface IDal : IDisposable
    {
        #region Auteur

        void CreerAuteur(string nom);
        Auteur ObtenirAuteur(string nom);
        Auteur ObtenirAuteur(int id);
        List<Auteur> ObtenirListesAuteur();


        


        #endregion

        #region Livre
        void CreerLivre(string titre,DateTime dateDeParution,Auteur auteur);
        // void AjouterUnLibre(string titre,Auteur auteur,DateTime dateDeParution );
        List<Livre> ObtenirListeLivre();
        List<Livre> ObtenirListeLivreDeLAuteur(int id);
        Livre ObtenirLivre(string titre);
        Livre ObtenirLivre(int id);
        List<Livre> RechercherLivre(string filtre);
        Client ObtenirEmprunteurDuLivre(int id);





        #endregion

        #region Client

        void CreerClient(string nom,string email);
        Client ObtenirClient(string email);
       List<Client> ObtenirListeClient();
        void AttribuerUnLivreAUnClient(Client emprunteur, Livre liveAEmpruntE);
        
        #endregion

    }
}