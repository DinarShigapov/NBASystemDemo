using NBASystem.Model;
using NBASystem.Pages;
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

namespace NBASystem.UserControls
{
    /// <summary>
    /// Логика взаимодействия для DivisionControl.xaml
    /// </summary>
    public partial class DivisionControl : UserControl
    {
        public List<Team> TeamList { get; set; }
        public Team SelectedTeam { get; set; }
        public int IndexTabControl { get; set; }
        public event EventHandler<PageChangedEventArgs> ChangePageRequested;
        public DivisionControl()
        {
            InitializeComponent();
        }

        private void NextPage()
        {
            ChangePageRequested?.Invoke(this, new PageChangedEventArgs(typeof(TeamDetailPage)));
        }

        private void TBRoster_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var team = (sender as TextBlock).DataContext as Team;
            if (team == null)
            {
                return;
            }
            SelectedTeam = team;
            NextPage();
        }

        private void TBLineup_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var team = (sender as TextBlock).DataContext as Team;
            if (team == null)
            {
                return;
            }
            SelectedTeam = team;
            NextPage();
        }

        private void TBMatchup_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var team = (sender as TextBlock).DataContext as Team;
            if (team == null)
            {
                return;
            }
            SelectedTeam = team;
            NextPage();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (TeamList.Count != 0)
            {
                LVGrid.ItemsSource = TeamList.ToList();
                HeaderName.Text = TeamList[0].Division.Name;
            }
        }
    }

    public class PageChangedEventArgs : EventArgs
    {
        public Type NewPageType { get; set; }

        public PageChangedEventArgs(Type newPageType)
        {
            NewPageType = newPageType;
        }
    }


}
