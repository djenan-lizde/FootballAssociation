using System;
using System.Collections.Generic;

namespace Transfermarkt.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }

        public ICollection<UsersRoles> UserRoles { get; set; }
    }
}
