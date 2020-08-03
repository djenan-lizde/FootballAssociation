using Microsoft.AspNetCore.Mvc;
using Transfermarkt.Models;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : BaseCRUDController<Models.Leagues, object, Models.Leagues, Models.Leagues>
    {
        public LeaguesController(ICRUDService<Leagues, object, Leagues, Leagues> service) : base(service){}
    }
}