using Microsoft.AspNetCore.Mvc;
using Transfermarkt.Models;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumsController : BaseController<Stadium>
    {
        private readonly IData<Stadium> _serviceStadium;

        public StadiumsController(IData<Stadium> serviceStadium, IData<Stadium> service) : base(service)
        {
            _serviceStadium = serviceStadium;
        }
        [HttpGet("HomeStadium/{ClubId}")]
        public Stadium GetStadium(int clubId)
        {
            return _serviceStadium.GetTByCondition(x => x.ClubId == clubId);
        }
    }
}