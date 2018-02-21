using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPFilRougeChoixResto.Models;

namespace TPFilRougeChoixResto.ViewModels
{
    public class UtilisateurViewModel
    {
        public Utilisateur Utilisateur { get; set; }
        public bool Authentifie { get; set; }
    }
}