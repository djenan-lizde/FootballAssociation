using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transfermarkt.Models;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    public class RefereeController : BaseCRUDController<Models.Referees, object, Models.Referees, Models.Referees>
    {
        public RefereeController(ICRUDService<Referees, object, Referees, Referees> service) : base(service) { }
    }
}