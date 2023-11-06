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
    /// Логика взаимодействия для MainScreenPage.xaml
    /// </summary>
    public partial class MainScreenPage : Page
    {

        private int _currentGroupList = 0;
        private int _maxPage = 4;
        List<BitmapImage> bytes;
        public MainScreenPage()
        {
            InitializeComponent();
            bytes = new List<BitmapImage>();
            foreach (var item in App.DB.Pictures)
            {
                bytes.Add(new BitmapImage(new Uri($"pack://application:,,,/Resources/Pictures/{item.Img}", UriKind.Absolute)));
            }
            LVImage.ItemsSource = bytes.ToList();

            
        }

        private void BSlideBack_Click(object sender, RoutedEventArgs e)
        {
            _currentGroupList--;
            if (_currentGroupList < 0)
                _currentGroupList = 0;
            Update();
        }

        private void BSlideNext_Click(object sender, RoutedEventArgs e)
        {
            _currentGroupList++;
            if (LVImage.Items.Count < 4)
                _currentGroupList--;
            Update();
        }


        private void Update()
        {
            IEnumerable<BitmapImage> photoList = bytes.ToList();
            photoList = photoList.Skip(_maxPage * _currentGroupList).Take(_maxPage);
            LVImage.ItemsSource = photoList;
        }

        private void BVisitor_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage(new VisitorMenuPage()));
        }

        private void BAdmin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage(new AdminLoginPage()));
        }
    }
}
