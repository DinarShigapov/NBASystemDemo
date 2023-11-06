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
    /// Логика взаимодействия для TechnicalAdminPages.xaml
    /// </summary>
    public partial class TechnicalAdminPages : Page
    {
        public TechnicalAdminPages()
        {
            InitializeComponent();
        }

        private void BExeclutions_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeamReportPages());
        }

        private void BReport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TeamReportPages());
        }
    }
}
