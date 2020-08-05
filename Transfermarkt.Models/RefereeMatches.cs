using System.ComponentModel.DataAnnotations;

namespace Transfermarkt.Models
{
    public class RefereeMatches
    {
        public int Id { get; set; }
        [Required]
        public int MatchId { get; set; }
        [Required]
        public int RefereeId { get; set; }
    }
}
