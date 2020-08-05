using System.ComponentModel.DataAnnotations;

namespace Transfermarkt.Models
{
    public class UsersRoles
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
