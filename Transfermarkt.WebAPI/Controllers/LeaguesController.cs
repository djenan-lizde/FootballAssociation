using Microsoft.AspNetCore.Mvc;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : BaseController<Leagues>
    {
        public LeaguesController(IData<Leagues> service) : base(service) { }
    }
}