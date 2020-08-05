using System;
using System.ComponentModel.DataAnnotations;

namespace Transfermarkt.Models
{
    public class Stadiums
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateBuilt { get; set; }
        [Required]
        [Range(0,100000,ErrorMessage ="Please insert an integer number between 0 and 100000")]
        public int Capacity { get; set; }
        [Required]
        public int ClubId { get; set; }
    }
}
