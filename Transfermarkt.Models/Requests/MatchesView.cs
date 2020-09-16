using System;
using System.Collections.Generic;
using System.Text;

namespace Transfermarkt.Models.Requests
{
    public class MatchesView
    {
        public int Id { get; set; }
        public string HomeClub { get; set; }
        public string AwayClub { get; set; }
        public string GameStart { get; set; }
        public string GameEnd { get; set; }
        public bool IsFinished { get; set; }
        public DateTime GameDate { get; set; }
        public string StadiumName { get; set; }
    }
}
