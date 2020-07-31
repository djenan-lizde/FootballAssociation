using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class Clubs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Nickname { get; set; }
        public DateTime Founded { get; set; }
        public byte[] Logo { get; set; }
        public int MarketValue { get; set; }
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public Cities City { get; set; }
    }
}
