using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class Leagues
    {
        public Leagues()
        {
            Matches = new HashSet<Matches>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Organizer { get; set; }
        public DateTime Established { get; set; }

        public virtual ICollection<Matches> Matches { get; set; }
    }
}
