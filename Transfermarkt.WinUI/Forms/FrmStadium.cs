﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            this.AutoValidate = AutoValidate.Disable;
        }

        private async void FrmStadium_Load(object sender, EventArgs e)
        {
            lblClubName.Text = ClubName;

            try
            {
                var stadiums = await _aPIServiceStadium.Get<List<Stadiums>>();
                var _stadium = stadiums.FirstOrDefault(x => x.ClubId == Id);
                if (_stadium != null)
                {
                    TxtCapacity.Text = _stadium.Capacity.ToString();
                    dateTimePicker1.Value = _stadium.DateBuilt;
                    TxtStadiumName.Text = _stadium.Name;
                    txtStadiumId.Text = _stadium.Id.ToString();
                }
                else
                {
                    MessageBox.Show("This clubs doesn't have stadium. Please added it.", "Information", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
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
                stadium.DateBuilt = dateTimePicker1.Value;
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
    }
}
