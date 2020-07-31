using System;
using System.Collections.Generic;
using System.Text;
using static Transfermarkt.Models.Enums.Enums;

namespace Transfermarkt.Models
{
    public class Players
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Jersey { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
        public int StrongerFoot { get; set; }
        public DateTime Birthdate { get; set; }
        public bool IsSigned { get; set; }
    }
}
