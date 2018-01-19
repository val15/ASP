using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TPFilRougeChoixResto.Models
{
    [Table("Restos")]//DataAnnotations: pour remomer la table au pluriel dans la base
    public class Resto
    {
        public int Id { get; set; }
        [Required]//pour dire que Nom est obligatoir

        public string Nom { get; set; }
        public string Telephone { get; set; }
    }
}