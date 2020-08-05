using System;
using System.ComponentModel.DataAnnotations;


namespace Transfermarkt.Models
{
    public class Leagues
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Organizer { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Established { get; set; }
    }
}
