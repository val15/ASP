using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPFilRougeChoixResto.ViewModels
{
    public class RestaurantVoteViewModel : IValidatableObject
    {
        public List<RestaurantCheckBoxViewModel> ListeDesResto { get; set; }

        public RestaurantVoteViewModel()
        {
            ListeDesResto=new List<RestaurantCheckBoxViewModel>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!ListeDesResto.Any(lrst => lrst.EstSelectionne))
                yield return new ValidationResult("Vous devez slectionner au moin un resto", new[] { "ListeDesResto" });
          
        }
    }
}