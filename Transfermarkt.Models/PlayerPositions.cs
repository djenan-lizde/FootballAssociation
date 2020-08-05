using System.ComponentModel.DataAnnotations;

namespace Transfermarkt.Models
{
    public class PlayerPositions
    {
        public int Id { get; set; }

        [Required]
        public int PlayerId { get; set; }
        [Required]
        public int PositionId { get; set; }
    }
}
