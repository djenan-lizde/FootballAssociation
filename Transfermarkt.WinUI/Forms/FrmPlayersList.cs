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

        private async void BtnPlayersList_Click(object sender, EventArgs e)
        {
            var result = await _aPIServicePlayer.Get<List<Player>>();
            if (result.Count() == 0)
            {
                MessageBox.Show("We don't have players in database.");
                return;
            }

            DgvPlayersList.DataSource = result;
        }
        private void DgvPlayersList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = DgvPlayersList.SelectedRows[0].Cells[0].Value;
            FrmPlayer frm = new FrmPlayer(int.Parse(id.ToString()));
            frm.Show();
        }
        private async void BtnUnsignedPlayers_Click(object sender, EventArgs e)
        {
            var result = await _aPIServicePlayer.Get<List<Player>>(null, "UnsignedPlayers");

            if (result.Count == 0)
            {
                MessageBox.Show("We don't have unsigned players in database.");
                return;
            }
            DgvPlayersList.DataSource = result;
        }
        private async void BtnContractUpdate_Click(object sender, EventArgs e)
        {
            var contracts = await _aPIServiceContract.Get<List<Contract>>("UnexpiredContracts");
            if (contracts.Count == 0)
            {
                MessageBox.Show("No expired contracts", "Information");
                return;
            }
            foreach (var item in contracts)
            {
                if (DateTime.Now > item.ExpirationDate)
                {
                    var player = await _aPIServicePlayer.GetById<Player>(item.PlayerId);
                    if (player == null)
                    {
                        MessageBox.Show("This player doesn't exist", "Error");
                        return;
                    }
                    item.IsExpired = true;
                    player.IsSigned = false;
                    await _aPIServiceContract.Update<Contract>(item);
                    await _aPIServicePlayer.Update<Player>(player);
                }
            }
        }
        private async void TxtSearchPlayer_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtSearchPlayer.Text))
            {
                DgvPlayersList.DataSource = await _aPIServicePlayer.Get<List<Player>>(null);
                return;
            }
            var request = new PlayerSearchRequest
            {
                FirstName = TxtSearchPlayer.Text.ToLower(),
                LastName = TxtSearchPlayer.Text.ToLower(),
                IsSigned = ChcIsSigned.Checked
            };
            var data = await _aPIServicePlayer.Get<List<Player>>(request, "PlayerSearch");

            DgvPlayersList.DataSource = data;
        }
    }
}
