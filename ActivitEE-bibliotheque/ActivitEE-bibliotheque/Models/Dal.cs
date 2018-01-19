using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ActivitEE_bibliotheque.Models
{
    public class Dal : IDal
    {
        private readonly BddContext _bdd;

        public Dal()
        {
            _bdd = new BddContext();
        }

        #region Auteur
        public void CreerAuteur(string nom)
        {
            _bdd.Auteurs.Add(new Auteur { Nom = nom });
            _bdd.SaveChanges();
        }

        public List<Auteur> ObtenirListesAuteur()
        {
            return _bdd.Auteurs.ToList();
        }

        public Auteur ObtenirAuteur(string nom)
        {
            return _bdd.Auteurs.FirstOrDefault(autr => autr.Nom == nom);

        }

        public Auteur ObtenirAuteur(int id)
        {
            return _bdd.Auteurs.FirstOrDefault(autr => autr.Id == id);
        }
        #endregion
        #region Livre

        public void CreerLivre(string titre, DateTime dateDeParution, Auteur auteur)
        {
            _bdd.Livres.Add(new Livre {Auteur = auteur, Titre = titre, DateDeParution = dateDeParution});
            _bdd.SaveChanges();
        }
        // void AjouterUnLibre(string titre,Auteur auteur,DateTime dateDeParution );
        public List<Livre> ObtenirListeLivre()
        {
            return _bdd.Livres.ToList();
        }

        public List<Livre> RechercherLivre(string filtre)
        {
            return _bdd.Livres.Where(lvr => lvr.Titre.Contains(filtre) || lvr.Auteur.Nom.Contains(filtre) || filtre == "").ToList() ;
        }

        public List<Livre> ObtenirListeLivreDeLAuteur(int id)
        {
            return _bdd.Livres.Where(lvr => lvr.Auteur.Id == id).ToList();
        }


        public Livre ObtenirLivre(string titre)
        {
            return _bdd.Livres.FirstOrDefault(lvr => lvr.Titre ==titre);

        }

        public Livre ObtenirLivre(int id)
        {
            return _bdd.Livres.FirstOrDefault(lvr => lvr.Id == id);

        }

        public Client ObtenirEmprunteurDuLivre(int id)
        {
            var emprunteur = _bdd.Clients.FirstOrDefault(cl => cl.LivreEmpruntE.Id == id);
            if (emprunteur == null)
                return null;
            else
            {
                return emprunteur;
            }
        }


        #endregion

        #region Client

        public void CreerClient(string nom, string email)
        {
            _bdd.Clients.Add(new Client {Nom = nom, Email = email});
            _bdd.SaveChanges();
        }

        public Client ObtenirClient(string email)
        {
            return _bdd.Clients.FirstOrDefault(cl => cl.Email == email);
        }

        public List<Client> ObtenirListeClient()
        {
            return _bdd.Clients.ToList();
        }

        public void AttribuerUnLivreAUnClient(Client emprunteur, Livre liveAEmpruntE)
        {
            emprunteur.LivreEmpruntE = liveAEmpruntE;
            _bdd.SaveChanges();
        }

        #endregion




        public void Dispose()
        {
            _bdd.Dispose();
        }
    }
}