using System;
using System.Collections.Generic;
using System.Text;

namespace Transfermarkt.Models.Requests
{
    public class UserSearchRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
