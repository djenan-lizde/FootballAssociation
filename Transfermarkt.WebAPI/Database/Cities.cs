using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class Cities
    {
        public Cities()
        {
            Clubs = new HashSet<Clubs>();
            Referees = new HashSet<Referees>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int PostalCode { get; set; }

        public virtual ICollection<Clubs> Clubs { get; set; }
        public virtual ICollection<Referees> Referees { get; set; }
    }
}
