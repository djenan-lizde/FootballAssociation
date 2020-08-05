using System;
using System.ComponentModel.DataAnnotations;

namespace Transfermarkt.Models
{
    public class Matches
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateGame { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string GameStart { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string GameEnd { get; set; }
        [Required]
        public bool IsFinished { get; set; }
        [Required]
        public int StadiumId { get; set; }
        [Required]
        public int HomeClubId { get; set; }
        [Required]
        public int AwayClubId { get; set; }
        [Required]
        public int LeagueId { get; set; }
        [Required]
        public int SeasonId { get; set; }
    }
}
