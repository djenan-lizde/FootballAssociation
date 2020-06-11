using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class PlayerPosition
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Player))]
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        [ForeignKey(nameof(Position))]
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
