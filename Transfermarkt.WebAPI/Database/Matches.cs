using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class Matches
    {
        public Matches()
        {
            MatchDetails = new HashSet<MatchDetails>();
            RefereeMatches = new HashSet<RefereeMatches>();
        }

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

        public virtual Clubs AwayClub { get; set; }
        public virtual Clubs HomeClub { get; set; }
        public virtual Leagues League { get; set; }
        public virtual Seasons Season { get; set; }
        public virtual Stadiums Stadium { get; set; }
        public virtual ICollection<MatchDetails> MatchDetails { get; set; }
        public virtual ICollection<RefereeMatches> RefereeMatches { get; set; }
    }
}
