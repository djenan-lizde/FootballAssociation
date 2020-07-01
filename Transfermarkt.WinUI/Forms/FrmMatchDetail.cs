using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmMatchDetail : Form
    {
        private readonly APIService _aPIServiceMatches = new APIService("Matches");
        private readonly APIService _aPIServiceClubs = new APIService("Clubs");
        private readonly APIService _aPIServicePlayers = new APIService("Players");

        public int Id { get; set; }
        public int HomeClubId { get; set; }
        public int AwayClubId { get; set; }

        public FrmMatchDetail(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private async void FrmMatchDetail_Load(object sender, EventArgs e)
        {
            var match = await _aPIServiceMatches.GetById<Models.Match>(Id);
            if (match.IsFinished)
            {
                BtnMatchFinish.Visible = false;
                BtnNewEventMatch.Visible = false;
            }

            var homeClubLeague = await _aPIServiceClubs.GetById<ClubLeague>(match.HomeClubId, "ClubLeague");
            var awayClubLeague = await _aPIServiceClubs.GetById<ClubLeague>(match.AwayClubId, "ClubLeague");

            HomeClubId = homeClubLeague.ClubId;
            AwayClubId = awayClubLeague.ClubId;

            var homeClub = await _aPIServiceClubs.GetById<Club>(HomeClubId);
            var awayClub = await _aPIServiceClubs.GetById<Club>(AwayClubId);

            if (homeClub != null)
            {
                Image image = ByteArrayToImage(homeClub.Logo);
                var newImage = ResizeImage(image);
                pictureBox1.Image = newImage;
                HomeClubName.Text = homeClub.Name;
            }

            if (awayClub != null)
            {
                Image image = ByteArrayToImage(awayClub.Logo);
                var newImage = ResizeImage(image);
                pictureBox2.Image = newImage;
                AwayClubName.Text = awayClub.Name;
            }

            var matchDetails = await _aPIServiceMatches.GetById<List<MatchDetail>>(Id, "MatchDetail");
            if (matchDetails.Count == 0)
            {
                HomeClubGoal.Text = "0";
                AwayClubGoal.Text = "0";
                return;
            }

            //goals
            HomeClubGoal.Text = GetMatchDetails(matchDetails, homeClub.Id, 3).ToString();
            AwayClubGoal.Text = GetMatchDetails(matchDetails, awayClub.Id, 3).ToString();

            if (matchDetails.Count(x => int.Parse(x.ActionType.ToString()) == 3) > 0)
            {
                List<GoalScorer> goalScorers = new List<GoalScorer>();
                foreach (var item in matchDetails)
                {
                    var player = await _aPIServicePlayers.GetById<Player>(item.PlayerId);
                    var club = await _aPIServiceClubs.GetById<Club>(item.ClubId);
                    var goalscorer = new GoalScorer
                    {
                        ClubName = club.Name,
                        Minute = item.Minute,
                        PlayerFullName = $"{player.FirstName} {player.LastName}"
                    };
                    goalScorers.Add(goalscorer);
                }
                DgvGoalScorers.DataSource = goalScorers;
            }

            //cards
            if (matchDetails.Count(x => int.Parse(x.ActionType.ToString()) == 0 || int.Parse(x.ActionType.ToString()) == 1) != 0)
            {
                List<PlayersCards> cards = new List<PlayersCards>();
                foreach (var item in matchDetails)
                {
                    var player = await _aPIServicePlayers.GetById<Player>(item.PlayerId);
                    var club = await _aPIServiceClubs.GetById<Club>(item.ClubId);
                    var playerCard = new PlayersCards
                    {
                        ClubName = club.Name,
                        PlayerFullName = $"{player.FirstName} {player.LastName}",
                        Minute = item.Minute
                    };
                    if (item.ActionType == 0)
                        playerCard.Card = "Yellow card";
                    else
                        playerCard.Card = "Red card";
                    cards.Add(playerCard);
                }
                DgvPlayerCards.DataSource = cards;
            }

            //corners
            if (matchDetails.Count(x => int.Parse(x.ActionType.ToString()) == 2) != 0)
            {
                List<PlayersCorners> corners = new List<PlayersCorners>();
                foreach (var item in matchDetails)
                {
                    var player = await _aPIServicePlayers.GetById<Player>(item.PlayerId);
                    var club = await _aPIServiceClubs.GetById<Club>(item.ClubId);
                    var playerCorner = new PlayersCorners
                    {
                        ClubName = club.Name,
                        PlayerFullName = $"{player.FirstName} {player.LastName}",
                        Minute = item.Minute
                    };
                    corners.Add(playerCorner);
                }
                DgvCorners.DataSource = corners;
            }

            WindowState = FormWindowState.Maximized;
        }
        private int GetMatchDetails(List<MatchDetail> list, int clubId, int enumValue)
        {
            var clubStats = list.Count(x => x.ClubId == clubId
                && int.Parse(x.ActionType.ToString()) == enumValue);
            return int.Parse(clubStats.ToString());
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
        private void BtnNewEventMatch_Click(object sender, EventArgs e)
        {
            FrmNewMatchEvent frm = new FrmNewMatchEvent(Id);
            frm.Show();
            Close();
        }
        private async void BtnMatchFinish_Click(object sender, EventArgs e)
        {
            var match = await _aPIServiceMatches.GetById<Models.Match>(Id);
            var hours = int.Parse(match.GameEnd.Substring(0, 2));
            var minutes = int.Parse(match.GameEnd.Substring(3, 2));
            //provjeriti konverzije datuma kako bi mogao testirati

            if (DateTime.Now.Date >= match.DateGame.Date)
            {
                match.IsFinished = true;
                await _aPIServiceMatches.Update<Match>(match);

                var matchDetails = await _aPIServiceMatches.GetById<List<MatchDetail>>(Id, "MatchDetail");

                var homeClubGoals = matchDetails.Count(x => x.ClubId == HomeClubId
                    && int.Parse(x.ActionType.ToString()) == 5);

                var awayClubGoals = matchDetails.Count(x => x.ClubId == AwayClubId
                    && int.Parse(x.ActionType.ToString()) == 5);

                if (homeClubGoals > awayClubGoals)
                    UpdatePoints(HomeClubId);
                else if (awayClubGoals > homeClubGoals)
                    UpdatePoints(AwayClubId);
                else
                    UpdatePoints(HomeClubId, AwayClubId, true);

                BtnMatchFinish.Visible = false;
                BtnNewEventMatch.Visible = false;
            }
        }
        private async void UpdatePoints(int clubId, int? clubId2 = null, bool tie = false)
        {
            if (tie == false)
            {
                var clubLeaguePoints = await _aPIServiceClubs.GetById<ClubLeague>(clubId, "ClubPoints");
                clubLeaguePoints.Points += 3;
                await _aPIServiceClubs.Update<ClubLeague>(clubLeaguePoints, "ClubPoints");
            }
            else
            {
                var clubLeaguePointsHome = await _aPIServiceClubs.GetById<ClubLeague>(clubId, "ClubPoints");
                var clubLeaguePointsAway = await _aPIServiceClubs.GetById<ClubLeague>(clubId2, "ClubPoints");

                clubLeaguePointsHome.Points += 1;
                clubLeaguePointsAway.Points += 1;

                await _aPIServiceClubs.Update<ClubLeague>(clubLeaguePointsHome, "ClubPoints");
                await _aPIServiceClubs.Update<ClubLeague>(clubLeaguePointsAway, "ClubPoints");
            }
        }
    }
}
