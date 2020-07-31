using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Transfermarkt.WebAPI.Database
{
    public partial class FootballAssociationDbContext : DbContext
    {
        public FootballAssociationDbContext()
        {
        }

        public FootballAssociationDbContext(DbContextOptions<FootballAssociationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Clubs> Clubs { get; set; }
        public virtual DbSet<ClubsLeague> ClubsLeague { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<Leagues> Leagues { get; set; }
        public virtual DbSet<MatchDetails> MatchDetails { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<PlayerPositions> PlayerPositions { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<RefereeMatches> RefereeMatches { get; set; }
        public virtual DbSet<Referees> Referees { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Seasons> Seasons { get; set; }
        public virtual DbSet<Stadiums> Stadiums { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersRoles> UsersRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-0415RGN\\DJENANSQL;Database=FootballAssociation;Trusted_Connection=false;User=sa;Password=Globus315");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clubs>(entity =>
            {
                entity.HasIndex(e => e.CityId);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.HasIndex(e => e.ClubId);

                entity.HasIndex(e => e.PlayerId);

                entity.Property(e => e.IsExpired)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MatchDetails>(entity =>
            {
                entity.HasIndex(e => e.MatchId);

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchDetails)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Matches>(entity =>
            {
                entity.HasIndex(e => e.AwayClubId);

                entity.HasIndex(e => e.HomeClubId);

                entity.HasIndex(e => e.LeagueId);

                entity.HasIndex(e => e.SeasonId);

                entity.HasIndex(e => e.StadiumId);

                entity.HasOne(d => d.AwayClub)
                    .WithMany(p => p.MatchesAwayClub)
                    .HasForeignKey(d => d.AwayClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.HomeClub)
                    .WithMany(p => p.MatchesHomeClub)
                    .HasForeignKey(d => d.HomeClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.LeagueId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Stadium)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.StadiumId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PlayerPositions>(entity =>
            {
                entity.HasIndex(e => e.PlayerId);

                entity.HasIndex(e => e.PositionId);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerPositions)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.PlayerPositions)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.Property(e => e.IsSigned)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            modelBuilder.Entity<RefereeMatches>(entity =>
            {
                entity.HasIndex(e => e.MatchId);

                entity.HasIndex(e => e.RefereeId);

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.RefereeMatches)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Referee)
                    .WithMany(p => p.RefereeMatches)
                    .HasForeignKey(d => d.RefereeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Referees>(entity =>
            {
                entity.HasIndex(e => e.CityId);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Referees)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Stadiums>(entity =>
            {
                entity.HasIndex(e => e.ClubId);

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Stadiums)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UsersRoles>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
