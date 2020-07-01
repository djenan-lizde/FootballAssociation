﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Extensions;
using static Transfermarkt.Models.Enums.Enums;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmNewMatchEvent : Form
    {
        private readonly APIService _aPIServiceMatches = new APIService("Matches");
        private readonly APIService _aPIServiceClubs = new APIService("Clubs");
        private readonly APIService _aPIServiceContracts = new APIService("Contracts");
        private readonly APIService _aPIServicePlayers = new APIService("Players");

        public int Id { get; set; }
        public FrmNewMatchEvent(int id)
        {
            InitializeComponent();
            Id = id;
        }
        private async void FrmNewMatchEvent_Load(object sender, EventArgs e)
        {
            var list = Globals.ToPairList<ActionType>(typeof(ActionType));
            CmbEvent.DataSource = list.ToList();
            CmbEvent.DisplayMember = "Value";
            CmbEvent.ValueMember = "Key";

            var match = await _aPIServiceMatches.GetById<Match>(Id);

            var homeClubLeague = await _aPIServiceClubs.GetById<ClubLeague>(match.HomeClubId, "ClubLeague");
            var awayClubLeague = await _aPIServiceClubs.GetById<ClubLeague>(match.AwayClubId, "ClubLeague");
            if (homeClubLeague == null || awayClubLeague == null)
            {
                return;
            }

            var homeClub = await _aPIServiceClubs.GetById<Club>(homeClubLeague.ClubId);
            var awayClub = await _aPIServiceClubs.GetById<Club>(awayClubLeague.ClubId);

            //clubs for drop down list
            List<Club> clubs = new List<Club>
            {
                homeClub,
                awayClub
            };
            CmbClubs.DataSource = clubs.ToList();
            CmbClubs.DisplayMember = "Name";
            CmbClubs.ValueMember = "Id";
        }
        private async void CmbClubs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbPlayers.SelectedItem = null;
            CmbPlayers.SelectedText = "--select--";
            List<Player> players = new List<Player>();

            var clubId = int.Parse(CmbClubs.SelectedValue.ToString());

            var playerContract = await _aPIServiceContracts.GetById<List<Contract>>(clubId, "ClubContracts");

            foreach (var item in playerContract)
            {
                var player = await _aPIServicePlayers.GetById<Player>(item.PlayerId);
                if (player == null) continue;
                players.Add(player);
            }

            CmbPlayers.DataSource = players.ToList();
            CmbPlayers.DisplayMember = "FirstName";
            CmbPlayers.ValueMember = "Id";
        }
        private async void BtnSaveDetail_Click(object sender, EventArgs e)
        {
            if (int.Parse(TxtMinute.Text) < 0 || int.Parse(TxtMinute.Text) > 95)
            {
                MessageBox.Show("Minutes can't be under 0 or higher than 95 minutes.", "Error");
                return;
            }
            var matchDetails = await _aPIServiceMatches.GetById<List<MatchDetail>>(Id, "MatchDetail");
            if (matchDetails.Count != 0)
            {
                var lastRecord = matchDetails.LastOrDefault();
                if (lastRecord.Minute > int.Parse(TxtMinute.Text))
                {
                    MessageBox.Show("Last added detail have lower minute.", "Error");
                    return;
                }
            }

            var matchDetail = new MatchDetail
            {
                ClubId = int.Parse(CmbClubs.SelectedValue.ToString()),
                MatchId = Id,
                Minute = int.Parse(TxtMinute.Text),
                PlayerId = int.Parse(CmbPlayers.SelectedValue.ToString()),
                ActionType = int.Parse(CmbEvent.SelectedIndex.ToString())
            };
            await _aPIServiceMatches.Insert<MatchDetail>(matchDetail, "NewDetailMatch");
            FrmMatchDetail frm = new FrmMatchDetail(Id);
            frm.Show();
            Close();
        }
    }
}
