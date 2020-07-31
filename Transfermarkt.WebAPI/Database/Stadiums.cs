using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class Stadiums
    {
        public Stadiums()
        {
            Matches = new HashSet<Matches>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateBuilt { get; set; }
        public int Capacity { get; set; }
        public int ClubId { get; set; }

        public virtual Clubs Club { get; set; }
        public virtual ICollection<Matches> Matches { get; set; }
    }
}
