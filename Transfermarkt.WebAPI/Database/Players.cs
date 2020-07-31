using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class Players
    {
        public Players()
        {
            Contracts = new HashSet<Contracts>();
            PlayerPositions = new HashSet<PlayerPositions>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Jersey { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
        public int StrongerFoot { get; set; }
        public DateTime Birthdate { get; set; }
        public bool? IsSigned { get; set; }

        public virtual ICollection<Contracts> Contracts { get; set; }
        public virtual ICollection<PlayerPositions> PlayerPositions { get; set; }
    }
}
