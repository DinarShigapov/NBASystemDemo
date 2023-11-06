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
    /// Логика взаимодействия для ManageTeamsPages.xaml
    /// </summary>
    public partial class ManageTeamsPages : Page
    {
        List<Conference> conferences; 
        public ManageTeamsPages()
        {
            InitializeComponent();
            var conference = new List<Conference> { new Conference { Name = "All" } };
            conference.AddRange(App.DB.Conference);
            CBConference.ItemsSource = conference.ToList();
            conferences = conference;
            CBConference.SelectedIndex = 0;

        }

        private void BAddTeam_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CBConference_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBConference.SelectedIndex != 0)
            {
                CBDivision.IsEnabled = false;
                CBDivision.ItemsSource = conferences.Select(x => x.Division).ToList();
            }
            else
            {
                CBDivision.IsEnabled = true;
            }
        }
    }
}
