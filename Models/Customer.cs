using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GBCSporting_Team_Amigos.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "First name required.")]
        [StringLength(50, ErrorMessage = "Must be between 1 and 50 characters long.", MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last name required.")]
        [StringLength(50, ErrorMessage = "Must be between 1 and 50 characters long.", MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(1000, ErrorMessage = "Must be between 1 and 1000 characters long.", MinimumLength = 1)]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "Must be between 1 and 50 characters long.", MinimumLength = 1)]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [StringLength(50, ErrorMessage = "Must be between 1 and 50 characters long.", MinimumLength = 1)]
        public string State { get; set; }

        [Required(ErrorMessage = "Postal Code is required.")]
        [RegularExpression("^[ABCEGHJ-NPRSTVXY]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[ ]?[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[0-9]{1}$",ErrorMessage = "Post code is invalid")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage ="Country is required.")]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "correct phone number format is ###-###-####")]
        public string? Phone { get; set; }

        public string FullName
        {
            get { return $"{Firstname} {Lastname}"; }
        }
    }
}
