using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class Seasons
    {
        public Seasons()
        {
            Matches = new HashSet<Matches>();
        }

        public int Id { get; set; }
        public string SeasonYear { get; set; }

        public virtual ICollection<Matches> Matches { get; set; }
    }
}
