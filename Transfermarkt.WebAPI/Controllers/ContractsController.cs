using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : BaseController<Contracts>
    {
        private readonly IData<Contracts> _serviceContract;
        public ContractsController(IData<Contracts> serviceContract, IData<Contracts> service) : base(service)
        {
            _serviceContract = serviceContract;
        }

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