using Microsoft.AspNetCore.Mvc;
using Transfermarkt.Models;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : BaseController<City> 
    {
        public CitiesController(IData<City> service):base(service){}
    }
}