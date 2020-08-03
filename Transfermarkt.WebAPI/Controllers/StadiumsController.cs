using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumsController : BaseCRUDController<Models.Stadiums, object, Models.Stadiums, Models.Stadiums>
    {
        private readonly IData<Stadiums> _serviceStadium;
        private readonly IMapper _mapper;
        public StadiumsController(ICRUDService<Models.Stadiums, object, Models.Stadiums, Models.Stadiums> service,
            IData<Stadiums> serviceStadium, IMapper mapper) : base(service)
        {
            _serviceStadium = serviceStadium;
            _mapper = mapper;
        }

        [HttpGet("HomeStadium/{ClubId}")]
        public Stadiums GetStadium(int clubId)
        {
            var homeClubStadium = _serviceStadium.GetTByCondition(x => x.ClubId == clubId);

            if (homeClubStadium == null)
            {
                throw new ArgumentNullException();
            }

            return _mapper.Map<Stadiums>(homeClubStadium);
        }
    }
}