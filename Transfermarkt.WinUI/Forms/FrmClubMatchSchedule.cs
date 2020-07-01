using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmClubMatchSchedule : Form
    {
        private readonly APIService _apiServiceMatches = new APIService("Matches");
        private readonly APIService _apiServiceClubs = new APIService("Clubs");

        public int? Id { get; set; }

        public FrmClubMatchSchedule(int? id = null)
        {
            InitializeComponent();
            Id = id;
        }

        private async void FrmClubMatchSchedule_Load(object sender, EventArgs e)
        {
            var club = await _apiServiceClubs.GetById<Club>(Id); //12
            var clubLeague = await _apiServiceClubs.GetById<ClubLeague>(club.Id, "ClubPoints"); //12

            var clubMatches = await _apiServiceMatches.GetById<List<Match>>(clubLeague.Id, "ClubMatches"); //8
            List<MatchSchedule> list = new List<MatchSchedule>();
            foreach (var item in clubMatches.OrderBy(x => x.DateGame))
            {
                var matchDetails = await _apiServiceMatches.GetById<List<MatchDetail>>(item.Id, "MatchDetail");
                var homeClubLeague = await _apiServiceClubs.GetById<ClubLeague>(item.HomeClubId, "ClubLeague");
                var awayClubLeague = await _apiServiceClubs.GetById<ClubLeague>(item.AwayClubId, "ClubLeague");
                var homeClub = await _apiServiceClubs.GetById<Club>(homeClubLeague.ClubId);
                var awayClub = await _apiServiceClubs.GetById<Club>(awayClubLeague.ClubId);
                var matchSchedule = new MatchSchedule
                {
                    GameDate = item.DateGame,
                    Id = item.Id
                };
                if (matchDetails == null)
                {
                    matchSchedule.MatchGame = $"{homeClub.Name} - vs - {awayClub.Name}";
                }
                else
                {
                    var homeClubGoals = matchDetails.Count(x => x.ClubId == homeClub.Id);
                    var awayClubGoals = matchDetails.Count(x => x.ClubId == awayClub.Id);
                    matchSchedule.MatchGame = $"{homeClub.Name} {homeClubGoals} vs {awayClubGoals} {awayClub.Name}";
                }
                list.Add(matchSchedule);
            }
            LblClubName.Text = club.Name;
            Image image = ByteArrayToImage(club.Logo);
            var newImage = ResizeImage(image);
            PicBoxLogoClub.Image = newImage;
            DgvMatches.DataSource = list;
        }
        private static Image ResizeImage(Image image)
        {
            var size = new Size(150, 150);
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
    }
}
