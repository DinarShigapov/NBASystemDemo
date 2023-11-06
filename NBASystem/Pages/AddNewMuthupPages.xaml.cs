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
    /// Логика взаимодействия для AddNewMuthupPages.xaml
    /// </summary>
    public partial class AddNewMuthupPages : Page
    {
        public AddNewMuthupPages()
        {
            InitializeComponent();
        }



        private void CBAway_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBAway.SelectedItem != null)
            {
                CBHome.ItemsSource = App.DB.Team.Where(x => x == CBAway.SelectedItem).ToList();
            }
        }

        private void CBHome_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CBHome.SelectedItem != null)
            {
                CBAway.ItemsSource = App.DB.Team.Where(x => x == CBHome.SelectedItem).ToList();
            }
        }
    }
}
