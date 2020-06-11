using System;
using System.ComponentModel.DataAnnotations.Schema;
using static Transfermarkt.Models.Enums.Enums;

namespace Transfermarkt.Models
{
    public class MatchDetail
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Match))]
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public int ActionType { get; set; }
        public int PlayerId { get; set; }
        public int ClubId { get; set; }
        public int Minute { get; set; }
    }
}
