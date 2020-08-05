using System.ComponentModel.DataAnnotations;

namespace Transfermarkt.Models
{
    public class Cities
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please insert an integer number")]
        public int PostalCode { get; set; }
    }
}
