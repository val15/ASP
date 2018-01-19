using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ActivitEE_bibliotheque.Models
{
    public class Auteur
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
    }
}