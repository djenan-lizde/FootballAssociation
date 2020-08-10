//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Transfermarkt.WebAPI.Encryption;

//namespace Transfermarkt.WebAPI.Database
//{
//    public partial class FootballAssociationDbContext
//    {
//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
//        {
//            //users
//            Users u1 = new Users
//            {
//                Id = 1,
//                Email = "desktop@mail.com",
//                FirstName = "test",
//                JoinDate = DateTime.Now,
//                LastName = "test",
//                Username = "desktop"
//            };
//            u1.PasswordSalt = HashGenSalt.GenerateSalt();
//            u1.PasswordHash = HashGenSalt.GenerateHash(u1.PasswordSalt, "test");
//            modelBuilder.Entity<Users>().HasData(u1);

//            Users u2 = new Users
//            {
//                Id = 2,
//                Email = "mobile@mail.com",
//                FirstName = "test",
//                JoinDate = DateTime.Now,
//                LastName = "test",
//                Username = "mobile"
//            };
//            u2.PasswordSalt = HashGenSalt.GenerateSalt();
//            u2.PasswordHash = HashGenSalt.GenerateHash(u2.PasswordSalt, "test");
//            modelBuilder.Entity<Users>().HasData(u2);

//            //roles
//            modelBuilder.Entity<Roles>().HasData(new WebAPI.Database.Roles()
//            {
//                Id = 1,
//                Name = "Administrator"
//            });
//            modelBuilder.Entity<Roles>().HasData(new WebAPI.Database.Roles()
//            {
//                Id = 2,
//                Name = "Member"
//            });

//            //users roles
//            modelBuilder.Entity<UsersRoles>().HasData(new WebAPI.Database.UsersRoles()
//            {
//                Id = 1,
//                RoleId = 1,
//                UserId = 1
//            });
//            modelBuilder.Entity<UsersRoles>().HasData(new WebAPI.Database.UsersRoles()
//            {
//                Id = 2,
//                RoleId = 2,
//                UserId = 2
//            });

//            //cities
//            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
//            {
//                Id = 1,
//                Name = "Dortmund",
//                PostalCode = 1132
//            });
//            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
//            {
//                Id = 2,
//                Name = "Berlin",
//                PostalCode = 1134
//            });
//            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
//            {
//                Id = 3,
//                Name = "Munchen",
//                PostalCode = 421
//            });
//            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
//            {
//                Id = 4,
//                Name = "Frankfurt",
//                PostalCode = 42
//            });
//            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
//            {
//                Id = 5,
//                Name = "Nurnberg",
//                PostalCode = 243
//            });
//            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
//            {
//                Id = 6,
//                Name = "Wiesbaden",
//                PostalCode = 15
//            });
//            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
//            {
//                Id = 7,
//                Name = "Hamburg",
//                PostalCode = 2143
//            });
//            modelBuilder.Entity<Cities>().HasData(new WebAPI.Database.Cities()
//            {
//                Id = 8,
//                Name = "Leverkusen",
//                PostalCode = 1442
//            });

//            //positions
//            modelBuilder.Entity<Positions>().HasData(new WebAPI.Database.Positions()
//            {
//                Id = 1,
//                Abbreviation = "GK",
//                Name = "GoalKeper"
//            });
//            modelBuilder.Entity<Positions>().HasData(new WebAPI.Database.Positions()
//            {
//                Id = 2,
//                Abbreviation = "CB",
//                Name = "CentreBack"
//            });
//            modelBuilder.Entity<Positions>().HasData(new WebAPI.Database.Positions()
//            {
//                Id = 3,
//                Abbreviation = "MF",
//                Name = "Midfield"
//            });
//            modelBuilder.Entity<Positions>().HasData(new WebAPI.Database.Positions()
//            {
//                Id = 4,
//                Abbreviation = "ST",
//                Name = "Striker"
//            });

//            //leagues
//            modelBuilder.Entity<Leagues>().HasData(new WebAPI.Database.Leagues()
//            {
//                Id = 1,
//                Name = "Bundesliga",
//                Established = DateTime.Now,
//                Organizer = "DFB"
//            });
//            modelBuilder.Entity<Leagues>().HasData(new WebAPI.Database.Leagues()
//            {
//                Id = 2,
//                Name = "Bundesliga 2",
//                Established = DateTime.Now,
//                Organizer = "DFB"
//            });

