using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ActivitEE_bibliotheque.Models
{
    public class Livre
    {
        public int Id { get; set; }
        [Required]
        public string Titre { get; set; }
        [Required]
        public DateTime DateDeParution { get; set; }
        [Required]
        public virtual Auteur Auteur { get; set; }
        
    }
}