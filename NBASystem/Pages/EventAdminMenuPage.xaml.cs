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
    /// Логика взаимодействия для EventAdminMenuPage.xaml
    /// </summary>
    public partial class EventAdminMenuPage : Page
    {
        public EventAdminMenuPage()
        {
            InitializeComponent();
        }

        private void BManage_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BSeason_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManageSeasonsPages());
        }

        private void BMatchups_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManageMatchupsPages());
        }

        private void BTeams_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManageTeamsPages());
        }

        private void BPlayers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ManagePalayrsPages());
        }
    }
}
