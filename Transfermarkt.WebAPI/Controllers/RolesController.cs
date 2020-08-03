using Microsoft.AspNetCore.Mvc;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController<Models.Roles, object>
    {
        public RolesController(IService<Models.Roles, object> service) : base(service) { }
    }
}