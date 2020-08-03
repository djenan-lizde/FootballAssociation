using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class Contracts
    {
        public int Id { get; set; }

        public DateTime SignedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int RedemptionClause { get; set; }
        public bool IsExpired { get; set; }
        public int ClubId { get; set; }
        public int PlayerId { get; set; }
    }
}
