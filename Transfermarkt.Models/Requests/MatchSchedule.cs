using System;
using System.Collections.Generic;
using System.Text;

namespace Transfermarkt.Models.Requests
{
    public class MatchSchedule
    {
        public int Id { get; set; }
        public string MatchGame { get; set; }
        public DateTime GameDate { get; set; }
    }
}
