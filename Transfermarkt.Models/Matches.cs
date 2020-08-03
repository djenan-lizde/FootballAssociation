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
        public int StadiumId { get; set; }
        public int HomeClubId { get; set; }
        public int AwayClubId { get; set; }
        public int LeagueId { get; set; }
        public int SeasonId { get; set; }
    }
}
