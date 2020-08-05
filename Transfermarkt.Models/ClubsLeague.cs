using System;
using System.ComponentModel.DataAnnotations;


namespace Transfermarkt.Models
{
    public class ClubsLeague
    {
        public int Id { get; set; }
        [Required]
        public int ClubId { get; set; }
        [Required]
        public int LeagueId { get; set; }
        [Required]
        public int SeasonId { get; set; }
        [Required]
        public int Points { get; set; }
        public TimeSpan LastUpdate { get; set; }
    }
}
