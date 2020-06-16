using System;
using System.Collections.Generic;
using System.Text;

namespace Transfermarkt.MobileApp.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Clubs,
        Leagues,
        Players
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
