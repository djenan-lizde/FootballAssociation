using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Transfermarkt.Models;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : BaseController<Match>
    {
        private readonly IData<RefereeMatch> _serviceRefereeMatch;
        private readonly IData<MatchDetail> _serviceMatchDetail;
        private readonly IData<Season> _serviceSeason;
        private readonly IData<Match> _serviceMatch;

        public MatchesController(IData<Match> service, IData<RefereeMatch> serviceRefereeMatch,
            IData<MatchDetail> serviceMatchDetail, IData<Season> serviceSeason, IData<Match> serviceMatch) : base(service)
        {
            _serviceRefereeMatch = serviceRefereeMatch;
            _serviceMatchDetail = serviceMatchDetail;
            _serviceMatch = serviceMatch;
            _serviceSeason = serviceSeason;
        }

        [HttpGet("MatchDetail/{MatchId}")]
        public List<MatchDetail> GetMatchDetails(int matchId)
        {
            return _serviceMatchDetail.GetByCondition(x => x.MatchId == matchId).ToList();
        }

        [HttpGet("ClubSchedule/{clubId}")]
        public List<Match> GetMatches(int clubId)
        {
            return _serviceMatch.GetByCondition(x => x.HomeClubId == clubId || x.AwayClubId == clubId).ToList();
        }

        [HttpGet("ClubMatches/{leagueId}")]
        public List<Match> GetClubsInLeague(int leagueId)
        {
            var list = _serviceSeason.Get();
            var lastSeason = list.LastOrDefault();
            return _serviceMatch.GetByCondition(x => x.LeagueId == leagueId && x.SeasonId==lastSeason.Id).ToList();
        }

        [HttpGet("Season")]
        public Season LastSeason()
        {
            var list = _serviceSeason.Get();
            var lastSeason = list.LastOrDefault();

            return lastSeason;
        }

        [HttpPost("RefereeMatch")]
        public RefereeMatch AddRefereeMatch(RefereeMatch refereeMatch)
        {
            return _serviceRefereeMatch.Insert(refereeMatch);
        }

        [HttpPost("NewDetailMatch")]
        public MatchDetail AddMatchDetail(MatchDetail matchDetail)
        {
            return _serviceMatchDetail.Insert(matchDetail);
        }
    }
}