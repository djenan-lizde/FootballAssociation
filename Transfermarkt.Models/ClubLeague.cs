using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class ClubLeague
    {
        public int Id { get; set; }

        //[ForeignKey(nameof(Club))]
        public int ClubId { get; set; }
        //public Club Club { get; set; }

        //[ForeignKey(nameof(League))]
        public int LeagueId { get; set; }
        //public League League { get; set; }

        //[ForeignKey(nameof(Season))]
        public int SeasonId { get; set; }
        //public Season Season { get; set; }
        public int Points { get; set; }
        public TimeSpan LastUpdate { get; set; }
    }
}
