using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class RefereeMatches
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int RefereeId { get; set; }

        public virtual Matches Match { get; set; }
        public virtual Referees Referee { get; set; }
    }
}
