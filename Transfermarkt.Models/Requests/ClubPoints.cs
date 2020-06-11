using System;
using System.Collections.Generic;
using System.Text;

namespace Transfermarkt.Models.Requests
{
    public class ClubPoints
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public byte[] Logo { get; set; }
        public int Points { get; set; }
    }
}
