using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Transfermarkt.Models;
using System.Linq;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmContract : Form
    {
        private readonly APIService _aPIServiceClubs = new APIService("Clubs");
        private readonly APIService _aPIServiceContracts = new APIService("Contracts");
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly int _id;

        public FrmContract(string firstName, string lastName, int id)
        {
            InitializeComponent();
            _firstName = firstName;
            _lastName = lastName;
            _id = id;
        }

        private async void FrmContract_Load(object sender, EventArgs e)
        {
            var clubs = await _aPIServiceClubs.Get<List<Club>>();

            CmbClubs.DataSource = clubs;
            CmbClubs.DisplayMember = "Name";
            CmbClubs.ValueMember = "Id";

            PlayerName.Text = $"{_firstName} {_lastName}";
        }

        private async void BtnSignContract_Click(object sender, EventArgs e)
        {
            var contracts = await _aPIServiceContracts.GetById<List<Contract>>(_id, "PlayerContracts");

            var contractInDb = contracts.LastOrDefault(x => x.PlayerId == _id);

            if (contractInDb == null || contractInDb.IsExpired)
            {
                Contract contract = new Contract
                {
                    ClubId = int.Parse(CmbClubs.SelectedValue.ToString()),
                    ExpirationDate = DateTime.Parse(TxtExpirationDate.Text),
                    IsExpired = false,
                    PlayerId = _id,
                    RedemptionClause = int.Parse(TxtRedemptionClause.Text),
                    SignedDate = DateTime.Now
                };
                await _aPIServiceContracts.Insert<Contract>(contract);
                MessageBox.Show("Player is successfully signed! ", "Error");
                return;
            }
            else
            {
                MessageBox.Show("Players contract is not expired yet!", "Error");
                return;
            }
        }
    }
}
