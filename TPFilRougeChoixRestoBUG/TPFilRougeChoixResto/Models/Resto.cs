using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TPFilRougeChoixResto.Models
{
    [Table("Restos")]//DataAnnotations: pour remomer la table au pluriel dans la base
    public class Resto : IValidatableObject

    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom du restaurant doit être saisi")]//pour dire que Nom est obligatoir et afficher une message d'érreur
        public string Nom { get; set; }
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage="Le numéro de téléphone est incorrect")]
        public string Telephone { get; set; }

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage="L'adresse mail est incorrecte")]
        public string Email { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)//pour personaliser un erreur
        {
            if (string.IsNullOrWhiteSpace(Telephone) && string.IsNullOrWhiteSpace(Email))
                yield return new ValidationResult("Vous devez saisir au moins un moyen de contacter le restaurant", new[] { "Telephone", "Email" });
            // etc.
        }

    }
}