//            //clubs
//            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
//            {
//                Id = 1,
//                Name = "Borussia Dortmund",
//                Abbreviation = "BVB",
//                CityId = 1,
//                Founded = DateTime.Now,
//                Logo = File.ReadAllBytes("Img/BorussiaDortmund.png"),
//                MarketValue = 1000000,
//                Nickname = "Milioneri"
//            });
//            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
//            {
//                Id = 2,
//                Name = "Hertha Berlin",
//                Abbreviation = "HB",
//                CityId = 2,
//                Founded = DateTime.Now,
//                Logo = File.ReadAllBytes("Img/HerthaBerlin.png"),
//                MarketValue = 244443,
//                Nickname = "Berliners"
//            });
//            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
//            {
//                Id = 3,
//                Name = "Union Berlin",
//                Abbreviation = "UB",
//                CityId = 2,
//                Founded = DateTime.Now,
//                Logo = File.ReadAllBytes("Img/UnionBerlin.jpg"),
//                MarketValue = 72532,
//                Nickname = "Berliners"
//            });
//            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
//            {
//                Id = 4,
//                Name = "Bayern Munchen",
//                Abbreviation = "BMH",
//                CityId = 3,
//                Founded = DateTime.Now,
//                Logo = File.ReadAllBytes("Img/BayernMunich.png"),
//                MarketValue = 72532,
//                Nickname = "Bavarci"
//            });
//            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
//            {
//                Id = 5,
//                Name = "Nurnberg",
//                Abbreviation = "NB",
//                CityId = 5,
//                Founded = DateTime.Now,
//                Logo = File.ReadAllBytes("Img/Nurnberg.png"),
//                MarketValue = 237981,
//                Nickname = "Bergs"
//            });
//            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
//            {
//                Id = 6,
//                Name = "St. Pauli",
//                Abbreviation = "STP",
//                CityId = 7,
//                Founded = DateTime.Now,
//                Logo = File.ReadAllBytes("Img/StPauli.png"),
//                MarketValue = 7234,
//                Nickname = "Pauls"
//            });
//            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
//            {
//                Id = 7,
//                Name = "Bayer Leverkusen",
//                Abbreviation = "BLE",
//                CityId = 8,
//                Founded = DateTime.Now,
//                Logo = File.ReadAllBytes("Img/Leverkuzen.png"),
//                MarketValue = 151243,
//                Nickname = "Pharmacists"
//            });
//            modelBuilder.Entity<Clubs>().HasData(new WebAPI.Database.Clubs()
//            {
//                Id = 8,
//                Name = "Wehen Wiesbaden",
//                Abbreviation = "WW",
//                CityId = 6,
//                Founded = DateTime.Now,
//                Logo = File.ReadAllBytes("Img/Wiesbaden.png"),
//                MarketValue = 151243,
//                Nickname = "Pharmacists"
//            });

//            //stadium
//            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
//            {
//                Id = 1,
//                Capacity = 80000,
//                ClubId = 1,
//                DateBuilt = DateTime.Now,
//                Name = "Signal Iduna Park"
//            });
//            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
//            {
//                Id = 2,
//                Capacity = 75000,
//                ClubId = 2,
//                DateBuilt = DateTime.Now,
//                Name = "Olympiastadion Berlin"
//            });
//            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
//            {
//                Id = 3,
//                Capacity = 70000,
//                ClubId = 3,
//                DateBuilt = DateTime.Now,
//                Name = "Stadion An der Alten Försterei"
//            });
//            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
//            {
//                Id = 4,
//                Capacity = 75000,
//                ClubId = 4,
//                DateBuilt = DateTime.Now,
//                Name = "Allianz Arena"
//            });
//            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
//            {
//                Id = 5,
//                Capacity = 40000,
//                ClubId = 5,
//                DateBuilt = DateTime.Now,
//                Name = "Max-Morlock-Stadion"
//            });
//            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
//            {
//                Id = 6,
//                Capacity = 35000,
//                ClubId = 6,
//                DateBuilt = DateTime.Now,
//                Name = "Millerntor-Stadion"
//            });
//            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
//            {
//                Id = 7,
//                Capacity = 55000,
//                ClubId = 7,
//                DateBuilt = DateTime.Now,
//                Name = "BayArena"
//            });
//            modelBuilder.Entity<Stadiums>().HasData(new WebAPI.Database.Stadiums()
//            {
//                Id = 8,
//                Capacity = 40000,
//                ClubId = 8,
//                DateBuilt = DateTime.Now,
//                Name = "Brita-Arena"
//            });

