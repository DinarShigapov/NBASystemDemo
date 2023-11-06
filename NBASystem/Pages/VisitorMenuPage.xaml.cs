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
    /// Логика взаимодействия для VisitorMenuPage.xaml
    /// </summary>
    public partial class VisitorMenuPage : Page
    {
        public VisitorMenuPage()
        {
            InitializeComponent();
        }

        private void BPhotos_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PhotosPage());
        }

        private void BMatchups_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MatchupListPage());
        }

        private void BPlayers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlayersMainPage());
        }

        private void BTeams_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeamsMainPage());
        }
    }
}
