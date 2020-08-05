using System;
using System.ComponentModel.DataAnnotations;

namespace Transfermarkt.Models
{
    public class Contracts
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SignedDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ExpirationDate { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please insert an integer number")]
        public int RedemptionClause { get; set; }
        [Required]
        public bool IsExpired { get; set; }
        [Required]
        public int ClubId { get; set; }
        [Required]
        public int PlayerId { get; set; }
    }
}
