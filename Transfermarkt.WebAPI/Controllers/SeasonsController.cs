using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    public class SeasonsController : BaseCRUDController<Models.Seasons, object, Models.Seasons, Models.Seasons>
    {
        public SeasonsController(ICRUDService<Models.Seasons, object, Models.Seasons, Models.Seasons> service) : base(service){}
    }
}
