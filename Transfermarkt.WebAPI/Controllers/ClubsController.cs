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
    public class ClubsController : BaseController<Clubs>
    {
        private readonly IData<ClubsLeague> _serviceClubLeague;
        private readonly IData<Seasons> _serviceSeason;
        private readonly IData<Clubs> _serviceClub;

        public ClubsController(IData<Clubs> service, IData<ClubsLeague> serviceClubLeague,
            IData<Clubs> serviceClub,
            IData<Seasons> serviceSeason) : base(service)
        {
            _serviceClubLeague = serviceClubLeague;
            _serviceSeason = serviceSeason;
            _serviceClub = serviceClub;
        }


        [HttpPost("ClubLeague")]
        public ClubsLeague AddClubLeague(ClubsLeague clubLeague)
        {
            return _serviceClubLeague.Insert(clubLeague);
        }

        [HttpGet("ClubLeague")]
        public IEnumerable<ClubsLeague> ClubLeagues()
        {
            return _serviceClubLeague.Get().AsEnumerable();
        }

        //vezano za meceve
        [HttpGet("ClubLeague/{ClubLeagueId}")]
        public ClubsLeague GetClubLeague(int clubLeagueId)
        {
            return _serviceClubLeague.GetTByCondition(x => x.Id == clubLeagueId);
        }

        //get klubova u sezoni
        [HttpGet("ClubsInSeason")]
        public List<ClubsLeague> GetClubsInSeason(int seasonId)
        {
            return _serviceClubLeague.GetByCondition(x => x.SeasonId == seasonId).ToList();
        }

        //get klubova u nekoj ligi
        [HttpGet("ClubsInLeague/{LeagueId}")]
        public List<ClubsLeague> ClubLeaguesCondition(int LeagueId)
        {
            var list = _serviceSeason.Get();
            var lastSeason = list.LastOrDefault();
            return _serviceClubLeague.GetByCondition(x => x.LeagueId == LeagueId
            && x.SeasonId == lastSeason.Id).ToList();
        }


        [HttpGet("ClubPoints/{ClubId}")]
        public ClubsLeague GetClubPoints(int clubId)
        {
            return _serviceClubLeague.GetTByCondition(x => x.ClubId == clubId);
        }

        [HttpPut("ClubPoints")]
        public ClubsLeague UpdatePoints(ClubsLeague clubLeague)
        {
            return _serviceClubLeague.Update(clubLeague);
        }
        
        
        
        [HttpGet("Season")]
        public Seasons LastSeason()
        {
            var list = _serviceSeason.Get();
            var lastSeason = list.LastOrDefault();

            return lastSeason;
        }

        [HttpGet("AllSeasons")]
        public List<Seasons> GetSeasons()
        {
            return _serviceSeason.Get();
        }

        [HttpPost("NewSeason")]
        public Seasons AddSeason(Seasons season)
        {
            return _serviceSeason.Insert(season);
        }

        [HttpGet("ClubSearch")]
        public List<Clubs> SearchClub([FromQuery]ClubSearchRequest request)
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