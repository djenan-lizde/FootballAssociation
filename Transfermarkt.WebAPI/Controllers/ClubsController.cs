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
    public class ClubsController : BaseController<Club>
    {
        private readonly IData<ClubLeague> _serviceClubLeague;
        private readonly IData<Season> _serviceSeason;
        private readonly IData<Club> _serviceClub;

        public ClubsController(IData<Club> service, IData<ClubLeague> serviceClubLeague,
            IData<Club> serviceClub,
            IData<Season> serviceSeason) : base(service)
        {
            _serviceClubLeague = serviceClubLeague;
            _serviceSeason = serviceSeason;
            _serviceClub = serviceClub;
        }


        [HttpPost("ClubLeague")]
        public ClubLeague AddClubLeague(ClubLeague clubLeague)
        {
            return _serviceClubLeague.Insert(clubLeague);
        }

        [HttpGet("ClubLeague")]
        public IEnumerable<ClubLeague> ClubLeagues()
        {
            return _serviceClubLeague.Get().AsEnumerable();
        }

        //vezano za meceve
        [HttpGet("ClubLeague/{ClubLeagueId}")]
        public ClubLeague GetClubLeague(int clubLeagueId)
        {
            return _serviceClubLeague.GetTByCondition(x => x.Id == clubLeagueId);
        }

        //get klubova u sezoni
        [HttpGet("ClubsInSeason")]
        public List<ClubLeague> GetClubsInSeason(int seasonId)
        {
            return _serviceClubLeague.GetByCondition(x => x.SeasonId == seasonId).ToList();
        }

        //get klubova u nekoj ligi
        [HttpGet("ClubsInLeague/{LeagueId}")]
        public List<ClubLeague> ClubLeaguesCondition(int LeagueId)
        {
            var list = _serviceSeason.Get();
            var lastSeason = list.LastOrDefault();
            return _serviceClubLeague.GetByCondition(x => x.LeagueId == LeagueId
            && x.SeasonId == lastSeason.Id).ToList();
        }


        [HttpGet("ClubPoints/{ClubId}")]
        public ClubLeague GetClubPoints(int clubId)
        {
            return _serviceClubLeague.GetTByCondition(x => x.ClubId == clubId);
        }

        [HttpPut("ClubPoints")]
        public ClubLeague UpdatePoints(ClubLeague clubLeague)
        {
            return _serviceClubLeague.Update(clubLeague);
        }
        
        
        
        [HttpGet("Season")]
        public Season LastSeason()
        {
            var list = _serviceSeason.Get();
            var lastSeason = list.LastOrDefault();

            return lastSeason;
        }

        [HttpGet("AllSeasons")]
        public List<Season> GetSeasons()
        {
            return _serviceSeason.Get();
        }

        [HttpPost("NewSeason")]
        public Season AddSeason(Season season)
        {
            return _serviceSeason.Insert(season);
        }

        [HttpGet("ClubSearch")]
        public List<Club> SearchClub([FromQuery]ClubSearchRequest request)
        {
            if (string.IsNullOrEmpty(request.Name.ToLower()))
            {
                return _serviceClub.Get().ToList();
            }
            var query = _serviceClub.GetByCondition(x => x.Name.ToLower().StartsWith(request.Name)).ToList();

            return query;
        }
    }
}