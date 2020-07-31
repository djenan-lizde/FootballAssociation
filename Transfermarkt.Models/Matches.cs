using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class Matches
    {
        public int Id { get; set; }
        public DateTime DateGame { get; set; }
        public string GameStart { get; set; }
        public string GameEnd { get; set; }
        public bool IsFinished { get; set; }

        [ForeignKey(nameof(Stadium))]
        public int StadiumId { get; set; }
        public Stadiums Stadium { get; set; }

        [ForeignKey(nameof(HomeClub))]
        public int HomeClubId { get; set; }
        public Clubs HomeClub { get; set; }

        [ForeignKey(nameof(AwayClub))]
        public int AwayClubId { get; set; }
        public Clubs AwayClub { get; set; }

        [ForeignKey(nameof(League))]
        public int LeagueId { get; set; }
        public Leagues League { get; set; }

        [ForeignKey(nameof(Season))]
        public int SeasonId { get; set; }
        public Seasons Season { get; set; }
    }
}
