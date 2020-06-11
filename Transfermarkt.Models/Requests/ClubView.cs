using System;
using System.Collections.Generic;
using System.Text;

namespace Transfermarkt.Models.Requests
{
    public class ClubView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Nickname { get; set; }
        public DateTime Founded { get; set; }
        public int MarketValue { get; set; }
    }
}
