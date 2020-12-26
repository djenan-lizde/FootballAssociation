using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    public class ContractsController : BaseCRUDController<Models.Contracts, object, Models.Contracts, Models.Contracts>
    {
        private readonly IData<Contracts> _serviceContract;
        public ContractsController(ICRUDService<Models.Contracts, object, Models.Contracts, Models.Contracts> service,
            IData<Contracts> serviceContract) : base(service) { _serviceContract = serviceContract; }


        [HttpGet("PlayerContracts/{PlayerId}")]
        public List<Contracts> GetContracts(int playerId)
        {
            return _serviceContract.GetByCondition(x => x.PlayerId == playerId).ToList();
        }

        [HttpGet("ClubContracts/{ClubId}")]
        public List<Contracts> GetClubContracts(int ClubId)
        {
            return _serviceContract.GetByCondition(x => x.ClubId == ClubId && x.IsExpired == false).ToList();
        }

        [HttpGet("UnexpiredContracts")]
        public List<Contracts> GetUnexpiredContracts()
        {
            return _serviceContract.GetByCondition(x => x.IsExpired == false).ToList();
        }
    }
}