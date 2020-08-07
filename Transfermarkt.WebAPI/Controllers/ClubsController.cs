using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using Transfermarkt.WebAPI.Services;


namespace Transfermarkt.WebAPI.Controllers
{
    public class ClubsController : BaseCRUDController<Models.Clubs, ClubSearchRequest, Models.Clubs, Models.Clubs>
    {
        private readonly IData<Database.Seasons> _serviceSeason;
        private readonly IData<Database.ClubsLeague> _serviceClubLeague;
        public ClubsController(ICRUDService<Models.Clubs, ClubSearchRequest, Models.Clubs, Models.Clubs> service
            , IData<Database.Seasons> serviceSeason, IData<Database.ClubsLeague> serviceClubLeague) : base(service)
        {
            _serviceSeason = serviceSeason;
            _serviceClubLeague = serviceClubLeague;
        }

        [HttpPost("ClubLeague")]
        public Database.ClubsLeague AddClubLeague(Database.ClubsLeague clubLeague)
        {
            return _serviceClubLeague.Insert(clubLeague);
        }

        [HttpGet("ClubLeague")]
        public IEnumerable<Database.ClubsLeague> ClubLeagues()
        {
            return _serviceClubLeague.Get().AsEnumerable();
        }

        //get clubs in league
        [HttpGet("ClubsInLeague/{LeagueId}")]
        public List<Database.ClubsLeague> ClubLeaguesCondition(int LeagueId)
        {
            var lastSeason = LastSeason();
            if (lastSeason == null)
            {
                return _serviceClubLeague.GetByCondition(x => x.LeagueId == LeagueId).ToList();
            }
            return _serviceClubLeague.GetByCondition(x => x.LeagueId == LeagueId
            && x.SeasonId == lastSeason.Id).ToList();
        }

        //vezano za meceve
        [HttpGet("ClubLeague/{ClubLeagueId}")]
        public Database.ClubsLeague GetClubLeague(int clubLeagueId)
        {
            return _serviceClubLeague.GetTByCondition(x => x.Id == clubLeagueId);
        }

        //get clubs in season
        [HttpGet("ClubsInSeason/{SeasonId}")]
        public List<Database.ClubsLeague> GetClubsInSeason(int seasonId)
        {
            return _serviceClubLeague.GetByCondition(x => x.SeasonId == seasonId).ToList();
        }

        [HttpGet("ClubPoints/{ClubId}")]
        public Database.ClubsLeague GetClubPoints(int clubId)
        {
            var lastSeason = LastSeason();
            if (lastSeason == null)
            {
                throw new ArgumentNullException();
            }
            return _serviceClubLeague.GetTByCondition(x => x.ClubId == clubId && x.SeasonId == lastSeason.Id);
        }

        [HttpPut("ClubPoints")]
        public Database.ClubsLeague UpdatePoints(Database.ClubsLeague clubLeague)
        {
            return _serviceClubLeague.Update(clubLeague);
        }

        [HttpGet("Season")]
        public Database.Seasons LastSeason()
        {
            var list = _serviceSeason.Get();
            return list.LastOrDefault();
        }
    }
}