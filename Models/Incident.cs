using System.ComponentModel.DataAnnotations;

namespace GBCSporting_Team_Amigos.Models
{
    public class Incident
    {
        [Key]
        public int IncidentId { get; set; }

        [Required(ErrorMessage = "Customer is required for incident report")]
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }

        public Customer? Customer { get; set; }

        [Required(ErrorMessage = "Product is required for incident report")]
        [Display(Name = "Product")]
        public int? ProductId { get; set; }

        public Product? Product { get; set; }

        [Required(ErrorMessage = "Title is required for incident report")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required for incident report")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Technician")]
        public int? TechnicianId { get; set; }
        public Technician? Technician { get; set; }

        private DateTime? openDate;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OpenDate { get { if (!openDate.HasValue) openDate = DateTime.Now; return openDate.Value; } set { openDate = value; } }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CloseDate { get; set; }
    }
}
