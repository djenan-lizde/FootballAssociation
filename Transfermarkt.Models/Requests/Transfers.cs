using System;
using System.Collections.Generic;
using System.Text;

namespace Transfermarkt.Models.Requests
{
    public class Transfers
    {
        public string ClubName { get; set; }
        public int RedemptionClause { get; set; }
        public string PlayerFullName { get; set; }
        public DateTime ContractExpirationDate { get; set; }
    }
}
