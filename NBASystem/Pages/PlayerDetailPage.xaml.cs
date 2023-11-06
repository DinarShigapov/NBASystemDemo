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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataVis = System.Windows.Forms.DataVisualization.Charting;

namespace NBASystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для PlayerDetailPage.xaml
    /// </summary>
    public partial class PlayerDetailPage : Page
    {
        Player contextPlayer;
        public PlayerDetailPage(Player selectedPlayer)
        {
            InitializeComponent();
            contextPlayer = selectedPlayer;
            DataContext = contextPlayer;

            DGSeason.ItemsSource = new List<Player>() { contextPlayer };
            DGCareer.ItemsSource = new List<Player>() { contextPlayer };

        }

        IEnumerable<PlayerStatistics> result = null;
        List<int> resultScore = new List<int>();
        bool isdate = false;
        private void BPoint_Click(object sender, RoutedEventArgs e)
        {
            charts.ChartAreas.Clear();
            charts.Series.Clear();
            result = contextPlayer.PlayerStatistics.ToList();
            
            Button button = (Button)sender;
            if (isdate == true)
            {
                result = result.Where(x => 
                    x.Matchup.Starttime.Date > DPStart.SelectedDate.Value.Date && 
                    x.Matchup.Starttime < DPEnd.SelectedDate.Value.Date
                    ).ToList();
            }
            isdate = false;
            switch (button.Name)
            {
                case "BPoint":
                    resultScore = result.Select(x => x.Point).ToList();
                    break;
                case "BRebound":
                    resultScore = result.Select(x => x.Rebound).ToList();
                    break;
                case "BAssists":
                    resultScore = result.Select(x => x.Assist).ToList();
                    break;
                case "BSteal":
                    resultScore = result.Select(x => x.Steal).ToList();
                    break;
                case "BBlock":
                    resultScore = result.Select(x => x.Block).ToList();
                    break;
            }
           


            charts.ChartAreas.Add(new ChartArea("Default"));

            charts.Series.Add(new Series("Series1"));
            charts.Series["Series1"].ChartArea = "Default";
            charts.Series["Series1"].ChartType = SeriesChartType.Line;

            int[] axisYData = resultScore.ToArray();
            string[] axisXData = new string[resultScore.Count()];
            for (int i = 0; i < axisYData.Length; i++)
            {
                axisXData[i] = $"9/{i + 4}";
            }
            charts.Series["Series1"].Points.DataBindXY(axisXData, axisYData);
        }

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            if (DPStart.SelectedDate != null && DPEnd.SelectedDate != null && result != null)
            {
              isdate = true;
            }
        }
    }
}
