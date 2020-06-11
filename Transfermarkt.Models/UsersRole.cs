using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Transfermarkt.Models
{
    public class UsersRoles
    {
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
