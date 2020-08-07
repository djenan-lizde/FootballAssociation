using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Extensions;
using static Transfermarkt.Models.Enums.Enums;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmPlayer : Form
    {
        private readonly APIService _aPIServicePlayer = new APIService("Players");
        private readonly APIService _aPIServicePositions = new APIService("Positions");

        public int? Id { get; set; }

        public FrmPlayer(int? id = null)
        {
            InitializeComponent();
            Id = id;
        }

        private async void FrmPlayers_Load(object sender, EventArgs e)
        {
            var list = Globals.ToPairList<StrongerFoot>(typeof(StrongerFoot)).ToList();
            list.Insert(0, new KeyValuePair<int, string>());
            CmbStrongerFoot.DataSource = list.ToList();
            CmbStrongerFoot.DisplayMember = "Value";
            CmbStrongerFoot.ValueMember = "Key";

            var positions = await _aPIServicePositions.Get<List<Positions>>();
            if (positions.Count == 0)
            {
                MessageBox.Show("We don't have positions,", "Information");
                return;
            }
            listBox1.DataSource = positions.ToList();
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Id";

            if (Id.HasValue)
            {
                var player = await _aPIServicePlayer.GetById<Players>(Id);
                TxtBirthDate.Text = player.Birthdate.ToString();
                TxtFirstName.Text = player.FirstName;
                TxtHeight.Text = player.Height.ToString();
                TxtJerseyNumber.Text = player.Jersey.ToString();
                TxtLastName.Text = player.LastName;
                TxtMarketValue.Text = player.Value.ToString();
                TxtMiddleName.Text = player.MiddleName;
                TxtWeight.Text = player.Weight.ToString();
                ChBoxSign.Checked = player.IsSigned;
                CmbStrongerFoot.SelectedIndex = player.StrongerFoot;
                if (player.IsSigned)
                {
                    ChBoxSign.Enabled = false;
                }
            }
        }
        private async void BtnAddPlayer_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {

                Players player = new Players
                {
                    FirstName = TxtFirstName.Text,
                    LastName = TxtLastName.Text,
                    Birthdate = DateTime.Parse(TxtBirthDate.Text.ToString()),
                    Height = int.Parse(TxtHeight.Text.ToString()),
                    Jersey = int.Parse(TxtJerseyNumber.Text.ToString()),
                    Value = int.Parse(TxtMarketValue.Text.ToString()),
                    Weight = int.Parse(TxtWeight.Text.ToString()),
                    StrongerFoot = int.Parse(CmbStrongerFoot.SelectedIndex.ToString()),
                    Id = Id ?? 0
                };
                if (string.IsNullOrEmpty(TxtMiddleName.Text))
                    player.MiddleName = "N/A";
                else
                    player.MiddleName = TxtMiddleName.Text;

                if (ChBoxSign.Checked)
                {
                    player.IsSigned = true;
                }
                else
                {
                    player.IsSigned = false;
                }
                Players lastAdded = null;
                if (Id.HasValue)
                    lastAdded = await _aPIServicePlayer.Update<Players>(player, player.Id.ToString());
                else
                    lastAdded = await _aPIServicePlayer.Insert<Players>(player);

                if (!Id.HasValue)
                {
                    var selectedValues = listBox1.SelectedItems.Cast<Positions>().Select(x => x.Id).ToList();
                    for (int i = 0; i < selectedValues.Count(); i++)
                    {
                        await _aPIServicePlayer.Insert<PlayerPositions>(new PlayerPositions
                        {
                            PlayerId = lastAdded.Id,
                            PositionId = selectedValues[i]
                        }, "InsertPlayerPosition");
                    }
                }
                if (ChBoxSign.Checked)
                {
                    if (ChBoxSign.Enabled == false)
                    {
                        return;
                    }
                    else
                    {
                        FrmContract frm = new FrmContract(lastAdded.FirstName, lastAdded.LastName, lastAdded.Id);
                        frm.Show();
                    }
                }
                Close();
            }
        }

        private void TxtFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtFirstName.Text))
            {
                errorProvider.SetError(TxtFirstName, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtFirstName, null);
            }
        }
        private void TxtLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtLastName.Text))
            {
                errorProvider.SetError(TxtLastName, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtLastName, null);
            }
        }
        private void TxtHeight_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool success = int.TryParse(TxtHeight.Text, out _);
            if (string.IsNullOrWhiteSpace(TxtHeight.Text) || !success)
            {
                errorProvider.SetError(TxtHeight, "Please insert number between 0 and 250");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtHeight, null);
            }
        }
        private void TxtWeight_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool success = int.TryParse(TxtWeight.Text, out _);
            if (string.IsNullOrWhiteSpace(TxtWeight.Text) || !success)
            {
                errorProvider.SetError(TxtWeight, "Please insert number between 0 and 500.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtWeight, null);
            }
        }
        private void TxtJerseyNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool success = int.TryParse(TxtJerseyNumber.Text, out _);
            if (string.IsNullOrWhiteSpace(TxtJerseyNumber.Text) || !success)
            {
                errorProvider.SetError(TxtJerseyNumber, "Please insert number between 0 and 100.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtJerseyNumber, null);
            }
        }
        private void TxtMarketValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool success = int.TryParse(TxtMarketValue.Text, out _);
            if (string.IsNullOrWhiteSpace(TxtMarketValue.Text) || !success)
            {
                errorProvider.SetError(TxtMarketValue, "Please insert number higher than 0");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtMarketValue, null);
            }
        }
        private void CmbStrongerFoot_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CmbStrongerFoot.SelectedIndex == 0 || CmbStrongerFoot.SelectedIndex == -1)
            {
                errorProvider.SetError(CmbStrongerFoot, "You need to select option from combo box");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(CmbStrongerFoot, null);
            }
        }
        private void TxtBirthDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool success = DateTime.TryParse(TxtBirthDate.Text, out _);
            if (string.IsNullOrWhiteSpace(TxtBirthDate.Text) || !success)
            {
                errorProvider.SetError(TxtBirthDate, "Please insert date");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtBirthDate, null);
            }
        }
    }
}
