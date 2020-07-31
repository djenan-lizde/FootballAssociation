using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class Positions
    {
        public Positions()
        {
            PlayerPositions = new HashSet<PlayerPositions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<PlayerPositions> PlayerPositions { get; set; }
    }
}
