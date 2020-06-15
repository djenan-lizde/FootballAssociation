using System;
using System.Collections.Generic;
using System.Text;

namespace Transfermarkt.Models.Requests
{
    public class PlayerContractsClubs
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        public DateTime SignedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int RedemptionClause { get; set; }
    }
}
