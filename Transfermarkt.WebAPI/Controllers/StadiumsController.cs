using Microsoft.AspNetCore.Mvc;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumsController : BaseController<Stadiums>
    {
        private readonly IData<Stadiums> _serviceStadium;

        public StadiumsController(IData<Stadiums> serviceStadium, IData<Stadiums> service) : base(service)
        {
            _serviceStadium = serviceStadium;
        }
        [HttpGet("HomeStadium/{ClubId}")]
        public Stadiums GetStadium(int clubId)
        {
            return _serviceStadium.GetTByCondition(x => x.ClubId == clubId);
        }
    }
}