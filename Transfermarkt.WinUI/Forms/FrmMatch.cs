using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Transfermarkt.Models;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmMatch : Form
    {
        private readonly APIService _aPIServiceStadium = new APIService("Stadiums");
        private readonly APIService _aPIServiceClub = new APIService("Clubs");
        private readonly APIService _aPIServiceMatch = new APIService("Matches");
        private readonly APIService _aPIServiceReferee = new APIService("Referee");

        private int StadiumId { get; set; }
        private IEnumerable<ClubLeague> ClubLeagues { get; set; }

        public FrmMatch()
        {
            InitializeComponent();
        }
        private async void FrmMatch_Load(object sender, EventArgs e)
        {
            var clubs = await _aPIServiceClub.Get<List<Club>>();
            var clubs1 = await _aPIServiceClub.Get<List<Club>>();

            ClubLeagues = await _aPIServiceClub.Get<List<ClubLeague>>(null, "ClubLeague");

            //pogledat neko drugo rjesenje
            CmbHomeClub.DataSource = clubs;
            CmbHomeClub.DisplayMember = "Name";
            CmbHomeClub.ValueMember = "Id";

            CmbAwayClub.DataSource = clubs1;
            CmbAwayClub.DisplayMember = "Name";
            CmbAwayClub.ValueMember = "Id";

            var referees = await _aPIServiceReferee.Get<List<Referee>>();
            CmbReferees.DataSource = referees;
            //dodat ime i prezime da prikazujes
            CmbReferees.DisplayMember = "FirstName";
            CmbReferees.ValueMember = "Id";

            TxtStadium.Text = "Home stadium will load automatically.";

        }
        private async void CmbHomeClub_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var clubId = int.Parse(CmbHomeClub.SelectedValue.ToString());
            var homeClub = await _aPIServiceClub.GetById<Club>(clubId);

            if (homeClub != null)
            {
                Image image = ByteArrayToImage(homeClub.Logo);
                var newImage = ResizeImage(image);
                pictureBox1.Image = newImage;
            }

            var homeStadium = await _aPIServiceStadium.GetById<Stadium>(homeClub.Id, "HomeStadium");
            if (homeStadium == null)
            {
                TxtStadium.Text = "Home club doesn't have home stadium.";
                return;
            }
            StadiumId = homeStadium.Id;
            TxtStadium.Text = homeStadium.Name;
        }
        private async void CmbAwayClub_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var clubId = int.Parse(CmbAwayClub.SelectedValue.ToString());
            var awayClub = await _aPIServiceClub.GetById<Club>(clubId);

            if (awayClub != null)
            {
                Image image = ByteArrayToImage(awayClub.Logo);
                var newImage = ResizeImage(image);
                pictureBox2.Image = newImage;
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
        private static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream mStream = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(mStream);
            }
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            var gameEnd = (int.Parse(TxtMatchStart.Text.Substring(0, 2)) + 2).ToString() + TxtMatchStart.Text.Substring(2, 3);
            var homeClub = ClubLeagues.LastOrDefault(x => x.ClubId == int.Parse(CmbHomeClub.SelectedValue.ToString()));
            var awayClub = ClubLeagues.LastOrDefault(x => x.ClubId == int.Parse(CmbAwayClub.SelectedValue.ToString()));

            var match = new Match
            {
                AwayClubId = awayClub.Id,
                HomeClubId = homeClub.Id,
                DateGame = DateTime.Parse(TxtDateGame.Text),
                IsFinished = false,
                StadiumId = StadiumId,
                GameStart = TxtMatchStart.Text,
                GameEnd = gameEnd
            };
            await _aPIServiceMatch.Insert<Match>(match);

            var matches = await _aPIServiceMatch.Get<List<Match>>();
            var lastMatch = matches.LastOrDefault();

            var refereeMatch = new RefereeMatch
            {
                RefereeId = int.Parse(CmbReferees.SelectedValue.ToString()),
                MatchId = lastMatch.Id
            };
            await _aPIServiceMatch.Insert<RefereeMatch>(refereeMatch, "RefereeMatch");
        }
    }
}
