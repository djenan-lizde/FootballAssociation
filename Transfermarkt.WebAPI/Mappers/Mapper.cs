using AutoMapper;
using Transfermarkt.WebAPI.Database;

namespace Transfermarkt.WebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Cities, Models.Cities>().ReverseMap();
            CreateMap<Database.Clubs, Models.Clubs>().ReverseMap();
            CreateMap<Database.ClubsLeague, Models.ClubsLeague>().ReverseMap();
            CreateMap<Database.Leagues, Models.Leagues>().ReverseMap();

            CreateMap<Database.Referees, Models.Referees>().ReverseMap();
            CreateMap<Database.RefereeMatches, Models.RefereeMatches>().ReverseMap();
            CreateMap<Database.Matches, Models.Matches>().ReverseMap();
            CreateMap<Database.MatchDetails, Models.MatchDetails>().ReverseMap();

            CreateMap<Database.Roles, Models.Roles>().ReverseMap();
            CreateMap<Database.Users, Models.Users>().ReverseMap();
            CreateMap<Database.UsersRoles, Models.UsersRoles>().ReverseMap();

            CreateMap<Database.Seasons, Models.Seasons>().ReverseMap();
            CreateMap<Database.Stadiums, Models.Stadiums>().ReverseMap();

            CreateMap<Database.Contracts, Models.Contracts>().ReverseMap();
            CreateMap<Database.Positions, Models.Positions>().ReverseMap();
            CreateMap<Database.Players, Models.Players>().ReverseMap();
            CreateMap<Database.PlayerPositions, Models.PlayerPositions>().ReverseMap();
        }
    }
}
