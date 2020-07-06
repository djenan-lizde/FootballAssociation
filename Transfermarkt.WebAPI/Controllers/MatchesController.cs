using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
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
        private readonly IData<Club> _serviceClub;
        private readonly IData<ClubLeague> _serviceClubLeague;


        public MatchesController(IData<Match> service, IData<RefereeMatch> serviceRefereeMatch,
            IData<MatchDetail> serviceMatchDetail, IData<Season> serviceSeason, IData<Match> serviceMatch,
            IData<Club> serviceClub, IData<ClubLeague> serviceClubLeague) : base(service)
        {
            _serviceRefereeMatch = serviceRefereeMatch;
            _serviceMatchDetail = serviceMatchDetail;
            _serviceMatch = serviceMatch;
            _serviceSeason = serviceSeason;
            _serviceClub = serviceClub;
            _serviceClubLeague = serviceClubLeague;
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
            return _serviceMatch.GetByCondition(x => x.LeagueId == leagueId && x.SeasonId == lastSeason.Id).ToList();
        }

        [HttpGet("SeasonMatches/{seasonId}")]
        public List<Match> GetMatchesSeason(int seasonId)
        {
            var list = _serviceSeason.Get();
            var lastSeason = list.LastOrDefault();
            return _serviceMatch.GetByCondition(x => x.SeasonId == lastSeason.Id).ToList();
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

        [HttpGet("PlayerMatchDetails/{playerId}")]
        public List<MatchDetail> GetPlayerMatchDetails(int playerId)
        {
            return _serviceMatchDetail.GetByCondition(x => x.PlayerId == playerId).ToList();
        }

        [HttpGet("RecommendMatch/{leagueId}")]
        public Match GetRecommendedMatch(int leagueId)
        {
            var seasons = _serviceSeason.Get();
            var lastSeason = seasons.LastOrDefault();

            var clubs = _serviceClubLeague.GetByCondition(x => x.LeagueId == leagueId && x.SeasonId == lastSeason.Id);

            List<ClubScoredGoals> clubScoredGoals = new List<ClubScoredGoals>();

            foreach (var item in clubs)
            {
                var club = _serviceClub.GetById(item.ClubId);

                var clubGoalDetails = _serviceMatchDetail.GetByCondition(x => x.ClubId == item.ClubId && x.ActionType == 3).Count();

                var clubGoals = new ClubScoredGoals
                {
                    ClubId = item.ClubId,
                    ClubName = club.Name,
                    NumberOfScoredGoals = clubGoalDetails
                };
                clubScoredGoals.Add(clubGoals);
            }

            for (int i = 1; i < clubScoredGoals.Count(); i++)
            {
                var match = _serviceMatch.GetTByCondition(x => x.HomeClubId == clubScoredGoals[i].ClubId || x.AwayClubId == clubScoredGoals[i - 1].ClubId);
                if (match != null)
                    return match;
            }

            return null;
        }
    }
}