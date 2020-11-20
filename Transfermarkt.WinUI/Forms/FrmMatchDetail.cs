using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Transfermarkt.Models;
using Transfermarkt.Models.Enums;
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
            try
            {
                var match = await _aPIServiceMatches.GetById<Matches>(Id);
                if (match.IsFinished)
                {
                    BtnMatchFinish.Visible = false;
                    BtnNewEventMatch.Visible = false;
                    BtnSimulate.Visible = false;
                }

                var homeClub = await _aPIServiceClubs.GetById<Clubs>(match.HomeClubId);
                var awayClub = await _aPIServiceClubs.GetById<Clubs>(match.AwayClubId);

                if (homeClub != null)
                {
                    HomeClubId = homeClub.Id;
                    Image image = ImageResizer.ByteArrayToImage(homeClub.Logo);
                    var newImage = ImageResizer.ResizeImage(image, 200, 200);
                    pictureBox1.Image = newImage;
                    HomeClubName.Text = homeClub.Name;
                }

                if (awayClub != null)
                {
                    AwayClubId = awayClub.Id;
                    Image image = ImageResizer.ByteArrayToImage(awayClub.Logo);
                    var newImage = ImageResizer.ResizeImage(image, 200, 200);
                    pictureBox2.Image = newImage;
                    AwayClubName.Text = awayClub.Name;
                }

                var matchDetails = await _aPIServiceMatches.GetById<List<MatchDetails>>(Id, "MatchDetail");
                if (matchDetails.Count == 0)
                {
                    HomeClubGoal.Text = "0";
                    AwayClubGoal.Text = "0";
                    return;
                }

                //goals
                if (matchDetails.Count(x => x.ActionType == (int)Enums.ActionType.Goal) > 0)
                {
                    HomeClubGoal.Text = matchDetails.Count(x => x.ClubId == homeClub.Id && x.ActionType == (int)Enums.ActionType.Goal).ToString();
                    AwayClubGoal.Text = matchDetails.Count(x => x.ClubId == awayClub.Id && x.ActionType == (int)Enums.ActionType.Goal).ToString();
                    List<GoalScorer> goalScorers = new List<GoalScorer>();
                    foreach (var item in matchDetails.Where(x => x.ActionType == (int)Enums.ActionType.Goal))
                    {
                        var player = await _aPIServicePlayers.GetById<Players>(item.PlayerId);
                        var club = await _aPIServiceClubs.GetById<Clubs>(item.ClubId);
                        goalScorers.Add(new GoalScorer
                        {
                            ClubName = club.Name,
                            Minute = item.Minute,
                            PlayerFullName = $"{player.FirstName} {player.LastName}"
                        });
                    }
                    DgvGoalScorers.DataSource = goalScorers;
                }
                else
                {
                    HomeClubGoal.Text = "0";
                    AwayClubGoal.Text = "0";
                }

                //cards
                if ((matchDetails.Count(x => x.ActionType == (int)Enums.ActionType.YellowCard) > 0)
                    || (matchDetails.Count(x => x.ActionType == (int)Enums.ActionType.RedCard) > 0))
                {
                    List<PlayersCards> cards = new List<PlayersCards>();
                    foreach (var item in matchDetails.Where(x => x.ActionType == (int)Enums.ActionType.YellowCard || x.ActionType == (int)Enums.ActionType.RedCard))
                    {
                        var player = await _aPIServicePlayers.GetById<Players>(item.PlayerId);
                        var club = await _aPIServiceClubs.GetById<Clubs>(item.ClubId);
                        var playerCard = new PlayersCards
                        {
                            ClubName = club.Name,
                            PlayerFullName = $"{player.FirstName} {player.LastName}",
                            Minute = item.Minute
                        };
                        if (item.ActionType == (int)Enums.ActionType.YellowCard)
                            playerCard.Card = "Yellow card";
                        else
                            playerCard.Card = "Red card";
                        cards.Add(playerCard);
                    }
                    DgvPlayerCards.DataSource = cards;
                }

                //corners
                if (matchDetails.Count(x => x.ActionType == (int)Enums.ActionType.CornerOccurred) > 0)
                {
                    List<PlayersCorners> corners = new List<PlayersCorners>();
                    foreach (var item in matchDetails.Where(x => x.ActionType == (int)Enums.ActionType.CornerOccurred))
                    {
                        var player = await _aPIServicePlayers.GetById<Players>(item.PlayerId);
                        var club = await _aPIServiceClubs.GetById<Clubs>(item.ClubId);
                        corners.Add(new PlayersCorners
                        {
                            ClubName = club.Name,
                            PlayerFullName = $"{player.FirstName} {player.LastName}",
                            Minute = item.Minute
                        });
                    }
                    DgvCorners.DataSource = corners;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
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
            var match = await _aPIServiceMatches.GetById<Matches>(Id);

            match.IsFinished = true;
            var updatedMatch = await _aPIServiceMatches.Update<Matches>(match, match.Id.ToString());

            UpdatePoints(updatedMatch);

            BtnMatchFinish.Visible = false;
            BtnNewEventMatch.Visible = false;
            BtnSimulate.Visible = false;

            MessageBox.Show("Match finished.", "Information", MessageBoxButtons.OK);
        }

        private async void BtnSimulate_Click(object sender, EventArgs e)
        {
            //random number of events
            Random random = new Random();
            int num = random.Next(1, 10);

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
            var updatedMatch = await _aPIServiceMatches.Update<Matches>(match, match.Id.ToString());
            UpdatePoints(updatedMatch);

            MessageBox.Show("Match simulated", "Information");
            FrmMatchDetail frm = new FrmMatchDetail(Id);
            frm.Show();
            Close();
        }
        private async void UpdatePoints(Matches match)
        {
            var matchDetails = await _aPIServiceMatches.GetById<List<MatchDetails>>(Id, "MatchDetail");

            //counting goals
            var homeClubGoals = matchDetails.Count(x => x.ClubId == HomeClubId
                && x.ActionType == (int)Enums.ActionType.Goal);

            var awayClubGoals = matchDetails.Count(x => x.ClubId == AwayClubId
                && x.ActionType == (int)Enums.ActionType.Goal);

            if (homeClubGoals > awayClubGoals)
            {
                var clubLeaguePoints = await _aPIServiceClubs.GetById<ClubsLeague>(match.HomeClubId, "ClubPoints");
                clubLeaguePoints.Points += 3;
                await _aPIServiceClubs.Update<ClubsLeague>(clubLeaguePoints, clubLeaguePoints.Id.ToString(), "ClubPoints");
            }
            else if (awayClubGoals > homeClubGoals)
            {
                var clubLeaguePoints = await _aPIServiceClubs.GetById<ClubsLeague>(match.AwayClubId, "ClubPoints");
                clubLeaguePoints.Points += 3;
                await _aPIServiceClubs.Update<ClubsLeague>(clubLeaguePoints, clubLeaguePoints.Id.ToString(), "ClubPoints");
            }
            else
            {
                var clubLeaguePointsHome = await _aPIServiceClubs.GetById<ClubsLeague>(match.HomeClubId, "ClubPoints");
                var clubLeaguePointsAway = await _aPIServiceClubs.GetById<ClubsLeague>(match.AwayClubId, "ClubPoints");

                clubLeaguePointsHome.Points += 1;
                clubLeaguePointsAway.Points += 1;

                await _aPIServiceClubs.Update<ClubsLeague>(clubLeaguePointsHome, clubLeaguePointsHome.Id.ToString(), "ClubPoints");
                await _aPIServiceClubs.Update<ClubsLeague>(clubLeaguePointsAway, clubLeaguePointsHome.Id.ToString(), "ClubPoints");
            }
        }
    }
}
