using Microsoft.AspNetCore.Mvc;
using Transfermarkt.Models;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseController<Role>
    {
        public RolesController(IData<Role> service) : base(service) { }
    }
}