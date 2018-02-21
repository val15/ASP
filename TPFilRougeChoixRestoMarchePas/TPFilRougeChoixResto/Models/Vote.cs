using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFilRougeChoixResto.Models
{
    public class Vote
    {
        public int Id { get; set; }
        /* "virtual "permet d’activer le chargement paresseux de la 
         * propriété par Entity Framework afin de permettre 
         * le chargement de ces objets à partir de leurs 
         * identifiants
         */
        public virtual Resto Resto { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public virtual Sondage Sondage { get; set; }
    }
}