//            //referee
//            modelBuilder.Entity<Referees>().HasData(new WebAPI.Database.Referees()
//            {
//                Id = 1,
//                CityId = 1,
//                FirstName = "Felix",
//                LastName = "Magath",
//                MiddleName = "N/A"
//            });
//            modelBuilder.Entity<Referees>().HasData(new WebAPI.Database.Referees()
//            {
//                Id = 2,
//                CityId = 3,
//                FirstName = "Felix",
//                LastName = "Brych",
//                MiddleName = "N/A"
//            });
//            modelBuilder.Entity<Referees>().HasData(new WebAPI.Database.Referees()
//            {
//                Id = 3,
//                CityId = 4,
//                FirstName = "Marco",
//                LastName = "Fritz",
//                MiddleName = "N/A"
//            });
//            modelBuilder.Entity<Referees>().HasData(new WebAPI.Database.Referees()
//            {
//                Id = 4,
//                CityId = 5,
//                FirstName = "Manuel",
//                LastName = "Grafe",
//                MiddleName = "N/A"
//            });
//            modelBuilder.Entity<Referees>().HasData(new WebAPI.Database.Referees()
//            {
//                Id = 5,
//                CityId = 6,
//                FirstName = "Tobias",
//                LastName = "Welz",
//                MiddleName = "N/A"
//            });

