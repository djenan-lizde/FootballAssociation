using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime DateGame { get; set; }
        public string GameStart { get; set; }
        public string GameEnd { get; set; }
        public bool IsFinished { get; set; }

        [ForeignKey(nameof(Stadium))]
        public int StadiumId { get; set; }
        public Stadium Stadium { get; set; }

        [ForeignKey(nameof(HomeClub))]
        public int HomeClubId { get; set; }
        public Club HomeClub { get; set; }

        [ForeignKey(nameof(AwayClub))]
        public int AwayClubId { get; set; }
        public Club AwayClub { get; set; }

        [ForeignKey(nameof(League))]
        public int LeagueId { get; set; }
        public League League { get; set; }

        [ForeignKey(nameof(Season))]
        public int SeasonId { get; set; }
        public Season Season { get; set; }
    }
}
