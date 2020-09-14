using System;
using System.Collections.Generic;
using System.Text;

namespace Transfermarkt.MobileApp.Models
{
    public enum MenuItemType
    {
        Clubs,
        Leagues,
        Players,
        Matches
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
