﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateBuilt { get; set; }
        public int Capacity { get; set; }
        [ForeignKey(nameof(Club))]
        public int ClubId { get; set; }
        public Club Club { get; set; }
    }
}