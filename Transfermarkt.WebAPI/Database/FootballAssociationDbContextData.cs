using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Transfermarkt.WebAPI.Encryption;

namespace Transfermarkt.WebAPI.Database
{
    public partial class FootballAssociationDbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //users
            Users u1 = new Users
            {
                Id = 1,
                Email = "desktop@mail.com",
                FirstName = "test",
                JoinDate = DateTime.Now,
                LastName = "test",
                Username = "desktop"
            };
            u1.PasswordSalt = HashGenSalt.GenerateSalt();
            u1.PasswordHash = HashGenSalt.GenerateHash(u1.PasswordSalt, "test");
            modelBuilder.Entity<Users>().HasData(u1);

            Users u2 = new Users
            {
                Id = 2,
                Email = "mobile@mail.com",
                FirstName = "test",
                JoinDate = DateTime.Now,
                LastName = "test",
                Username = "mobile"
            };
            u2.PasswordSalt = HashGenSalt.GenerateSalt();
            u2.PasswordHash = HashGenSalt.GenerateHash(u2.PasswordSalt, "test");
            modelBuilder.Entity<Users>().HasData(u2);

            Users u3 = new Users
            {
                Id = 3,
                Email = "user@mail.com",
                FirstName = "user",
                JoinDate = DateTime.Now,
                LastName = "user",
                Username = "user"
            };
            u3.PasswordSalt = HashGenSalt.GenerateSalt();
            u3.PasswordHash = HashGenSalt.GenerateHash(u3.PasswordSalt, "test");
            modelBuilder.Entity<Users>().HasData(u3);

            //roles
            modelBuilder.Entity<Roles>().HasData(new WebAPI.Database.Roles()
            {
                Id = 1,
                Name = "Administrator"
            });
            modelBuilder.Entity<Roles>().HasData(new WebAPI.Database.Roles()
            {
                Id = 2,
                Name = "Member"
            });

            //users roles
            modelBuilder.Entity<UsersRoles>().HasData(new WebAPI.Database.UsersRoles()
            {
                Id = 1,
                RoleId = 1,
                UserId = 1
            });
            modelBuilder.Entity<UsersRoles>().HasData(new WebAPI.Database.UsersRoles()
            {
                Id = 2,
                RoleId = 2,
                UserId = 1
            });
            modelBuilder.Entity<UsersRoles>().HasData(new WebAPI.Database.UsersRoles()
            {
                Id = 3,
                RoleId = 1,
                UserId = 2
            });
            modelBuilder.Entity<UsersRoles>().HasData(new WebAPI.Database.UsersRoles()
            {
                Id = 4,
                RoleId = 2,
                UserId = 2
            });
            modelBuilder.Entity<UsersRoles>().HasData(new WebAPI.Database.UsersRoles()
            {
                Id = 5,
                RoleId = 2,
                UserId = 3
            });

