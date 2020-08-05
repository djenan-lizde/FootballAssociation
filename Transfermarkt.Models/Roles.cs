using System.ComponentModel.DataAnnotations;


namespace Transfermarkt.Models
{
    public class Roles
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
