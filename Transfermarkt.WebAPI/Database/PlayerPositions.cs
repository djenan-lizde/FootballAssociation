using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class PlayerPositions
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int PositionId { get; set; }

        public virtual Players Player { get; set; }
        public virtual Positions Position { get; set; }
    }
}
