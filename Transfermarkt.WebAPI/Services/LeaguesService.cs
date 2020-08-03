using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transfermarkt.WebAPI.Database;

namespace Transfermarkt.WebAPI.Services
{
    public class LeaguesService : BaseCRUDService<Models.Leagues, object, Database.Leagues, Models.Leagues, Models.Leagues>,
        IService<Models.Leagues, object>
    {
        public LeaguesService(FootballAssociationDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