            //cities
            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
            {
                Id = 1,
                Name = "Dortmund",
                PostalCode = 1132
            });
            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
            {
                Id = 2,
                Name = "Berlin",
                PostalCode = 1134
            });
            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
            {
                Id = 3,
                Name = "Munchen",
                PostalCode = 421
            });
            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
            {
                Id = 4,
                Name = "Frankfurt",
                PostalCode = 42
            });
            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
            {
                Id = 5,
                Name = "Nurnberg",
                PostalCode = 243
            });
            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
            {
                Id = 6,
                Name = "Wiesbaden",
                PostalCode = 15
            });
            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
            {
                Id = 7,
                Name = "Hamburg",
                PostalCode = 2143
            });
            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
            {
                Id = 8,
                Name = "Leverkusen",
                PostalCode = 1442
            });

            //positions
            modelBuilder.Entity<Positions>().HasData(new WebAPI.Database.Positions()
            {
                Id = 1,
                Abbreviation = "GK",
                Name = "GoalKeper"
            });
            modelBuilder.Entity<Positions>().HasData(new WebAPI.Database.Positions()
            {
                Id = 2,
                Abbreviation = "CB",
                Name = "CentreBack"
            });
            modelBuilder.Entity<Positions>().HasData(new WebAPI.Database.Positions()
            {
                Id = 3,
                Abbreviation = "MF",
                Name = "Midfield"
            });
            modelBuilder.Entity<Positions>().HasData(new WebAPI.Database.Positions()
            {
                Id = 4,
                Abbreviation = "ST",
                Name = "Striker"
            });

            //leagues
            modelBuilder.Entity<Leagues>().HasData(new WebAPI.Database.Leagues()
            {
                Id = 1,
                Name = "Bundesliga",
                Established = DateTime.Now,
                Organizer = "DFB"
            });
            modelBuilder.Entity<Leagues>().HasData(new WebAPI.Database.Leagues()
            {
                Id = 2,
                Name = "Bundesliga 2",
                Established = DateTime.Now,
                Organizer = "DFB"
            });

            //clubs
            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
            {
                Id = 1,
                Name = "Borussia Dortmund",
                Abbreviation = "BVB",
                CityId = 1,
                Founded = DateTime.Now,
                Logo = File.ReadAllBytes("Img/BorussiaDortmund.png"),
                MarketValue = 1000000,
                Nickname = "Milioneri"
            });
            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
            {
                Id = 2,
                Name = "Hertha Berlin",
                Abbreviation = "HB",
                CityId = 2,
                Founded = DateTime.Now,
                Logo = File.ReadAllBytes("Img/HerthaBerlin.png"),
                MarketValue = 244443,
                Nickname = "Berliners"
            });
            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
            {
                Id = 3,
                Name = "Union Berlin",
                Abbreviation = "UB",
                CityId = 2,
                Founded = DateTime.Now,
                Logo = File.ReadAllBytes("Img/UnionBerlin.jpg"),
                MarketValue = 72532,
                Nickname = "Berliners"
            });
            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
            {
                Id = 4,
                Name = "Bayern Munchen",
                Abbreviation = "BMH",
                CityId = 3,
                Founded = DateTime.Now,
                Logo = File.ReadAllBytes("Img/BayernMunich.png"),
                MarketValue = 72532,
                Nickname = "Bavarci"
            });
            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
            {
                Id = 5,
                Name = "Nurnberg",
                Abbreviation = "NB",
                CityId = 5,
                Founded = DateTime.Now,
                Logo = File.ReadAllBytes("Img/Nurnberg.png"),
                MarketValue = 237981,
                Nickname = "Bergs"
            });
            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
            {
                Id = 6,
                Name = "St. Pauli",
                Abbreviation = "STP",
                CityId = 7,
                Founded = DateTime.Now,
                Logo = File.ReadAllBytes("Img/StPauli.png"),
                MarketValue = 7234,
                Nickname = "Pauls"
            });
            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
            {
                Id = 7,
                Name = "Bayer Leverkusen",
                Abbreviation = "BLE",
                CityId = 8,
                Founded = DateTime.Now,
                Logo = File.ReadAllBytes("Img/Leverkuzen.png"),
                MarketValue = 151243,
                Nickname = "Pharmacists"
            });
            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
            {
                Id = 8,
                Name = "Wehen Wiesbaden",
                Abbreviation = "WW",
                CityId = 6,
                Founded = DateTime.Now,
                Logo = File.ReadAllBytes("Img/Wiesbaden.png"),
                MarketValue = 151243,
                Nickname = "Pharmacists"
            });

            //stadium
            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
            {
                Id = 1,
                Capacity = 80000,
                ClubId = 1,
                DateBuilt = DateTime.Now,
                Name = "Signal Iduna Park"
            });
            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
            {
                Id = 2,
                Capacity = 75000,
                ClubId = 2,
                DateBuilt = DateTime.Now,
                Name = "Olympiastadion Berlin"
            });
            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
            {
                Id = 3,
                Capacity = 70000,
                ClubId = 3,
                DateBuilt = DateTime.Now,
                Name = "Stadion An der Alten Försterei"
            });
            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
            {
                Id = 4,
                Capacity = 75000,
                ClubId = 4,
                DateBuilt = DateTime.Now,
                Name = "Allianz Arena"
            });
            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
            {
                Id = 5,
                Capacity = 40000,
                ClubId = 5,
                DateBuilt = DateTime.Now,
                Name = "Max-Morlock-Stadion"
            });
            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
            {
                Id = 6,
                Capacity = 35000,
                ClubId = 6,
                DateBuilt = DateTime.Now,
                Name = "Millerntor-Stadion"
            });
            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
            {
                Id = 7,
                Capacity = 55000,
                ClubId = 7,
                DateBuilt = DateTime.Now,
                Name = "BayArena"
            });
            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
            {
                Id = 8,
                Capacity = 40000,
                ClubId = 8,
                DateBuilt = DateTime.Now,
                Name = "Brita-Arena"
            });

            //referee
            modelBuilder.Entity<Referees>().HasData(new WebAPI.Database.Referees()
            {
                Id = 1,
                CityId = 1,
                FirstName = "Felix",
                LastName = "Magath",
                MiddleName = "N/A"
            });
            modelBuilder.Entity<Referees>().HasData(new WebAPI.Database.Referees()
            {
                Id = 2,
                CityId = 3,
                FirstName = "Felix",
                LastName = "Brych",
                MiddleName = "N/A"
            });
            modelBuilder.Entity<Referees>().HasData(new WebAPI.Database.Referees()
            {
                Id = 3,
                CityId = 4,
                FirstName = "Marco",
                LastName = "Fritz",
                MiddleName = "N/A"
            });
            modelBuilder.Entity<Referees>().HasData(new WebAPI.Database.Referees()
            {
                Id = 4,
                CityId = 5,
                FirstName = "Manuel",
                LastName = "Grafe",
                MiddleName = "N/A"
            });
            modelBuilder.Entity<Referees>().HasData(new WebAPI.Database.Referees()
            {
                Id = 5,
                CityId = 6,
                FirstName = "Tobias",
                LastName = "Welz",
                MiddleName = "N/A"
            });
        }
    }
}
