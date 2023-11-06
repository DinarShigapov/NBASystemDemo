using NBASystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для TeamDetailPage.xaml
    /// </summary>
    public partial class TeamDetailPage : Page
    {
        Team contextTeam;
        public TeamDetailPage(Team team, int tab)
        {
            InitializeComponent();
            TBMain.SelectedIndex = tab;
            List<Season> seasons = new List<Season>() { new Season { Name = "All" } };
            seasons.AddRange(App.DB.Season.ToList());
            CBYear.ItemsSource = seasons.ToList();
            CBYear.SelectedIndex = 0;

            contextTeam = team;
            DataContext = contextTeam;
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Update();
            
        }

        private void Update() 
        {
            if (CBYear.SelectedIndex != 0)
            {
                DGMatchup.ItemsSource = App.DB.Matchup.Where(x => x.Team_Home == contextTeam.Id && x.SeasonId == CBYear.SelectedIndex).ToList();
                DGRoster.ItemsSource = App.DB.PlayerInTeam.Where(x => x.TeamId == contextTeam.Id && x.SeasonId == CBYear.SelectedIndex).ToList();


                LVPF.ItemsSource = GetPlayersByPosition(2);
                LVSG.ItemsSource = GetPlayersByPosition(4);
                LVC.ItemsSource = GetPlayersByPosition(3);
                LVSF.ItemsSource = GetPlayersByPosition(1);
                LVPG.ItemsSource = GetPlayersByPosition(5);
            }
            else
            {
                DGRoster.ItemsSource = App.DB.PlayerInTeam.Where(x => x.TeamId == contextTeam.Id).ToList();
                DGMatchup.ItemsSource = App.DB.Matchup.Where(x => x.Team_Home == contextTeam.Id).ToList();

                LVPF.ItemsSource = GetPlayersByPosition(2);
                LVSG.ItemsSource = GetPlayersByPosition(4);
                LVC.ItemsSource = GetPlayersByPosition(3);
                LVSF.ItemsSource = GetPlayersByPosition(1);
                LVPG.ItemsSource = GetPlayersByPosition(5);
            }
        }

        private List<Player> GetPlayersByPosition(int positionId)
        {
            if (CBYear.SelectedIndex == 0)
            {
                return App.DB.PlayerInTeam
                .Where(x => x.TeamId == contextTeam.Id)
                .Select(x => x.Player)
                .Where(z => z.PositionId == positionId)
                .ToList();
            }
            else
            {
                return App.DB.PlayerInTeam
                .Where(x => x.TeamId == contextTeam.Id && x.SeasonId == (CBYear.SelectedIndex))
                .Select(x => x.Player)
                .Where(z => z.PositionId == positionId)
                .ToList();
            }
            
        }
    }
}
