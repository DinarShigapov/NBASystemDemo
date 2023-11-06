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
    /// Логика взаимодействия для ManageMatchupsPages.xaml
    /// </summary>
    public partial class ManageMatchupsPages : Page
    {
        private List<Matchup> players = new List<Matchup>();
        public ManageMatchupsPages()
        {
            InitializeComponent();
        
            var conference = new List<Season> { new Season { Name = "All" } };
            conference.AddRange(App.DB.Season);
            CbSeasonStart.ItemsSource = conference.ToList();
            CbSeasonStart.SelectedIndex = 0;
            CbSeasonEnd.SelectedDate = DateTime.Now;
            if (CCheckBox.IsChecked == false)
            {
                CbSeasonEnd.IsEnabled = false;
            }
          
        }

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            players = App.DB.Matchup.ToList();

            if (CbSeasonStart.SelectedIndex != 0)
            {
                List<PlayerInTeam> playerInTeams = App.DB.PlayerInTeam.ToList();
                playerInTeams = playerInTeams.Where(x => x.SeasonId == CbSeasonStart.SelectedIndex).ToList();

                players = (List<Matchup>)players.Where(x => x.Season == CbSeasonStart.SelectedValue).ToList();
            }
            if (CCheckBox.IsChecked == true)
            {
                if (CbSeasonEnd.SelectedDate != null)
                {

                    players = (List<Matchup>)players.Where(x => x.Starttime == (DateTime)CbSeasonEnd.SelectedDate.Value).ToList();
                }
            }
            DGMatch.ItemsSource = players;
            DGMatchResult.ItemsSource = players;

        }

        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BAddNew_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddNewMuthupPages());
        }

        private void BExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(CCheckBox.IsChecked == false)
            {
                CbSeasonEnd.IsEnabled = false;
            }
            else
            {
                CCheckBox.IsEnabled = true;
            }
        }
    }
}
