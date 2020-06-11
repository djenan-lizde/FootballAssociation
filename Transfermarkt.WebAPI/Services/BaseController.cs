using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        private readonly IData<T> _dataService;
        public BaseController(IData<T> dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public List<T> Get()
        {
            return _dataService.Get();
        }
        [HttpGet("{id}")]
        public T GetById(int id)
        {
            return _dataService.GetById(id);
        }
        [HttpPost]
        public T Insert(T model)
        {
            return _dataService.Insert(model);
        }

        [HttpPut]
        public T Update(T model)
        {
            return _dataService.Update(model);
        }
    }
}