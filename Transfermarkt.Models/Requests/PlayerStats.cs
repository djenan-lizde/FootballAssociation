using System;
using System.Collections.Generic;
using System.Text;

namespace Transfermarkt.Models.Requests
{
    public class PlayerStats
    {
        public int Id { get; set; }
        public int NumberOfGoals { get; set; }
        public int NumberOfYellowCards { get; set; }
        public int NumberOfRedCards { get; set; }
    }
}
