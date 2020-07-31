using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class MatchDetails
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int ActionType { get; set; }
        public int PlayerId { get; set; }
        public int ClubId { get; set; }
        public int Minute { get; set; }

        public virtual Matches Match { get; set; }
    }
}
