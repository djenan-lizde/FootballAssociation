using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmReport : Form
    {
        private readonly APIService _apiServiceContracts = new APIService("Contracts");
        private readonly APIService _apiServiceLeagues = new APIService("Leagues");
        private readonly APIService _apiServiceClubs = new APIService("Clubs");
        private readonly APIService _apiServicePlayers = new APIService("Players");

        public FrmReport()
        {
            InitializeComponent();
        }

        private async void FrmReport_Load(object sender, EventArgs e)
        {
            var leagues = await _apiServiceLeagues.Get<List<Leagues>>();
            CmbLeagues.DataSource = leagues;
            CmbLeagues.DisplayMember = "Name";
            CmbLeagues.ValueMember = "Id";
        }

        public List<ClubContracts> clubContractsMoneySpent = new List<ClubContracts>();
        public List<Transfers> transfers = new List<Transfers>();
        private async void CmbLeagues_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TxtTotalSum.Enabled = true;
            clubContractsMoneySpent.Clear();
            transfers.Clear();
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
                    if (clubContracts.Count() == 0)
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
                            RedemptionClause = item2.RedemptionClause
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
                foreach (var item in clubContractsMoneySpent)
                {
                    ChrPie.Series["s1"].Points.AddXY(item.ClubName, item.Sum);
                }
                TxtTotalSum.Text = clubContractsMoneySpent.Sum(x => x.Sum).ToString();
                DgvTransfers.DataSource = transfers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Stream stream = File.OpenWrite(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ContractsSum.txt");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ClubContracts>));
                xmlSerializer.Serialize(stream, clubContractsMoneySpent);

                stream.Close();
                MessageBox.Show("Successfully saved to desktop.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
