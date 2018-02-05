using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPFilRougeChoixResto.Models
{
    public class Sondage
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        /* "virtual "permet d’activer le chargement paresseux de la 
         * propriété par Entity Framework afin de permettre 
         * le chargement de ces objets à partir de leurs 
         * identifiants
         */
        public virtual List<Vote> Votes { get; set; }

     
    }
}