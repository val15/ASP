using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ActivitEE_bibliotheque.Models
{
    public class Client
    {
        [Required]
        public string Nom {get; set;}
        [Key]
        public string Email { get; set; }
        
        public virtual Livre LivreEmpruntE { get; set; }

    }
}