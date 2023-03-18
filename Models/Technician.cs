using System.ComponentModel.DataAnnotations;

namespace GBCSporting_Team_Amigos.Models
{
    public class Technician
    {
        [Key]
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Technician Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Technician E-mail is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Technician Phone is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage = "correct phone number format is ###-###-####")]
        public string Phone { get; set; }
    }
}
