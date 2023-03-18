using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBCSporting_Team_Amigos.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Code is required")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Yearly Price is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a correct price")]
        [Display(Name = "Yearly Price")]
        public double Price { get; set; }

        private DateTime? releaseDate;
        [Required(ErrorMessage = "Release Date is required")]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate {
            get
            {
                if (!releaseDate.HasValue)
                    releaseDate = DateTime.Now;
                return releaseDate.Value;

            }
            set { releaseDate = value; }
        }
    }
}
