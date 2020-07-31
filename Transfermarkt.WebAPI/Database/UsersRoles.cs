using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class UsersRoles
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
