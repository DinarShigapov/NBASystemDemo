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
    /// Логика взаимодействия для PlayersMainPage.xaml
    /// </summary>
    public partial class PlayersMainPage : Page
    {
        private int countInPage = 4;
        private int MaxPageCount;
        private int currentPage = 1;

        private List<Player> players = new List<Player>();
        List<string> alphabet;

        public PlayersMainPage()
        {
            InitializeComponent();
            List<Season> seasons = new List<Season>() { new Season { Name = "All" } };
            seasons.AddRange(App.DB.Season.ToList());
            List<Team> Teams = new List<Team>() { new Team { TeamName = "All" } };
            Teams.AddRange(App.DB.Team.ToList());

            CBYear.ItemsSource = seasons.ToList();
            CBTeam.ItemsSource = Teams.ToList();
            alphabet = new List<string>();
            alphabet.Add("ALL");
            for (char i = 'A'; i <= 'Z'; i++)
            {
                alphabet.Add(i.ToString());
            }
            LVAlphabet.ItemsSource = alphabet.ToList();
            LVAlphabet.SelectedIndex = 0;
            CBTeam.SelectedIndex = 0;
            CBYear.SelectedIndex = 0;
            Refresh();
        }


        private void Refresh()
        {
            currentPage = 1;

            players = App.DB.Player.ToList();

            if (LVAlphabet.SelectedIndex != 0)
            {
                players = (List<Player>)players.Where(x => x.Name.StartsWith(alphabet[LVAlphabet.SelectedIndex])).ToList();
            }
            if (CBYear.SelectedIndex != 0)
            {
                List<PlayerInTeam> playerInTeams = App.DB.PlayerInTeam.ToList();
                playerInTeams = playerInTeams.Where(x =>x.SeasonId == CBYear.SelectedIndex).ToList();

                players = (List<Player>)players.Where(x => x.PlayerInTeam.Select(z => z.SeasonId).FirstOrDefault() == CBYear.SelectedIndex).ToList();
            }
            if (CBTeam.SelectedIndex != 0)
            {

                players = (List<Player>)players.Where(x => x.PlayerInTeam.Select(z => z.TeamId).FirstOrDefault() == CBTeam.SelectedIndex).ToList();
            }
            if (TBPLayerName.Text.Length != 0)
            {

                players = (List<Player>)players.Where(x => x.Name.StartsWith(TBPLayerName.Text)).ToList();
            }

            MaxPageCount = (int)Math.Ceiling((double)players.Count / countInPage);



            GetPlayerPage();
        }

        private void GetPlayerPage() 
        {
            ListTb.Text = $"{currentPage}/{(MaxPageCount > 0 ? MaxPageCount : 1)}";
            DGPlayer.ItemsSource = players.Skip((currentPage - 1) * countInPage).Take(countInPage);
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MaxPageCount == 0)
            {
                return;
            }

            Button button = (Button)sender; 
            switch (button.Name)
            {
                case  "BNext":
                    if (currentPage == MaxPageCount)
                        currentPage = 1;
                    else currentPage++;
                    break;
                case "BBack":
                    if (currentPage == 1)
                        currentPage = MaxPageCount;
                    else currentPage--;
                    break;
                case "BFullNext":
                    currentPage = MaxPageCount;
                    break;
                case "BFullBack":
                    currentPage = 1;
                    break;
            }

            GetPlayerPage();
        }

        private void CBTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void CBYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void TBPLayerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void LVAlphabet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DGPlayer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var select = DGPlayer.SelectedItem as Player;
            NavigationService.Navigate(new PlayerDetailPage(select));
        }
    }
}
