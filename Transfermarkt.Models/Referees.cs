using System.ComponentModel.DataAnnotations;

namespace Transfermarkt.Models
{
    public class Referees
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required]
        public int CityId { get; set; }
    }
}
