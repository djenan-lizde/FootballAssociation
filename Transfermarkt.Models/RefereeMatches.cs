using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class RefereeMatches
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int RefereeId { get; set; }
    }
}
