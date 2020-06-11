using Microsoft.AspNetCore.Mvc;
using Transfermarkt.Models;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : BaseController<League>
    {
        public LeaguesController(IData<League> service) : base(service) { }
    }
}