﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;

namespace Transfermarkt.MobileApp.ViewModels
{
    public class PlayerDetailsViewModel
    {
        private readonly APIService _apiServiceContracts = new APIService("Contracts");
        private readonly APIService _apiServiceClubs = new APIService("Clubs");
        private readonly APIService _apiServiceMatches = new APIService("Matches");

        public PlayerDetailsViewModel() { }

        public PlayersClub Player { get; set; }

        public ObservableCollection<PlayerContractsClubs> Contracts { get; set; } = new ObservableCollection<PlayerContractsClubs>();

        public async Task PlayerContracts()
        {
            var contracts = await _apiServiceContracts.GetById<List<Contract>>(Player.Id, "PlayerContracts");
            foreach (var item in contracts)
            {
                var club = await _apiServiceClubs.GetById<Club>(item.ClubId);
                var playerClub = new PlayerContractsClubs
                {
                    ClubName = club.Name,
                    ExpirationDate = item.ExpirationDate,
                    Id = item.PlayerId,
                    RedemptionClause = item.RedemptionClause,
                    SignedDate = item.SignedDate,
                    Logo = club.Logo
                };
                Contracts.Add(playerClub);
            }
        }
    }
}
