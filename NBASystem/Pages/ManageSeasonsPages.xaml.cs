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
    /// Логика взаимодействия для ManageSeasonsPages.xaml
    /// </summary>
    public partial class ManageSeasonsPages : Page
    {
        public ManageSeasonsPages()
        {
            InitializeComponent();
            List<Season> seasonList = new List<Season> { new Season { Name = "All" } };
            seasonList.AddRange(App.DB.Season);
            CbSeason.ItemsSource = seasonList.ToList();
            CbSeason.SelectedIndex = 0;

            List<MatchupType> matchupsList = new List<MatchupType> { new MatchupType { Name = "All" } };
            matchupsList.AddRange(App.DB.MatchupType);
            CbType.ItemsSource = matchupsList.ToList();
            CbType.SelectedIndex = 0;
        }


        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {

            IEnumerable<Matchup> matchups = App.DB.Matchup.ToList();

            if (CbSeason.SelectedIndex != 0)
            {
                matchups = matchups.Where(x => x.Season == CbSeason.SelectedItem);
            }
            if (CbType.SelectedIndex != 0) 
            {
                matchups = matchups.Where(x => x.MatchupType == CbType.SelectedItem);
            }
            DGMatch.ItemsSource = matchups.ToList();
            DGMatchState.ItemsSource = matchups.ToList();
        }
    }
}
