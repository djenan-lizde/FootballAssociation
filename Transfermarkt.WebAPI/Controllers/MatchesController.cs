﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Transfermarkt.Models.Requests;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    public class MatchesController : BaseCRUDController<Models.Matches, object, Models.Matches, Models.Matches>
    {
        private readonly IData<RefereeMatches> _serviceRefereeMatch;
        private readonly IData<MatchDetails> _serviceMatchDetail;
        private readonly IData<Seasons> _serviceSeason;
        private readonly IData<Matches> _serviceMatch;
        private readonly IData<Clubs> _serviceClub;
        private readonly IData<ClubsLeague> _serviceClubLeague;

        public MatchesController(ICRUDService<Models.Matches, object, Models.Matches, Models.Matches> service,
             IData<MatchDetails> serviceMatchDetail, IData<RefereeMatches> serviceRefereeMatch,
            IData<Seasons> serviceSeason, IData<Matches> serviceMatch,
            IData<Clubs> serviceClub, IData<ClubsLeague> serviceClubLeague) : base(service)
        {
            _serviceMatchDetail = serviceMatchDetail;
            _serviceRefereeMatch = serviceRefereeMatch;
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
            if (lastSeason != null)
            {
                var clubs = _serviceClubLeague.GetByCondition(x => x.LeagueId == leagueId && x.SeasonId == lastSeason.Id);

                List<ClubScoredGoals> clubScoredGoals = new List<ClubScoredGoals>();

                foreach (var item in clubs)
                {
                    var club = _serviceClub.GetById(item.ClubId);
                    if (club != null)
                    {
                        var clubGoalDetails = _serviceMatchDetail.GetByCondition(x => x.ClubId == item.ClubId && x.ActionType == 3).Count();

                        var clubGoals = new ClubScoredGoals
                        {
                            ClubId = item.ClubId,
                            ClubName = club.Name,
                            NumberOfScoredGoals = clubGoalDetails
                        };
                        clubScoredGoals.Add(clubGoals);
                    }
                }

                for (int i = 1; i < clubScoredGoals.OrderByDescending(x => x.NumberOfScoredGoals).Count(); i++)
                {
                    var match = _serviceMatch.GetTByCondition(x => (x.HomeClubId == clubScoredGoals[i].ClubId 
                            || x.AwayClubId == clubScoredGoals[i - 1].ClubId) && x.IsFinished == false);
                    if (match != null)
                        return match;
                }
            }
            return null;
        }

        private Seasons LastSeason()
        {
            var seasons = _serviceSeason.Get();
            return seasons.LastOrDefault();
        }
    }
}