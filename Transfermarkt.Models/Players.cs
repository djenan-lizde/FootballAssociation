using System;
using System.ComponentModel.DataAnnotations;


namespace Transfermarkt.Models
{
    public class Players
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required]
        [Range(1,99,ErrorMessage ="Please insert an integer number between 1 and 99")]
        public int Jersey { get; set; }
        [Required]
        [Range(1, 250, ErrorMessage = "Please insert an integer number between 1 and 220")]
        public int Height { get; set; }
        [Required]
        [Range(1, 500, ErrorMessage = "Please insert an integer number between 1 and 200")]
        public int Weight { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please insert an integer number between 1 and 99")]
        public int Value { get; set; }
        [Required]
        public int StrongerFoot { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }
        [Required]
        public bool IsSigned { get; set; }
    }
}
