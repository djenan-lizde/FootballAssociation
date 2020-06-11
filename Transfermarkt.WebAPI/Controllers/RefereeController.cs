using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transfermarkt.Models;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefereeController : BaseController<Referee>
    {
        public RefereeController(IData<Referee> service) : base(service) { }
    }
}