using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmReport : Form
    {
        private readonly APIService _apiServiceContracts = new APIService("Contracts");
        private readonly APIService _apiServiceLeagues = new APIService("Leagues");
        private readonly APIService _apiServiceClubs = new APIService("Clubs");
        private readonly APIService _apiServicePlayers = new APIService("Players");
        private readonly APIService _reportsService = new APIService("Reports");

        public FrmReport()
        {
            InitializeComponent();
        }

        private async void FrmReport_Load(object sender, EventArgs e)
        {
            var leagues = await _apiServiceLeagues.Get<List<Leagues>>();
            if (leagues.Count == 0)
            {
                MessageBox.Show("We don't have leagues", "Information", MessageBoxButtons.OK);
                return;
            }
            BtnClubContracts.Enabled = false;
            BtnTransfers.Enabled = false;
            leagues.Insert(0, new Leagues());
            CmbLeagues.DataSource = leagues;
            CmbLeagues.DisplayMember = "Name";
            CmbLeagues.ValueMember = "Id";
            TxtTotalSum.ReadOnly = true;
        }

        public List<ClubContracts> clubContractsMoneySpent = new List<ClubContracts>();
        public List<Transfers> transfers = new List<Transfers>();
        private async void CmbLeagues_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TxtTotalSum.Enabled = true;
            BtnClubContracts.Enabled = true;
            BtnTransfers.Enabled = true;
            clubContractsMoneySpent.Clear();
            transfers.Clear();
            DgvTransfers.DataSource = null;

            var selectedValue = int.Parse(CmbLeagues.SelectedValue.ToString());
            var clubsInLeague = await _apiServiceClubs.GetById<List<ClubsLeague>>(selectedValue, "ClubsInLeague");

            if (clubsInLeague.Count() == 0)
            {
                return;
            }
            try
            {
                foreach (var item in clubsInLeague)
                {
                    var clubContracts = await _apiServiceContracts.GetById<List<Contracts>>(item.ClubId, "ClubContracts");
                    if (clubContracts.Count == 0)
                    {
                        continue;
                    }
                    var club = await _apiServiceClubs.GetById<Clubs>(item.ClubId);
                    foreach (var item2 in clubContracts)
                    {
                        var player = await _apiServicePlayers.GetById<Players>(item2.PlayerId);
                        transfers.Add(new Transfers
                        {
                            ClubName = club.Name,
                            ContractExpirationDate = item2.ExpirationDate,
                            PlayerFullName = $"{player.FirstName} {player.LastName}",
                            RedemptionClause = $"{item2.RedemptionClause} €"
                        });
                    }
                    var contractsSum = clubContracts.Sum(x => x.RedemptionClause);
                    clubContractsMoneySpent.Add(new ClubContracts
                    {
                        ClubName = club.Name,
                        Sum = contractsSum
                    });
                }

                ChrPie.Series["s1"].IsValueShownAsLabel = true;
                ChrPie.Series["s1"].Points.Clear();
                foreach (var item in clubContractsMoneySpent)
                {
                    ChrPie.Series["s1"].Points.AddXY(item.ClubName, item.Sum);
                }
                TxtTotalSum.Text = clubContractsMoneySpent.Sum(x => x.Sum).ToString();
                DgvTransfers.DataSource = transfers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void BtnTransfers_Click(object sender, EventArgs e)
        {
            try
            {
                await _reportsService.GetExcelFile($"Transfers_Report_{DateTime.UtcNow.Ticks}.xls", $"transfers");
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error while creating report.", "Information");
                throw;
            }
        }

        private async void BtnClubContracts_Click(object sender, EventArgs e)
        {
            try
            {
                await _reportsService.GetExcelFile($"ClubContracts_Report_{DateTime.UtcNow.Ticks}.xls", "clubContracts");
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error while creating report.", "Information");
                throw;
            }
        }
    }
}
