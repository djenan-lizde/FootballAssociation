using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Transfermarkt.Models;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmStadium : Form
    {
        private readonly APIService _aPIServiceStadium = new APIService("Stadiums");
        public string ClubName { get; set; }
        public int Id { get; set; }

        public FrmStadium(int id, string clubName)
        {
            InitializeComponent();
            Id = id;
            ClubName = clubName;
        }

        private async void FrmStadium_Load(object sender, EventArgs e)
        {
            lblClubName.Text = ClubName;

            try
            {
                var _stadium = await _aPIServiceStadium.GetById<Stadiums>(Id, "HomeStadium");
                if (_stadium != null)
                {
                    TxtCapacity.Text = _stadium.Capacity.ToString();
                    TxtDateBuilt.Text = _stadium.DateBuilt.ToString();
                    TxtStadiumName.Text = _stadium.Name;
                    txtStadiumId.Text = _stadium.Id.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("This club doesn't have stadium", "Information", MessageBoxButtons.OK);
                return;
            }
        }

        readonly Stadiums stadium = new Stadiums();
        private async void BtnSaveStadium_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                if (Id == 0)
                {
                    var stadiums = await _aPIServiceStadium.Get<List<Stadiums>>();

                    foreach (var item in stadiums)
                    {
                        if (item.Name == TxtStadiumName.Text)
                        {
                            MessageBox.Show("Stadium already exists!", "Information", MessageBoxButtons.OK);
                            return;
                        }
                    }
                }

                stadium.Capacity = int.Parse(TxtCapacity.Text);
                stadium.ClubId = Id;
                stadium.DateBuilt = DateTime.Parse(TxtDateBuilt.Text.ToString());
                stadium.Name = TxtStadiumName.Text;
                if (string.IsNullOrWhiteSpace(txtStadiumId.Text))
                    stadium.Id = 0;
                else
                    stadium.Id = int.Parse(txtStadiumId.Text.ToString());

                if (stadium.Id == 0)
                {
                    await _aPIServiceStadium.Insert<Stadiums>(stadium);
                    MessageBox.Show("Successfully added!", "Stadium added");
                    Close();
                }
                else
                {
                    await _aPIServiceStadium.Update<Stadiums>(stadium, stadium.Id.ToString());
                    MessageBox.Show("Successfully updated!", "Stadium updated");
                    Close();
                }
            }
        }

        private void TxtStadiumName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtStadiumName.Text))
            {
                errorProvider.SetError(TxtStadiumName, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtStadiumName, null);
            }
        }
        private void TxtCapacity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool success = int.TryParse(TxtCapacity.Text, out _);
            if (string.IsNullOrWhiteSpace(TxtCapacity.Text) || !success)
            {
                errorProvider.SetError(TxtCapacity, "Please insert number");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtCapacity, null);
            }
        }
        private void TxtDateBuilt_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool success = DateTime.TryParse(TxtDateBuilt.Text, out _);
            if (string.IsNullOrWhiteSpace(TxtDateBuilt.Text) || !success)
            {
                errorProvider.SetError(TxtDateBuilt, "Please insert date");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtDateBuilt, null);
            }
        }
    }
}
