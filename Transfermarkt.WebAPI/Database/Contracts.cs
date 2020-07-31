using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class Contracts
    {
        public int Id { get; set; }
        public DateTime SignedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int RedemptionClause { get; set; }
        public int ClubId { get; set; }
        public int PlayerId { get; set; }
        public bool? IsExpired { get; set; }

        public virtual Clubs Club { get; set; }
        public virtual Players Player { get; set; }
    }
}
