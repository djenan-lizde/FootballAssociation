using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Transfermarkt.Models.Requests;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : BaseController<Players>
    {
        private readonly IData<Positions> _servicePosition;
        private readonly IData<PlayerPositions> _servicePlayerPosition;
        private readonly IData<Players> _servicePlayer;

        public PlayersController(IData<Players> service, IData<Positions> servicePosition,
            IData<PlayerPositions> servicePlayerPosition,
            IData<Players> servicePlayer) : base(service)
        {
            _servicePosition = servicePosition;
            _servicePlayer = servicePlayer;
            _servicePlayerPosition = servicePlayerPosition;
        }

        [HttpGet("Positions")]
        public List<Positions> GetPositions()
        {
            return _servicePosition.Get();
        }

        [HttpPost("InsertPlayerPosition")]
        public PlayerPositions InsertPlayerPosition(PlayerPositions playerPosition)
        {
            return _servicePlayerPosition.Insert(playerPosition);
        }

        [HttpGet("UnsignedPlayers")]
        public List<Players> GetUnsignedPlayers()
        {
            return _servicePlayer.GetByCondition(x => x.IsSigned == false).ToList();
        }

        [HttpGet("PlayerSearch")]
        public List<Players> SearchPlayer([FromQuery]PlayerSearchRequest request)
        {
            if (string.IsNullOrEmpty(request.FirstName.ToLower()) 
                && string.IsNullOrEmpty(request.LastName.ToLower()))
            {
                return _servicePlayer.Get().ToList();
            }
            var query = _servicePlayer.GetByCondition(x => x.FirstName.ToLower()
            .StartsWith(request.FirstName) || x.LastName.ToLower().StartsWith(request.LastName)).ToList();

            return query;

            //if (request.IsSigned)
            //{
            //    return query.Where(x => x.IsSigned == true).ToList();
            //}

            //return query.Where(x => x.IsSigned == false).ToList();
        }
    }
}