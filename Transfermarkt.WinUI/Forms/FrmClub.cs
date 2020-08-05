using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using Transfermarkt.WinUI.Helper;
using System.Data;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmClub : Form
    {
        private readonly APIService _aPIServiceCity = new APIService("Cities");
        private readonly APIService _aPIServiceLeague = new APIService("Leagues");
        private readonly APIService _aPIServiceClub = new APIService("Clubs");
        private readonly APIService _aPIServiceContract = new APIService("Contracts");
        private readonly APIService _aPIServicePlayer = new APIService("Players");

        public int? Id { get; set; }
        Clubs club = new Clubs();

        public FrmClub(int? id = null)
        {
            InitializeComponent();
            Id = id;
        }
        private async void FrmInsertClub_Load(object sender, EventArgs e)
        {
            var resultCity = await _aPIServiceCity.Get<List<Cities>>();

            CmbCities.DataSource = resultCity;
            CmbCities.DisplayMember = "Name";
            CmbCities.ValueMember = "Id";

            var resultLeague = await _aPIServiceLeague.Get<List<Leagues>>();

            CmbLeagues.DataSource = resultLeague;
            CmbLeagues.DisplayMember = "Name";
            CmbLeagues.ValueMember = "Id";

            if (Id.HasValue)
            {
                var clubLoad = await _aPIServiceClub.GetById<Clubs>(Id);
                TxtAbbreviation.Text = clubLoad.Abbreviation;
                TxtClubName.Text = clubLoad.Name;
                TxtDateFounded.Text = clubLoad.Founded.ToString();
                TxtMarketValue.Text = clubLoad.MarketValue.ToString();
                TxtNickname.Text = clubLoad.Nickname;
                CmbCities.SelectedIndex = clubLoad.CityId - 1;
                CmbLeagues.Enabled = false;
                if (clubLoad.Logo != null)
                {
                    Image image = ImageResizer.ByteArrayToImage(clubLoad.Logo);
                    var newImage = ImageResizer.ResizeImage(image, 200, 200);
                    pictureBox1.Image = newImage;
                }
                label9.Visible = true;
                var contracts = await _aPIServiceContract.GetById<List<Contracts>>(Id, "ClubContracts");
                if (contracts.Count == 0)
                {
                    MessageBox.Show("This clubs doesn't have players yet.", "Information");
                    return;
                }
                DgvPlayers.Visible = true;
                BtnMatchSchedule.Visible = true;
                List<PlayersClub> playersClubs = new List<PlayersClub>();
                foreach (var item in contracts)
                {
                    var playerInDb = await _aPIServicePlayer.GetById<Players>(item.PlayerId);
                    var player = new PlayersClub
                    {
                        Id = item.PlayerId,
                        Birthdate = playerInDb.Birthdate,
                        FirstName = playerInDb.FirstName,
                        Jersey = playerInDb.Jersey,
                        LastName = playerInDb.LastName
                    };
                    playersClubs.Add(player);
                }
                DgvPlayers.DataSource = playersClubs;
            }
        }
        private async void BtnSaveClub_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                club.MarketValue = int.Parse(TxtMarketValue.Text);
                club.Name = TxtClubName.Text;
                club.Nickname = TxtNickname.Text;
                club.CityId = int.Parse(CmbCities.SelectedValue.ToString());
                club.Founded = DateTime.Parse(TxtDateFounded.Text.ToString());
                club.Abbreviation = TxtAbbreviation.Text;
                club.Id = Id ?? 0;

                if (Id.HasValue)
                {
                    var clubInDb = await _aPIServiceClub.GetById<Clubs>(club.Id);
                    club.Logo = clubInDb.Logo;
                    await _aPIServiceClub.Update<Clubs>(club, club.Id.ToString());
                    MessageBox.Show("Successfully updated.", "Club update");
                }
                else
                {
                    club = await _aPIServiceClub.Insert<Clubs>(club);
                    Id = club.Id;
                    MessageBox.Show("Successfully added.", "Information");
                    FrmStadium frm = new FrmStadium(club.Id, club.Name);
                    frm.Show();
                }
                Close();
            }
        }
        private void BtnAddLogo_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;

                var file = File.ReadAllBytes(fileName);

                club.Logo = file;
                TxtPhotoInput.Text = fileName;

                Image image = Image.FromFile(fileName);
                Image newImage = ImageResizer.ResizeImage(image, 200, 200);
                pictureBox1.Image = newImage;
            }
        }
        private void BtnMatchSchedule_Click(object sender, EventArgs e)
        {
            FrmClubMatchSchedule frm = new FrmClubMatchSchedule(Id);
            frm.Show();
        }
        private void TxtClubName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtClubName.Text))
            {
                errorProvider.SetError(TxtClubName, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtClubName, null);
            }
        }
        private void TxtNickname_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNickname.Text))
            {
                errorProvider.SetError(TxtNickname, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtNickname, null);
            }
        }
        private void TxtAbbreviation_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtAbbreviation.Text))
            {
                errorProvider.SetError(TxtAbbreviation, "Input can not be an empty string.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtAbbreviation, null);
            }
        }
        private void TxtPhotoInput_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPhotoInput.Text))
            {
                errorProvider.SetError(TxtPhotoInput, "Please insert logo");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtPhotoInput, null);
            }
        }
        private void TxtMarketValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool success = int.TryParse(TxtMarketValue.Text, out _);
            if (string.IsNullOrWhiteSpace(TxtMarketValue.Text) || !success)
            {
                errorProvider.SetError(TxtMarketValue, "Please insert number");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtMarketValue, null);
            }
        }
        private void TxtDateFounded_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool success = DateTime.TryParse(TxtDateFounded.Text, out _);
            if (string.IsNullOrWhiteSpace(TxtDateFounded.Text) || !success)
            {
                errorProvider.SetError(TxtDateFounded, "Please insert date");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(TxtDateFounded, null);
            }
        }
        private void CmbCities_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CmbCities.SelectedIndex == 0 || CmbCities.SelectedIndex == -1)
            {
                errorProvider.SetError(CmbCities, "You need to select option from combo box");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(CmbCities, null);
            }
        }
        private void CmbLeagues_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (CmbLeagues.SelectedIndex == 0 || CmbLeagues.SelectedIndex == -1)
            {
                errorProvider.SetError(CmbLeagues, "You need to select option from combo box");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(CmbLeagues, null);
            }
        }
    }
}
