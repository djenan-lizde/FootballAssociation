using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Transfermarkt.Models.Requests;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : BaseController<Matches>
    {
        private readonly IData<RefereeMatches> _serviceRefereeMatch;
        private readonly IData<MatchDetails> _serviceMatchDetail;
        private readonly IData<Seasons> _serviceSeason;
        private readonly IData<Matches> _serviceMatch;
        private readonly IData<Clubs> _serviceClub;
        private readonly IData<ClubsLeague> _serviceClubLeague;


        public MatchesController(IData<Matches> service, IData<RefereeMatches> serviceRefereeMatch,
            IData<MatchDetails> serviceMatchDetail, IData<Seasons> serviceSeason, IData<Matches> serviceMatch,
            IData<Clubs> serviceClub, IData<ClubsLeague> serviceClubLeague) : base(service)
        {
            _serviceRefereeMatch = serviceRefereeMatch;
            _serviceMatchDetail = serviceMatchDetail;
            _serviceMatch = serviceMatch;
            _serviceSeason = serviceSeason;
            _serviceClub = serviceClub;
            _serviceClubLeague = serviceClubLeague;
        }

        [HttpGet("MatchDetail/{MatchId}")]
        public List<MatchDetails> GetMatchDetails(int matchId)
        {
            return _serviceMatchDetail.GetByCondition(x => x.MatchId == matchId).ToList();
        }

        [HttpGet("ClubSchedule/{clubId}")]
        public List<Matches> GetMatches(int clubId)
        {
            return _serviceMatch.GetByCondition(x => x.HomeClubId == clubId || x.AwayClubId == clubId).ToList();
        }

        [HttpGet("ClubMatches/{leagueId}")]
        public List<Matches> GetClubsInLeague(int leagueId)
        {
            var list = _serviceSeason.Get();
            var lastSeason = list.LastOrDefault();
            return _serviceMatch.GetByCondition(x => x.LeagueId == leagueId && x.SeasonId == lastSeason.Id).ToList();
        }

        [HttpGet("SeasonMatches/{seasonId}")]
        public List<Matches> GetMatchesSeason(int seasonId)
        {
            var list = _serviceSeason.Get();
            var lastSeason = list.LastOrDefault();
            return _serviceMatch.GetByCondition(x => x.SeasonId == lastSeason.Id).ToList();
        }

        [HttpGet("Season")]
        public Seasons LastSeason()
        {
            var list = _serviceSeason.Get();
            var lastSeason = list.LastOrDefault();

            return lastSeason;
        }

        [HttpPost("RefereeMatch")]
        public RefereeMatches AddRefereeMatch(RefereeMatches refereeMatch)
        {
            return _serviceRefereeMatch.Insert(refereeMatch);
        }

        [HttpPost("NewDetailMatch")]
        public MatchDetails AddMatchDetail(MatchDetails matchDetail)
        {
            return _serviceMatchDetail.Insert(matchDetail);
        }

        [HttpGet("PlayerMatchDetails/{playerId}")]
        public List<MatchDetails> GetPlayerMatchDetails(int playerId)
        {
            return _serviceMatchDetail.GetByCondition(x => x.PlayerId == playerId).ToList();
        }

        [HttpGet("RecommendMatch/{leagueId}")]
        public Matches GetRecommendedMatch(int leagueId)
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