using System;

namespace Transfermarkt.Models
{
    public class ClubsLeague
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public int LeagueId { get; set; }
        public int SeasonId { get; set; }
        public int Points { get; set; }
        public TimeSpan LastUpdate { get; set; }
    }
}
