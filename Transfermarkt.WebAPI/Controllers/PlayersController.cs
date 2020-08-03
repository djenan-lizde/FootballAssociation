using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Transfermarkt.Models.Requests;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    public class PlayersController : BaseCRUDController<Models.Players, PlayerSearchRequest, Models.Players, Models.Players>
    {
        private readonly IData<PlayerPositions> _servicePlayerPosition;
        private readonly IData<Players> _servicePlayer;

        public PlayersController(ICRUDService<Models.Players, PlayerSearchRequest, Models.Players, Models.Players> service,
            IData<PlayerPositions> servicePlayerPosition, IData<Players> servicePlayer) : base(service) 
        {
            _servicePlayerPosition = servicePlayerPosition;
            _servicePlayer = servicePlayer;
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
    }
}