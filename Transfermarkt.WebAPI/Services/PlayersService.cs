using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Transfermarkt.Models.Requests;
using Transfermarkt.WebAPI.Database;

namespace Transfermarkt.WebAPI.Services
{
    public class PlayersService : BaseCRUDService<Models.Players, PlayerSearchRequest, Database.Players, Models.Players, Models.Players>,
        IService<Models.Players, PlayerSearchRequest>
    {
        public PlayersService(FootballAssociationDbContext context, IMapper mapper) : base(context, mapper) { }

        public override List<Models.Players> Get(PlayerSearchRequest search)
        {
            var query = _context.Set<Players>().AsQueryable();

            if (string.IsNullOrEmpty(search.FirstName)
                && string.IsNullOrEmpty(search.LastName))
            {
                return _mapper.Map<List<Models.Players>>(query);
            }
            query = query.Where(x => x.FirstName.ToLower()
            .StartsWith(search.FirstName) || x.LastName.ToLower().StartsWith(search.LastName));

            var list = query.ToList();

            return _mapper.Map<List<Models.Players>>(list);
        }
    }
}
