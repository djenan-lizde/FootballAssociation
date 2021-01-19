using System;

namespace Transfermarkt.Models.Requests
{
    public class Transfers
    {
        public string ClubName { get; set; }
        public string RedemptionClause { get; set; }
        public string PlayerFullName { get; set; }
        public DateTime ContractExpirationDate { get; set; }
    }
}
