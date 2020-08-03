using System;
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
            var list = Globals.ToPairList<ActionType>(typeof(ActionType)).ToList();
            CmbEvent.DataSource = list;
            CmbEvent.DisplayMember = "Value";
            CmbEvent.ValueMember = "Key";

            var match = await _aPIServiceMatches.GetById<Matches>(Id);

            var homeClub = await _aPIServiceClubs.GetById<Clubs>(match.HomeClubId);
            var awayClub = await _aPIServiceClubs.GetById<Clubs>(match.AwayClubId);
            if (homeClub == null || awayClub == null)
            {
                return;
            }

            //clubs for drop down list
            List<Clubs> clubs = new List<Clubs>
            {
                homeClub,
                awayClub
            };
            CmbClubs.DataSource = clubs;
            CmbClubs.DisplayMember = "Name";
            CmbClubs.ValueMember = "Id";
        }
        private async void CmbClubs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CmbPlayers.SelectedItem = null;
            CmbPlayers.SelectedText = "--select--";
            List<Players> players = new List<Players>();

            var clubId = int.Parse(CmbClubs.SelectedValue.ToString());

            var playerContract = await _aPIServiceContracts.GetById<List<Contracts>>(clubId, "ClubContracts");

            foreach (var item in playerContract)
            {
                var player = await _aPIServicePlayers.GetById<Players>(item.PlayerId);
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
            var matchDetails = await _aPIServiceMatches.GetById<List<MatchDetails>>(Id, "MatchDetail");
            if (matchDetails.Count != 0)
            {
                var lastRecord = matchDetails.LastOrDefault();
                if (lastRecord.Minute > int.Parse(TxtMinute.Text))
                {
                    MessageBox.Show("Last added detail have lower minute.", "Error");
                    return;
                }
            }

            await _aPIServiceMatches.Insert<MatchDetails>(new MatchDetails
            {
                ClubId = int.Parse(CmbClubs.SelectedValue.ToString()),
                MatchId = Id,
                Minute = int.Parse(TxtMinute.Text),
                PlayerId = int.Parse(CmbPlayers.SelectedValue.ToString()),
                ActionType = int.Parse(CmbEvent.SelectedIndex.ToString())
            }, "NewDetailMatch");
            FrmMatchDetail frm = new FrmMatchDetail(Id);
            frm.Show();
            Close();
        }
    }
}
