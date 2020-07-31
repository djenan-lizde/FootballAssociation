using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class PlayerPositions
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public Players Player { get; set; }

        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }
        public Positions Position { get; set; }
    }
}
