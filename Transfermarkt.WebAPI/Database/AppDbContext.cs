using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transfermarkt.Models;

namespace Transfermarkt.WebAPI.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ClubLeague> ClubsLeague { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchDetail> MatchDetails { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerPosition> PlayerPositions { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<RefereeMatch> RefereeMatches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsersRoles> UsersRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
