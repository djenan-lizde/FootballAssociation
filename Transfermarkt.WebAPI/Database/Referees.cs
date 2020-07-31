using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class Referees
    {
        public Referees()
        {
            RefereeMatches = new HashSet<RefereeMatches>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int CityId { get; set; }

        public virtual Cities City { get; set; }
        public virtual ICollection<RefereeMatches> RefereeMatches { get; set; }
    }
}
