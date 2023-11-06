using NBASystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для MatchupListPage.xaml
    /// </summary>
    public partial class MatchupListPage : Page
    {
        public MatchupListPage()
        {
            InitializeComponent();
            CurrentMatch.DataContext = GetCurrentMatch();
            DGMatch.ItemsSource = App.DB.Matchup.ToList();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
           var selectedDate = (sender as DatePicker).SelectedDate;
            if (selectedDate != null)
            {
                DGMatch.ItemsSource = App.DB.Matchup.Where(
                    x => x.Starttime.Year == selectedDate.Value.Year &&
                    x.Starttime.Day == selectedDate.Value.Day &&
                    x.Starttime.Month == selectedDate.Value.Month
                    ).ToList();

            }
        }

        private Matchup GetCurrentMatch()
        {
            var asss =  App.DB.Matchup.OrderByDescending(x =>x.Starttime).Where(X => X.Starttime < DateTime.Now).FirstOrDefault();
            return asss;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           if( DpSELET.SelectedDate != null)
            {
                DateTime dateTime = DpSELET.SelectedDate.Value;
                dateTime +=(TimeSpan.FromDays(1));
                DpSELET.SelectedDate = dateTime;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DpSELET.SelectedDate != null)
            {
                DateTime dateTime = DpSELET.SelectedDate.Value;
                dateTime -= (TimeSpan.FromDays(1));
                DpSELET.SelectedDate = dateTime;
            }
        }

        private void BView_Click(object sender, RoutedEventArgs e)
        {
            var selected = (sender as Button).DataContext as Matchup;
            if (selected == null) return;
            NavigationService.Navigate(new MatchupDetailPage(selected));
        }
    }
}
