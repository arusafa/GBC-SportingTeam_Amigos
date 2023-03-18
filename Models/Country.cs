using System.ComponentModel.DataAnnotations;

namespace GBCSporting_Team_Amigos.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
