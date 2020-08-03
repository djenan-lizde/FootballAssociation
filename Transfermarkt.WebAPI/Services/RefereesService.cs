using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transfermarkt.WebAPI.Database;

namespace Transfermarkt.WebAPI.Services
{
    public class RefereesService : BaseCRUDService<Models.Referees, object, Database.Referees, Models.Referees, Models.Referees>,
        IService<Models.Referees, object>
    {
        public RefereesService(FootballAssociationDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
