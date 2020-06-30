using System;
using System.Collections.Generic;
using System.Text;

namespace Transfermarkt.Models.Requests
{
    public class PlayersCorners
    {
        public string PlayerFullName { get; set; }
        public string ClubName { get; set; }
        public int Minute { get; set; }
    }
}
