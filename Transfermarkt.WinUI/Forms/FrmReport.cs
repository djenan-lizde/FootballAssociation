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
            BtnPrint.Enabled = false;
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
            BtnPrint.Enabled = true;
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
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var tableData = clubContractsMoneySpent;
                if (tableData.Count > 0)
                {
                    Stream stream = File.OpenWrite(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SeasonReport.pdf");
                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    Font times = new Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN);

                    Paragraph header = new Paragraph($"Report for the league {CmbLeagues.Text}", times)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        Font = times
                    };
                    doc.Add(header);
                    doc.Add(new Paragraph("\n"));

                    PdfPTable table = new PdfPTable(2);

                    foreach (var item in tableData.OrderByDescending(x => x.Sum))
                    {
                        PdfPCell cell1 = new PdfPCell(new Phrase($"{item.ClubName}"))
                        {
                            HorizontalAlignment = 1
                        };
                        table.AddCell(cell1);
                        PdfPCell cell2 = new PdfPCell(new Phrase($"{item.Sum} €"))
                        {
                            HorizontalAlignment = 1
                        };
                        table.AddCell(cell2);
                    }
                    doc.Add(table);
                    Paragraph footer = new Paragraph($"Transfer sum { clubContractsMoneySpent.Sum(x => x.Sum)} €", times)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        Font = times
                    };
                    doc.Add(footer);
                    doc.Add(new Paragraph("\n"));

                    var transferTableData = transfers;
                    if (transferTableData.Count > 0)
                    {
                        doc.Add(new Paragraph("\n"));

                        PdfPTable transferTable = new PdfPTable(3);

                        PdfPCell elements = new PdfPCell(new Phrase("Player name - Expiration date - Redemption clause"))
                        {
                            HorizontalAlignment = 1
                        };
                        elements.Colspan = 3;
                        transferTable.AddCell(elements);

                        foreach (var item in transferTableData.OrderByDescending(x => x.RedemptionClause))
                        {
                            PdfPCell cell1 = new PdfPCell(new Phrase($"{item.PlayerFullName}"))
                            {
                                HorizontalAlignment = 1
                            };
                            transferTable.AddCell(cell1);
                            PdfPCell cell2 = new PdfPCell(new Phrase($"{item.ContractExpirationDate.ToShortDateString()}"))
                            {
                                HorizontalAlignment = 1
                            };
                            transferTable.AddCell(cell2);
                            PdfPCell cell3 = new PdfPCell(new Phrase($"{item.RedemptionClause} €"))
                            {
                                HorizontalAlignment = 1
                            };
                            transferTable.AddCell(cell3);
                        }
                        doc.Add(transferTable);
                    }
                    doc.Close();

                    MessageBox.Show("Report successfully saved to desktop.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("There is no enough data to create a report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
