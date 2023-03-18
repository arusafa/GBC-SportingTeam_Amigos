using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting_Team_Amigos.Models
{
    public class Registration
    {
        [Key]
        public int RegistrationId { get; set; }

        [Required(ErrorMessage = "Customer is required")]
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }

        public Customer? Customer { get; set; }

        [Required(ErrorMessage = "Product is required")]
        [Display(Name = "Product")]
        public int? ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
