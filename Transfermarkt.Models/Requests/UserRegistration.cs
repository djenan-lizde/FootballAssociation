using System;
using System.Collections.Generic;
using System.Text;

namespace Transfermarkt.Models
{
    public class UserRegistration
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Roles { get; set; } = new List<int>();
    }
}
