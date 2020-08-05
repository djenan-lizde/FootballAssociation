using System.ComponentModel.DataAnnotations;

namespace Transfermarkt.Models
{
    public class Seasons
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string SeasonYear { get; set; }
    }
}
