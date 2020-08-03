using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class PlayerPositions
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int PositionId { get; set; }
    }
}
