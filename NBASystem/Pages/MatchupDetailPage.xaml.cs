using NBASystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NBASystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для MatchupDetailPage.xaml
    /// </summary>
    public partial class MatchupDetailPage : Page
    {
        Matchup contextMatch;
        public MatchupDetailPage(Matchup matchup)
        {
            InitializeComponent();
            contextMatch = matchup;
            FGMAway.Text = GetFGMade(matchup.Team);
            FGMHome.Text = GetFGMade(matchup.Team1);
            PTAway.Text = GetPTMade(matchup.Team);
            PTHome.Text = GetPTMade(matchup.Team1);
            FTAway.Text = GetFTMade(matchup.Team);
            FTHome.Text = GetFTMade(matchup.Team1);
            AssistsAway.Text = GetAssits(matchup.Team);
            AssistsHome.Text = GetAssits(matchup.Team1);
            StealsAway.Text = GetSteal(matchup.Team);
            StealsHome.Text = GetSteal(matchup.Team1);
            BlockAway.Text = GetBlock(matchup.Team);
            BlockHome.Text = GetBlock(matchup.Team1);
            TurnoversAway.Text = GetTurn(matchup.Team);
            TurnoversHome.Text = GetTurn(matchup.Team1);
            Tb1TFirst.Text = GetQuarterAway(1);
            TB1TWAS.Text = GetQuarterHome(1);
            Tb2TFirst.Text = GetQuarterAway(2);
            TB2TWAS.Text = GetQuarterHome(2);
            Tb3TFirst.Text = GetQuarterAway(3);
            TB3TWAS.Text = GetQuarterHome(3);
            Tb4TFirst.Text = GetQuarterAway(4); 
            TB4TWAS.Text = GetQuarterHome(4);
            TbTFirst.Text = contextMatch.MatchupDetail.Sum(x => x.Team_Away_Score).ToString();
            TBTWAS.Text = contextMatch.MatchupDetail.Sum(x => x.Team_Home_Score).ToString();
            DataContext = contextMatch;

        }

        public string GetQuarterAway(int i) 
        {
            return contextMatch.MatchupDetail.FirstOrDefault(x => x.Quarter == i).Team_Away_Score.ToString();
        }

        public string GetQuarterHome(int i)
        {
            return contextMatch.MatchupDetail.FirstOrDefault(x => x.Quarter == i).Team_Home_Score.ToString();
        }


        private string GetFGMade(Team team)
        {
            var result = App.DB.PlayerStatistics.Where(x => x.MatchupId == contextMatch.Id && team.Id == x.TeamId).ToList();
            int fgMade = result.Select(x => x.FieldGoalMade).Sum();
            int fgMissed = result.Select(x => x.FieldGoalMissed).Sum();
            return $"{fgMade} - {fgMissed}";
        }

        private string GetPTMade(Team team)
        {
            var result = App.DB.PlayerStatistics.Where(x => x.MatchupId == contextMatch.Id && team.Id == x.TeamId).ToList();
            int fgMade = result.Select(x => x.FreeThrowMade).Sum();
            int fgMissed = result.Select(x => x.FreeThrowMissed).Sum();
            return $"{fgMade} - {fgMissed}";
        }

        private string GetFTMade(Team team)
        {
            var result = App.DB.PlayerStatistics.Where(x => x.MatchupId == contextMatch.Id && team.Id == x.TeamId).ToList();
            int fgMade = result.Select(x => x.OFFR).Sum();
            int fgMissed = result.Select(x => x.DFFR).Sum();
            return $"{fgMade} - {fgMissed}";
        }

        private string GetAssits(Team team)
        {
            var result = App.DB.PlayerStatistics.Where(x => x.MatchupId == contextMatch.Id && team.Id == x.TeamId).Sum(x => x.Assist);
            return $"{result}";
        }

        private string GetSteal(Team team)
        {
            var result = App.DB.PlayerStatistics.Where(x => x.MatchupId == contextMatch.Id && team.Id == x.TeamId).Sum(x => x.Steal);
            return $"{result}";
        }

        private string GetBlock(Team team)
        {
            var result = App.DB.PlayerStatistics.Where(x => x.MatchupId == contextMatch.Id && team.Id == x.TeamId).Sum(x => x.Block);
            return $"{result}";
        }

        private string GetTurn(Team team)
        {
            var result = App.DB.PlayerStatistics.Where(x => x.MatchupId == contextMatch.Id && team.Id == x.TeamId).Sum(x => x.Turnover);
            return $"{result}";
        }

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
