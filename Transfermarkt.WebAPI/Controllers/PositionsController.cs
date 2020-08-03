using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    public class PositionsController : BaseController<Models.Positions, object>
    {
        public PositionsController(IService<Models.Positions, object> service) : base(service) { }
    }
}
