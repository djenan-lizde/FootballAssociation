using System;
using System.Collections.Generic;

namespace Transfermarkt.WebAPI.Database
{
    public partial class Roles
    {
        public Roles()
        {
            UsersRoles = new HashSet<UsersRoles>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UsersRoles> UsersRoles { get; set; }
    }
}
