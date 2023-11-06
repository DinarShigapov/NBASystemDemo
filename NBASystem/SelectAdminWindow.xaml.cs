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
using System.Windows.Shapes;

namespace NBASystem
{
    /// <summary>
    /// Логика взаимодействия для SelectAdminWindow.xaml
    /// </summary>
    public partial class SelectAdminWindow : Window
    {
        public SelectAdminWindow()
        {
            InitializeComponent();
        }

        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BEvent_Click(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow as MainWindow;

            if ((Page)window.MainFrame.Content is MenuPage)
            {
                var page = (MenuPage)window.MainFrame.Content;

                page.MenuFrame.Navigate(new EventAdminMenuPage());
            }

            this.Close();
        }

        private void BTechnical_Click(object sender, RoutedEventArgs e)
        {
            var window = Application.Current.MainWindow as MainWindow;

            if ((Page)window.MainFrame.Content is MenuPage)
            {
                var page = (MenuPage)window.MainFrame.Content;

                page.MenuFrame.Navigate(new PhotosPage());
            }

            this.Close();
        }
    }
}
