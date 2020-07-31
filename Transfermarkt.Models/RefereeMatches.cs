using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class RefereeMatches
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Match))]
        public int MatchId { get; set; }
        public Matches Match { get; set; }

        [ForeignKey(nameof(Referee))]
        public int RefereeId { get; set; }
        public Referees Referee { get; set; }
    }
}
