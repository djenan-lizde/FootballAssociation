using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : BaseController<Player>
    {
        private readonly IData<Position> _servicePosition;
        private readonly IData<PlayerPosition> _servicePlayerPosition;
        private readonly IData<Player> _servicePlayer;

        public PlayersController(IData<Player> service, IData<Position> servicePosition,
            IData<PlayerPosition> servicePlayerPosition,
            IData<Player> servicePlayer) : base(service)
        {
            _servicePosition = servicePosition;
            _servicePlayer = servicePlayer;
            _servicePlayerPosition = servicePlayerPosition;
        }

        [HttpGet("Positions")]
        public List<Position> GetPositions()
        {
            return _servicePosition.Get();
        }

        [HttpPost("InsertPlayerPosition")]
        public PlayerPosition InsertPlayerPosition(PlayerPosition playerPosition)
        {
            return _servicePlayerPosition.Insert(playerPosition);
        }

        [HttpGet("UnsignedPlayers")]
        public List<Player> GetUnsignedPlayers()
        {
            return _servicePlayer.GetByCondition(x => x.IsSigned == false).ToList();
        }

        [HttpGet("PlayerSearch")]
        public List<Player> SearchPlayer([FromQuery]PlayerSearchRequest request)
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