using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Transfermarkt.Models.Enums;
using Transfermarkt.Models.Requests;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{

    public class ReccomendedMatch
    {
        public int ClubId { get; set; }
        public int scoredGoals { get; set; }
        public int clubPoints { get; set; }
    }

    public class MatchesController : BaseCRUDController<Models.Matches, object, Models.Matches, Models.Matches>
    {
        private readonly IData<RefereeMatches> _serviceRefereeMatch;
        private readonly IData<MatchDetails> _serviceMatchDetail;
        private readonly IData<Seasons> _serviceSeason;
        private readonly IData<Matches> _serviceMatch;
        private readonly IData<Clubs> _serviceClub;
        private readonly IData<ClubsLeague> _serviceClubLeague;
        private readonly FootballAssociationDbContext _dbContext;

        public MatchesController(ICRUDService<Models.Matches, object, Models.Matches, Models.Matches> service,
             IData<MatchDetails> serviceMatchDetail, IData<RefereeMatches> serviceRefereeMatch,
            IData<Seasons> serviceSeason, IData<Matches> serviceMatch,
            IData<Clubs> serviceClub, IData<ClubsLeague> serviceClubLeague, FootballAssociationDbContext context) : base(service)
        {
            _serviceMatchDetail = serviceMatchDetail;
            _serviceRefereeMatch = serviceRefereeMatch;
            _serviceMatch = serviceMatch;
            _serviceSeason = serviceSeason;
            _serviceClub = serviceClub;
            _serviceClubLeague = serviceClubLeague;
            _dbContext = context;
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
            var season = LastSeason();
            return _serviceMatch.GetByCondition(x => x.LeagueId == leagueId && x.SeasonId == season.Id).ToList();
        }

        [HttpGet("SeasonMatches/{seasonId}")]
        public List<Matches> GetMatchesSeason(int seasonId)
        {
            return _serviceMatch.GetByCondition(x => x.SeasonId == seasonId).ToList();
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
            
            if (lastSeason == null)
            {
                return null;
            }

            var clubs = _dbContext.ClubsLeague
                .Where(cb => cb.LeagueId == leagueId && cb.SeasonId == lastSeason.Id)
                .Select(cb => new ClubPointsGoals {
                    Points = cb.Points,
                    ClubId = cb.ClubId,
                    ClubName = _dbContext.Clubs.Where(c => c.Id == cb.ClubId).FirstOrDefault().Name,
                    NumberOfScoredGoals = _dbContext.MatchDetails
                                    .Where(md => 
                                        md.Match.LeagueId == leagueId && md.Match.SeasonId == lastSeason.Id &&
                                        (md.Match.HomeClubId == cb.ClubId || md.Match.AwayClubId == cb.ClubId) 
                                        && md.Match.IsFinished == true && md.ActionType == (int)Enums.ActionType.Goal
                                    )
                                    .Count()
                })
                .OrderByDescending(x => x.NumberOfScoredGoals)
                .OrderByDescending(x => x.Points)
                .ToList();

            if (clubs.Count() == 0)
            {
                return null;
            }

            var bestClub = clubs.First();
            var secondBestClub = clubs[1];

            Matches match = _dbContext.Matches.Where(
                m => 
                (
                    (m.AwayClubId == bestClub.ClubId && m.HomeClubId == secondBestClub.ClubId) 
                    || (m.AwayClubId == secondBestClub.ClubId && m.HomeClubId == bestClub.ClubId)
                )
                    && m.IsFinished == false)
                .FirstOrDefault();

            return match;
        }

        private Seasons LastSeason()
        {
            var seasons = _serviceSeason.Get();
            return seasons.LastOrDefault();
        }
    }
}