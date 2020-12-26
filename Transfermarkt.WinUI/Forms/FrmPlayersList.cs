using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmPlayersList : Form
    {
        private readonly APIService _aPIServicePlayer = new APIService("Players");
        private readonly APIService _aPIServiceContract = new APIService("Contracts");
        public FrmPlayersList()
        {
            InitializeComponent();
        }

        private async void FrmPlayersList_Load(object sender, EventArgs e)
        {
            var result = await _aPIServicePlayer.Get<List<Players>>();
            if (result.Count() == 0)
            {
                MessageBox.Show("We don't have players in database.");
                return;
            }

            DgvPlayersList.DataSource = result;
        }
        private async void BtnPlayersList_Click(object sender, EventArgs e)
        {
            DgvPlayersList.DataSource = null;

            var result = await _aPIServicePlayer.Get<List<Players>>();
            if (result.Count() == 0)
            {
                MessageBox.Show("We don't have players in database.","Information", MessageBoxButtons.OK);
                return;
            }

            DgvPlayersList.DataSource = result;
        }
        private void DgvPlayersList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = DgvPlayersList.SelectedRows[0].Cells[0].Value;

            if ((int)id == 0)
            {
                MessageBox.Show("You need to select a player.", "Error", MessageBoxButtons.OK);
                return;
            }

            FrmPlayer frm = new FrmPlayer(int.Parse(id.ToString()));
            frm.Show();
        }
        private async void BtnUnsignedPlayers_Click(object sender, EventArgs e)
        {
            DgvPlayersList.DataSource = null;

            var result = await _aPIServicePlayer.Get<List<Players>>(null, "UnsignedPlayers");

            if (result.Count == 0)
            {
                MessageBox.Show("We don't have unsigned players in database.");
                var players = await _aPIServicePlayer.Get<List<Players>>();
                DgvPlayersList.DataSource = players;
                return;
            }
            DgvPlayersList.DataSource = result;
        }
        private async void BtnContractUpdate_Click(object sender, EventArgs e)
        {
            var contracts = await _aPIServiceContract.Get<List<Contracts>>("UnexpiredContracts");
            if (contracts.Count == 0)
            {
                MessageBox.Show("No expired contracts", "Information");
                return;
            }
            foreach (var item in contracts)
            {
                if (DateTime.Now > item.ExpirationDate)
                {
                    var player = await _aPIServicePlayer.GetById<Players>(item.PlayerId);
                    if (player == null)
                    {
                        MessageBox.Show("This player doesn't exist", "Error");
                        continue;
                    }
                    item.IsExpired = true;
                    player.IsSigned = false;
                    await _aPIServiceContract.Update<Contracts>(item, item.Id.ToString());
                    await _aPIServicePlayer.Update<Players>(player, player.Id.ToString());
                }
            }
            MessageBox.Show("Contracts updated", "Information", MessageBoxButtons.OK);
        }
        private async void TxtSearchPlayer_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSearchPlayer.Text))
            {
                DgvPlayersList.DataSource = await _aPIServicePlayer.Get<List<Players>>(null);
                return;
            }

            var data = await _aPIServicePlayer.Get<List<Players>>(new PlayerSearchRequest
            {
                FirstName = TxtSearchPlayer.Text.ToLower(),
                LastName = TxtSearchPlayer.Text.ToLower()
            });

            DgvPlayersList.DataSource = data;
        }
    }
}
