﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TPFilRougeChoixResto.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        [Required, MaxLength(80)]//pour dire que Prenom est obligatoir et une taille max de 80
        public string Prenom { get; set; }
        [Required]
        public string MotDePasse { get; set; }

       
    }
}