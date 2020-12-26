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
        private readonly APIService _aPIServicePlayer = new APIService("Players");
        private readonly APIService _aPIServiceContracts = new APIService("Contracts");
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly bool _signed;
        private readonly int _id;

        public FrmContract(string firstName, string lastName, int id, bool signed)
        {
            InitializeComponent();
            _firstName = firstName;
            _lastName = lastName;
            _id = id;
            _signed = signed;
            this.AutoValidate = AutoValidate.Disable;
        }

        private async void FrmContract_Load(object sender, EventArgs e)
        {
            var clubs = await _aPIServiceClubs.Get<List<Clubs>>();

            if (clubs.Count == 0)
            {
                MessageBox.Show("We don't have clubs.", "Information");
                return;
            }

            clubs.Insert(0, new Clubs());
            CmbClubs.DataSource = clubs;
            CmbClubs.DisplayMember = "Name";
            CmbClubs.ValueMember = "Id";

            PlayerName.Text = $"{_firstName} {_lastName}";
        }

        private async void BtnSignContract_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var contracts = await _aPIServiceContracts.GetById<List<Contracts>>(_id, "PlayerContracts");

                var contractInDb = contracts.LastOrDefault(x => x.PlayerId == _id);

                if (dateTimePicker1.Value < DateTime.Now)
                {
                    MessageBox.Show("Expiration date can't be lower than today's date.", "Information", MessageBoxButtons.OK);
                    return;
                }

                if (contractInDb == null || contractInDb.IsExpired)
                {
                    await _aPIServiceContracts.Insert<Contracts>(new Contracts
                    {
                        ClubId = int.Parse(CmbClubs.SelectedValue.ToString()),
                        ExpirationDate = dateTimePicker1.Value,
                        IsExpired = false,
                        PlayerId = _id,
                        RedemptionClause = int.Parse(TxtRedemptionClause.Text),
                        SignedDate = DateTime.Now
                    });
                    var player = await _aPIServicePlayer.GetById<Players>(_id);
                    player.IsSigned = true;
                    await _aPIServicePlayer.Update<Players>(player, player.Id.ToString());
                    MessageBox.Show("Player is successfully signed! ", "Information", MessageBoxButtons.OK);
                    FrmPlayersList frm = new FrmPlayersList();
                    frm.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Players contract is not expired yet!", "Error");
                    return;
                }
            }
        }

        private void TxtRedemptionClause_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool success = int.TryParse(TxtRedemptionClause.Text, out _);
            if (string.IsNullOrWhiteSpace(TxtRedemptionClause.Text) || !success)
            {
                errorProvider.SetError(TxtRedemptionClause, "Please insert an integer number.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtRedemptionClause, null);
            }
        }
        private void CmbClubs_Validating(object sender, System.ComponentModel.CancelEventArgs e)
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
    }
}
