using System.ComponentModel.DataAnnotations;


namespace Transfermarkt.Models
{
    public class Positions
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Abbreviation { get; set; }
    }
}
