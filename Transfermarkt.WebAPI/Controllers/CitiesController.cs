using Microsoft.AspNetCore.Mvc;
using Transfermarkt.Models;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : BaseCRUDController<Models.Cities, object, Models.Cities, Models.Cities>
    {
        public CitiesController(ICRUDService<Cities, object, Cities, Cities> service) : base(service) { }
    }
}