using AutoMapper;
using Transfermarkt.WebAPI.Database;

namespace Transfermarkt.WebAPI.Services
{
    public class CitiesService : BaseCRUDService<Models.Cities, object, Database.Cities, Models.Cities, Models.Cities>,
        IService<Models.Cities, object>
    {
        public CitiesService(FootballAssociationDbContext context, IMapper mapper) : base(context, mapper) { }
}
}
