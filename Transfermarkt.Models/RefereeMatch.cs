using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class RefereeMatch
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Match))]
        public int MatchId { get; set; }
        public Match Match { get; set; }

        [ForeignKey(nameof(Referee))]
        public int RefereeId { get; set; }
        public Referee Referee { get; set; }
    }
}
