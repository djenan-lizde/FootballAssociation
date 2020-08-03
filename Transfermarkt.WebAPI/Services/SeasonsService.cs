using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transfermarkt.WebAPI.Database;

namespace Transfermarkt.WebAPI.Services
{
    public class SeasonsService: BaseCRUDService<Models.Seasons, object, Database.Seasons, Models.Seasons, Models.Seasons>,
        IService<Models.Seasons, object>
    {
        public SeasonsService(FootballAssociationDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
