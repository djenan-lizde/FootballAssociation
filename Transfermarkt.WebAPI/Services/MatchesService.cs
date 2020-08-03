using AutoMapper;
using Transfermarkt.WebAPI.Database;

namespace Transfermarkt.WebAPI.Services
{
    public class MatchesService : BaseCRUDService<Models.Matches, object, Database.Matches, Models.Matches, Models.Matches>,
        IService<Models.Matches, object>
    {
        public MatchesService(FootballAssociationDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
