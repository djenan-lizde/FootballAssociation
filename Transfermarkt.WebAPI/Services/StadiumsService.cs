using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transfermarkt.WebAPI.Database;

namespace Transfermarkt.WebAPI.Services
{
    public class StadiumsService : BaseCRUDService<Models.Stadiums, object, Database.Stadiums, Models.Stadiums, Models.Stadiums>,
        IService<Models.Stadiums, object>
    {
        public StadiumsService(FootballAssociationDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