//            //players
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 1,
//                Birthdate = DateTime.Now,
//                FirstName = "Mats",
//                LastName = "Hummels",
//                Height = 200,
//                IsSigned = true,
//                Jersey = 5,
//                MiddleName = "N/A",
//                StrongerFoot = 1,
//                Value = 100000,
//                Weight = 90
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 2,
//                Birthdate = DateTime.Now,
//                FirstName = "Marco",
//                LastName = "Reus",
//                Height = 180,
//                IsSigned = true,
//                Jersey = 17,
//                MiddleName = "N/A",
//                StrongerFoot = 2,
//                Value = 100000,
//                Weight = 85
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 3,
//                Birthdate = DateTime.Now,
//                FirstName = "Robert",
//                LastName = "Lewandovski",
//                Height = 180,
//                IsSigned = true,
//                Jersey = 7,
//                MiddleName = "N/A",
//                StrongerFoot = 2,
//                Value = 100000,
//                Weight = 85
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 4,
//                Birthdate = DateTime.Now,
//                FirstName = "Thomas",
//                LastName = "Muller",
//                Height = 180,
//                IsSigned = true,
//                Jersey = 7,
//                MiddleName = "N/A",
//                StrongerFoot = 2,
//                Value = 100000,
//                Weight = 85
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 5,
//                Birthdate = DateTime.Now,
//                FirstName = "Vedad",
//                LastName = "Ibisevic",
//                Height = 190,
//                IsSigned = true,
//                Jersey = 7,
//                MiddleName = "N/A",
//                StrongerFoot = 2,
//                Value = 100000,
//                Weight = 85
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 6,
//                Birthdate = DateTime.Now,
//                FirstName = "Dodi",
//                LastName = "Lukebakio",
//                Height = 200,
//                IsSigned = true,
//                Jersey = 7,
//                MiddleName = "N/A",
//                StrongerFoot = 0,
//                Value = 200000,
//                Weight = 85
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 7,
//                Birthdate = DateTime.Now,
//                FirstName = "Charles",
//                LastName = "Aranguiz",
//                Height = 180,
//                IsSigned = true,
//                Jersey = 7,
//                MiddleName = "N/A",
//                StrongerFoot = 2,
//                Value = 100000,
//                Weight = 85
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 8,
//                Birthdate = DateTime.Now,
//                FirstName = "Kai",
//                LastName = "Havertz",
//                Height = 180,
//                IsSigned = true,
//                Jersey = 7,
//                MiddleName = "N/A",
//                StrongerFoot = 1,
//                Value = 100000,
//                Weight = 85
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 9,
//                Birthdate = DateTime.Now,
//                FirstName = "Robin",
//                LastName = "Hack",
//                Height = 180,
//                IsSigned = true,
//                Jersey = 7,
//                MiddleName = "N/A",
//                StrongerFoot = 1,
//                Value = 20000,
//                Weight = 85
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 10,
//                Birthdate = DateTime.Now,
//                FirstName = "Patric",
//                LastName = "Erras",
//                Height = 180,
//                IsSigned = true,
//                Jersey = 7,
//                MiddleName = "N/A",
//                StrongerFoot = 1,
//                Value = 20000,
//                Weight = 85
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 11,
//                Birthdate = DateTime.Now,
//                FirstName = "Henk",
//                LastName = "Veerman",
//                Height = 180,
//                IsSigned = true,
//                Jersey = 14,
//                MiddleName = "N/A",
//                StrongerFoot = 1,
//                Value = 204000,
//                Weight = 77
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 12,
//                Birthdate = DateTime.Now,
//                FirstName = "Marvin",
//                LastName = "Senger",
//                Height = 205,
//                IsSigned = true,
//                Jersey = 7,
//                MiddleName = "N/A",
//                StrongerFoot = 0,
//                Value = 444000,
//                Weight = 100
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 13,
//                Birthdate = DateTime.Now,
//                FirstName = "Neven",
//                LastName = "Subotic",
//                Height = 195,
//                IsSigned = true,
//                Jersey = 2,
//                MiddleName = "N/A",
//                StrongerFoot = 0,
//                Value = 10000,
//                Weight = 93
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 14,
//                Birthdate = DateTime.Now,
//                FirstName = "Felix",
//                LastName = "Kroos",
//                Height = 176,
//                IsSigned = true,
//                Jersey = 99,
//                MiddleName = "N/A",
//                StrongerFoot = 0,
//                Value = 444000,
//                Weight = 77
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 15,
//                Birthdate = DateTime.Now,
//                FirstName = "Manuel",
//                LastName = "Schaffler",
//                Height = 186,
//                IsSigned = true,
//                Jersey = 99,
//                MiddleName = "N/A",
//                StrongerFoot = 0,
//                Value = 444000,
//                Weight = 77
//            });
//            modelBuilder.Entity<Players>().HasData(new WebAPI.Database.Players()
//            {
//                Id = 16,
//                Birthdate = DateTime.Now,
//                FirstName = "Paterson",
//                LastName = "Chato",
//                Height = 197,
//                IsSigned = true,
//                Jersey = 99,
//                MiddleName = "N/A",
//                StrongerFoot = 2,
//                Value = 444000,
//                Weight = 77
//            });

//            //contracts
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 1,
//                ClubId = 1,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 1,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 2,
//                ClubId = 2,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 2,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 3,
//                ClubId = 4,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 3,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 4,
//                ClubId = 4,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 4,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 5,
//                ClubId = 2,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 5,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 6,
//                ClubId = 2,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 6,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 7,
//                ClubId = 3,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 7,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 8,
//                ClubId = 3,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 8,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 9,
//                ClubId = 5,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 9,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 10,
//                ClubId = 5,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 10,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 11,
//                ClubId = 6,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 11,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 12,
//                ClubId = 6,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 12,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 13,
//                ClubId = 7,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 13,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 14,
//                ClubId = 7,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 14,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 15,
//                ClubId = 8,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 15,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });
//            modelBuilder.Entity<Contracts>().HasData(new WebAPI.Database.Contracts()
//            {
//                Id = 16,
//                ClubId = 8,
//                ExpirationDate = DateTime.Now.AddYears(3),
//                IsExpired = false,
//                PlayerId = 16,
//                RedemptionClause = 50000,
//                SignedDate = DateTime.Now
//            });

//            //playerPositions
//            var rand = new Random();
//            for (int i = 1; i <= 16; i++)
//            {
//                modelBuilder.Entity<PlayerPositions>().HasData(new WebAPI.Database.PlayerPositions()
//                {
//                    Id = i,
//                    PlayerId = i,
//                    PositionId = rand.Next(1, 4)
//                });
//            }
//        }
//    }
//}
