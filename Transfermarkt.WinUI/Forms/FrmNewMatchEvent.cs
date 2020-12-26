using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Extensions;
using Transfermarkt.Models.Requests;
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
            this.AutoValidate = AutoValidate.Disable;
        }
        private async void FrmNewMatchEvent_Load(object sender, EventArgs e)
        {
            var list = Globals.ToPairList<ActionType>(typeof(ActionType)).ToList();
            list.Insert(0, new KeyValuePair<int, string>());
            CmbEvent.DataSource = list;
            CmbEvent.DisplayMember = "Value";
            CmbEvent.ValueMember = "Key";

            var match = await _aPIServiceMatches.GetById<Matches>(Id);

            if (match == null)
            {
                MessageBox.Show("Match not selected", "Error");
                return;
            }
            var homeClub = await _aPIServiceClubs.GetById<Clubs>(match.HomeClubId);
            var awayClub = await _aPIServiceClubs.GetById<Clubs>(match.AwayClubId);
            if (homeClub == null || awayClub == null)
            {
                MessageBox.Show("Club not existing", "Error");
                return;
            }

            //clubs for drop down list
            List<Clubs> clubs = new List<Clubs>
            {
                homeClub,
                awayClub
            };
            clubs.Insert(0, new Clubs());
            CmbClubs.DataSource = clubs;
            CmbClubs.DisplayMember = "Name";
            CmbClubs.ValueMember = "Id";
        }
        private async void CmbClubs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var clubId = int.Parse(CmbClubs.SelectedValue.ToString());
            if (clubId == 0)
            {
                MessageBox.Show("Club not selected", "Error", MessageBoxButtons.OK);
                return;
            }
            var playerContract = await _aPIServiceContracts.GetById<List<Contracts>>(clubId, "ClubContracts");

            List<PersonDropDownList> players = new List<PersonDropDownList>();
            foreach (var item in playerContract)
            {
                var player = await _aPIServicePlayers.GetById<Players>(item.PlayerId);
                if (player == null) continue;
                players.Add(new PersonDropDownList
                {
                    FullName = $"{player.FirstName} {player.LastName}",
                    Id = player.Id
                });
            }

            players.Insert(0, new PersonDropDownList());
            CmbPlayers.DataSource = players.ToList();
            CmbPlayers.DisplayMember = "FullName";
            CmbPlayers.ValueMember = "Id";
        }
        private async void BtnSaveDetail_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
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
                    ActionType = int.Parse(CmbEvent.SelectedIndex.ToString()) - 1
                }, "NewDetailMatch");
                FrmMatchDetail frm = new FrmMatchDetail(Id);
                frm.Show();
                Close();
            }
        }
        private void TxtMinute_Validating(object sender, CancelEventArgs e)
        {
            bool success = int.TryParse(TxtMinute.Text, out _);
            if (string.IsNullOrWhiteSpace(TxtMinute.Text) || !success)
            {
                errorProvider.SetError(TxtMinute, "Please insert date");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtMinute, null);
            }
        }
        private void CmbEvent_Validating(object sender, CancelEventArgs e)
        {
            if (CmbEvent.SelectedIndex == 0 || CmbEvent.SelectedIndex == -1)
            {
                errorProvider.SetError(CmbEvent, "You need to select option from combo box");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(CmbEvent, null);
            }
        }
        private void CmbClubs_Validating(object sender, CancelEventArgs e)
        {
            if (CmbClubs.SelectedIndex == 0 || CmbClubs.SelectedIndex == -1)
            {
                errorProvider.SetError(CmbClubs, "You need to select option from combo box");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(CmbClubs, null);
            }
        }
        private void CmbPlayers_Validating(object sender, CancelEventArgs e)
        {
            if (CmbPlayers.SelectedIndex == 0 || CmbPlayers.SelectedIndex == -1)
            {
                errorProvider.SetError(CmbPlayers, "You need to select option from combo box");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(CmbPlayers, null);
            }
        }
    }
}
