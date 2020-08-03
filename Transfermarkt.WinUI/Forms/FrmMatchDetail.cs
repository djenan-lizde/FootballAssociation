using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using Transfermarkt.WinUI.Helper;

namespace Transfermarkt.WinUI.Forms
{
    public partial class FrmMatchDetail : Form
    {
        private readonly APIService _aPIServiceMatches = new APIService("Matches");
        private readonly APIService _aPIServiceClubs = new APIService("Clubs");
        private readonly APIService _aPIServicePlayers = new APIService("Players");
        private readonly APIService _aPIServiceContracts = new APIService("Contracts");

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
            var match = await _aPIServiceMatches.GetById<Matches>(Id);
            if (match.IsFinished)
            {
                BtnMatchFinish.Visible = false;
                BtnNewEventMatch.Visible = false;
            }

            var homeClub = await _aPIServiceClubs.GetById<Clubs>(match.HomeClubId);
            var awayClub = await _aPIServiceClubs.GetById<Clubs>(match.AwayClubId);

            HomeClubId = homeClub.Id;
            AwayClubId = awayClub.Id;

            if (homeClub != null)
            {
                Image image = ImageResizer.ByteArrayToImage(homeClub.Logo);
                var newImage = ImageResizer.ResizeImage(image, 200, 200);
                pictureBox1.Image = newImage;
                HomeClubName.Text = homeClub.Name;
            }

            if (awayClub != null)
            {
                Image image = ImageResizer.ByteArrayToImage(awayClub.Logo);
                var newImage = ImageResizer.ResizeImage(image, 200, 200);
                pictureBox2.Image = newImage;
                AwayClubName.Text = awayClub.Name;
            }

            var matchDetails = await _aPIServiceMatches.GetById<List<MatchDetails>>(Id, "MatchDetail");
            if (matchDetails.Count() == 0)
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
                    var player = await _aPIServicePlayers.GetById<Players>(item.PlayerId);
                    var club = await _aPIServiceClubs.GetById<Clubs>(item.ClubId);
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
            if ((matchDetails.Count(x => int.Parse(x.ActionType.ToString()) == 0) > 0)
                || (matchDetails.Count(x => int.Parse(x.ActionType.ToString()) == 1) > 0))
            {
                List<PlayersCards> cards = new List<PlayersCards>();
                foreach (var item in matchDetails)
                {
                    var player = await _aPIServicePlayers.GetById<Players>(item.PlayerId);
                    var club = await _aPIServiceClubs.GetById<Clubs>(item.ClubId);
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
                    var player = await _aPIServicePlayers.GetById<Players>(item.PlayerId);
                    var club = await _aPIServiceClubs.GetById<Clubs>(item.ClubId);
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
        private int GetMatchDetails(List<MatchDetails> list, int clubId, int enumValue)
        {
            var clubStats = list.Count(x => x.ClubId == clubId
                && int.Parse(x.ActionType.ToString()) == enumValue);
            return int.Parse(clubStats.ToString());
        }
        private void BtnNewEventMatch_Click(object sender, EventArgs e)
        {
            FrmNewMatchEvent frm = new FrmNewMatchEvent(Id);
            frm.Show();
            Close();
        }
        private async void BtnMatchFinish_Click(object sender, EventArgs e)
        {
            var match = await _aPIServiceMatches.GetById<Matches>(Id);
            var hours = int.Parse(match.GameEnd.Substring(0, 2));
            var minutes = int.Parse(match.GameEnd.Substring(3, 2));

            if (DateTime.Now.Date >= match.DateGame.Date)
            {
                match.IsFinished = true;
                await _aPIServiceMatches.Update<Matches>(match, match.Id.ToString());

                var matchDetails = await _aPIServiceMatches.GetById<List<MatchDetails>>(Id, "MatchDetail");

                //counting goals
                var homeClubGoals = matchDetails.Count(x => x.ClubId == HomeClubId
                    && int.Parse(x.ActionType.ToString()) == 3);

                var awayClubGoals = matchDetails.Count(x => x.ClubId == AwayClubId
                    && int.Parse(x.ActionType.ToString()) == 3);

                if (homeClubGoals > awayClubGoals)
                    UpdatePoints(HomeClubId);
                else if (awayClubGoals > homeClubGoals)
                    UpdatePoints(AwayClubId);
                else
                    UpdatePoints(HomeClubId, AwayClubId, true);

                BtnMatchFinish.Visible = false;
                BtnNewEventMatch.Visible = false;
            }
            else
            {
                MessageBox.Show("Match is not finished.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private async void UpdatePoints(int clubId, int? clubId2 = null, bool tie = false)
        {
            if (tie == false)
            {
                var clubLeaguePoints = await _aPIServiceClubs.GetById<ClubsLeague>(clubId, "ClubPoints");
                clubLeaguePoints.Points += 3;
                await _aPIServiceClubs.Update<ClubsLeague>(clubLeaguePoints, clubLeaguePoints.Id.ToString(), "ClubPoints");
            }
            else
            {
                var clubLeaguePointsHome = await _aPIServiceClubs.GetById<ClubsLeague>(clubId, "ClubPoints");
                var clubLeaguePointsAway = await _aPIServiceClubs.GetById<ClubsLeague>(clubId2, "ClubPoints");

                clubLeaguePointsHome.Points += 1;
                clubLeaguePointsAway.Points += 1;

                await _aPIServiceClubs.Update<ClubsLeague>(clubLeaguePointsHome, clubLeaguePointsHome.Id.ToString(), "ClubPoints");
                await _aPIServiceClubs.Update<ClubsLeague>(clubLeaguePointsAway, clubLeaguePointsHome.Id.ToString(), "ClubPoints");
            }
        }

        private async void BtnSimulate_Click(object sender, EventArgs e)
        {
            //random number of events
            Random random = new Random();
            int num = random.Next(1,10);

            var homePlayers = await _aPIServiceContracts.GetById<List<Contracts>>(HomeClubId, "ClubContracts");
            var awayPlayers = await _aPIServiceContracts.GetById<List<Contracts>>(AwayClubId, "ClubContracts");

            for (int i = 1; i <= num; i++)
            {
                var matchDetail = new MatchDetails
                {
                    ActionType = random.Next(1, 4),
                    MatchId = Id,
                    Minute = random.Next(1, 95)
                };
                if (i % 2 == 0)
                {
                    matchDetail.ClubId = HomeClubId;
                    var index = random.Next(homePlayers.Count());
                    matchDetail.PlayerId = homePlayers[index].PlayerId;
                }
                else
                {
                    matchDetail.ClubId = AwayClubId;
                    var index = random.Next(awayPlayers.Count());
                    matchDetail.PlayerId = awayPlayers[index].PlayerId;
                }
                await _aPIServiceMatches.Insert<MatchDetails>(matchDetail, "NewDetailMatch");
            }
            BtnMatchFinish.Visible = false;
            BtnNewEventMatch.Visible = false;
            BtnSimulate.Visible = false;
            var match = await _aPIServiceMatches.GetById<Matches>(Id);
            match.IsFinished = true;
            await _aPIServiceMatches.Update<Matches>(match, match.Id.ToString());
            MessageBox.Show("Match simulated", "Information");
            FrmMatchDetail frm = new FrmMatchDetail(Id);
            frm.Show();
            Close();
        }
    }
}
