using System;

namespace Transfermarkt.Models.Requests
{
    public class PlayersClub
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Jersey { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
