using System;
using System.ComponentModel.DataAnnotations;

namespace Transfermarkt.Models
{
    public class Clubs
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Abbreviation { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Nickname { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Founded { get; set; }
        [Required]
        public byte[] Logo { get; set; }
        [Required]
        [Range(0,int.MaxValue,ErrorMessage ="Please insert an integer number")]
        public int MarketValue { get; set; }
        [Required]
        public int CityId { get; set; }
    }
}
