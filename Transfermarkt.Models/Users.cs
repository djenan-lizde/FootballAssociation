using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Transfermarkt.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime JoinDate { get; set; }

        public ICollection<UsersRoles> UserRoles { get; set; }
    }
}
