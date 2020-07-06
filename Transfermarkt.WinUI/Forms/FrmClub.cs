using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;

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
        readonly Club club = new Club();

        public FrmClub(int? id = null)
        {
            InitializeComponent();
            Id = id;
        }
        private async void FrmInsertClub_Load(object sender, EventArgs e)
        {
            var resultCity = await _aPIServiceCity.Get<List<City>>();

            CmbCities.DataSource = resultCity;
            CmbCities.DisplayMember = "Name";
            CmbCities.ValueMember = "Id";

            var resultLeague = await _aPIServiceLeague.Get<List<League>>();

            CmbLeagues.DataSource = resultLeague;
            CmbLeagues.DisplayMember = "Name";
            CmbLeagues.ValueMember = "Id";

            if (Id.HasValue)
            {
                var clubLoad = await _aPIServiceClub.GetById<Club>(Id);
                txtAbbreviation.Text = clubLoad.Abbreviation;
                txtClubName.Text = clubLoad.Name;
                txtDateFounded.Text = clubLoad.Founded.ToString();
                txtMarketValue.Text = clubLoad.MarketValue.ToString();
                txtNickname.Text = clubLoad.Nickname;
                CmbCities.SelectedIndex = clubLoad.CityId - 1;
                CmbLeagues.Enabled = false;
                if (clubLoad.Logo != null)
                {
                    Image image = ByteArrayToImage(clubLoad.Logo);
                    var newImage = ResizeImage(image);
                    pictureBox1.Image = newImage;
                }
                label9.Visible = true;
                DgvPlayers.Visible = true;
                BtnMatchSchedule.Visible = true;
                var contracts = await _aPIServiceContract.GetById<List<Contract>>(Id, "ClubContracts");
                List<PlayersClub> playersClubs = new List<PlayersClub>();
                foreach (var item in contracts)
                {
                    var playerInDb = await _aPIServicePlayer.GetById<Player>(item.PlayerId);
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
        private static Image ResizeImage(Image image)
        {
            var size = new Size(200, 200);
            Image newImage = new Bitmap(image, size);
            using (Graphics graphics = Graphics.FromImage((Bitmap)newImage))
            {
                graphics.DrawImage(image, new Rectangle(Point.Empty, size));
            }
            return newImage;
        }
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }
        private async void BtnSaveClub_Click(object sender, EventArgs e)
        {
            club.MarketValue = int.Parse(txtMarketValue.Text);
            club.Name = txtClubName.Text;
            club.Nickname = txtNickname.Text;
            club.CityId = int.Parse(CmbCities.SelectedValue.ToString());
            club.Founded = DateTime.Parse(txtDateFounded.Text.ToString());
            club.Abbreviation = txtAbbreviation.Text;
            club.Id = Id ?? 0;

            if (Id.HasValue)
            {
                var clubInDb = await _aPIServiceClub.GetById<Club>(club.Id);
                club.Logo = clubInDb.Logo;
                await _aPIServiceClub.Update<Club>(club);
                MessageBox.Show("Successfully updated.", "Club update");
            }
            else
            {
                await _aPIServiceClub.Insert<Club>(club);
                MessageBox.Show("Successfully added. You can click assign stadium button for" +
                    " adding stadium!", "Club add");
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
                txtPhotoInput.Text = fileName;

                Image image = Image.FromFile(fileName);
                Image newImage = ResizeImage(image);
                pictureBox1.Image = newImage;
            }
        }
        private async void BtnAddStadium_Click(object sender, EventArgs e)
        {
            var clubs = await _aPIServiceClub.Get<List<Club>>();
            var clubStadium = clubs.Find(x => x.Name == club.Name);

            if (Id.HasValue)
            {
                var clubInDb = await _aPIServiceClub.GetById<Club>(Id);
                FrmStadium frm = new FrmStadium(clubInDb.Id, clubInDb.Name);
                frm.Show();
            }
            else if (clubStadium != null && clubStadium.Id != 0)
            {
                FrmStadium frm = new FrmStadium(clubStadium.Id, clubStadium.Name);
                frm.Show();
            }
            else
            {
                MessageBox.Show("You need to insert new club" +
                    " to be able to assing stadium!", "Error");
            }
        }
        private void BtnMatchSchedule_Click(object sender, EventArgs e)
        {
            FrmClubMatchSchedule frm = new FrmClubMatchSchedule(Id);
            frm.Show();
        }
    }
}
