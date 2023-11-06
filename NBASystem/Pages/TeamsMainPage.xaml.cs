using NBASystem.Model;
using NBASystem.UserControls;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    /// Логика взаимодействия для TeamsMainPage.xaml
    /// </summary>
    public partial class TeamsMainPage : Page
    {
        public TeamsMainPage()
        {
            InitializeComponent();
            int i = 0;
            foreach (var item in App.DB.Division.Where(x => x.ConferenceId == 1))
            {
                var buffer = AddUserControl(item.Id);
                EasternGrid.Children.Add(buffer);
                Grid.SetColumn(buffer, i);
                i += 2;
            }

            int j = 0;
            foreach (var item in App.DB.Division.Where(x => x.ConferenceId == 2))
            {
                var buffer = AddUserControl(item.Id);
                WesternGrid.Children.Add(buffer);
                Grid.SetColumn(buffer, j);
                j += 2;
            }

        }

        private DivisionControl AddUserControl(int divisionId)
        {
            DivisionControl division = new DivisionControl();
            division.TeamList = App.DB.Team.Where(x => x.DivisionId == divisionId).ToList();
            division.ChangePageRequested += (sender, e) =>
            {
                if (e.NewPageType != null)
                {
                    TeamDetailPage newPage = new TeamDetailPage(division.SelectedTeam, division.IndexTabControl);
                    NavigationService.Navigate(newPage);
                }
            };

            return division;

        }
    }
}
