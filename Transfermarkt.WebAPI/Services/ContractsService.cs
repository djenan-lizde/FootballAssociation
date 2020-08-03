using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transfermarkt.WebAPI.Database;

namespace Transfermarkt.WebAPI.Services
{
    public class ContractsService : BaseCRUDService<Models.Contracts, object, Database.Contracts, Models.Contracts, Models.Contracts>,
        IService<Models.Contracts, object>
    {
        public ContractsService(FootballAssociationDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
