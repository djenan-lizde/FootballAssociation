using System;
using System.Collections.Generic;
using System.Text;

namespace Transfermarkt.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Organizer { get; set; }
        public DateTime Established { get; set; }
    }
}
