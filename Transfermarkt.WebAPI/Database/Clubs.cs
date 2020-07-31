using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class Clubs
    {
        public Clubs()
        {
            Contracts = new HashSet<Contracts>();
            MatchesAwayClub = new HashSet<Matches>();
            MatchesHomeClub = new HashSet<Matches>();
            Stadiums = new HashSet<Stadiums>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Nickname { get; set; }
        public DateTime Founded { get; set; }
        public byte[] Logo { get; set; }
        public int MarketValue { get; set; }
        public int CityId { get; set; }

        public virtual Cities City { get; set; }
        public virtual ICollection<Contracts> Contracts { get; set; }
        public virtual ICollection<Matches> MatchesAwayClub { get; set; }
        public virtual ICollection<Matches> MatchesHomeClub { get; set; }
        public virtual ICollection<Stadiums> Stadiums { get; set; }
    }
}
