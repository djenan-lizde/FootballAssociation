using System.Collections.Generic;
using System.Linq;
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

        public MatchesController(IData<Match> service, IData<RefereeMatch> serviceRefereeMatch,
            IData<MatchDetail> serviceMatchDetail) : base(service)
        {
            _serviceRefereeMatch = serviceRefereeMatch;
            _serviceMatchDetail = serviceMatchDetail;
        }

        [HttpGet("MatchDetail/{MatchId}")]
        public List<MatchDetail> GetMatchDetails(int matchId)
        {
            return _serviceMatchDetail.GetByCondition(x => x.MatchId == matchId).ToList();
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