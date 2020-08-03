using Microsoft.AspNetCore.Mvc;
using Transfermarkt.WebAPI.Services;
using Transfermarkt.Models;

namespace Transfermarkt.WebAPI.Controllers
{
    public class CitiesController : BaseController<Models.Cities, object>
    {
        public CitiesController(IService<Models.Cities, object> service) : base(service){} 
    }
}