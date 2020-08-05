using System;
using System.ComponentModel.DataAnnotations;

namespace Transfermarkt.Models
{
    public class MatchDetails
    {
        public int Id { get; set; }
        [Required]
        public int MatchId { get; set; }
        [Required]
        public int ActionType { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public int ClubId { get; set; }
        [Required]
        [Range(0, 95, ErrorMessage = "Please insert an integer number between 0 and 95")]
        public int Minute { get; set; }
    }
}
