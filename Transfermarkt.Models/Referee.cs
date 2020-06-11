using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class Referee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
