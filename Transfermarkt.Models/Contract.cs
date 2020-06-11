using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public DateTime SignedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int RedemptionClause { get; set; }
        public bool IsExpired { get; set; }

        [ForeignKey(nameof(Club))]
        public int ClubId { get; set; }
        public Club Club { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
