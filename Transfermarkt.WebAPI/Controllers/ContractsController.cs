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
    public class ContractsController : BaseController<Models.Contract>
    {
        private readonly IData<Models.Contract> _serviceContract;
        public ContractsController(IData<Models.Contract> serviceContract, IData<Models.Contract> service) : base(service)
        {
            _serviceContract = serviceContract;
        }

        [HttpGet("PlayerContracts/{PlayerId}")]
        public List<Models.Contract> GetContracts(int playerId)
        {
            return _serviceContract.GetByCondition(x => x.PlayerId == playerId).ToList();
        }
        [HttpGet("ClubContracts/{ClubId}")]
        public List<Models.Contract> GetClubContracts(int ClubId)
        {
            return _serviceContract.GetByCondition(x => x.ClubId == ClubId && x.IsExpired == false).ToList();
        }
        [HttpGet("UnexpiredContracts")]
        public List<Models.Contract> GetUnexpiredContracts()
        {
            return _serviceContract.GetByCondition(x => x.IsExpired == false).ToList();
        }
    }
}