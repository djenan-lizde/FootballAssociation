using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Transfermarkt.Models.Requests;
using Transfermarkt.WebAPI.Database;

namespace Transfermarkt.WebAPI.Services
{
    public class ClubsService : BaseCRUDService<Models.Clubs, ClubSearchRequest, Database.Clubs, Models.Clubs, Models.Clubs>,
        IService<Models.Clubs, ClubSearchRequest>
    {
        public ClubsService(FootballAssociationDbContext context, IMapper mapper) : base(context, mapper) { }

        public override List<Models.Clubs> Get(ClubSearchRequest search)
        {
            var query = _context.Set<Database.Clubs>().AsQueryable();

            if (string.IsNullOrEmpty(search.Name))
            {
                return _mapper.Map<List<Models.Clubs>>(query);
            }

            query = query.Where(x => x.Name.ToLower().StartsWith(search.Name));

            var list = query.ToList();

            return _mapper.Map<List<Models.Clubs>>(list);
        }
    }
}
