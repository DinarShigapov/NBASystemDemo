using NBASystem.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
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
    /// Логика взаимодействия для PhotosPage.xaml
    /// </summary>
    public partial class PhotosPage : Page
    {
        private int countInPage = 12;
        private int MaxPageCount;
        private int currentPage = 1;
        List<Pictures> picture;
        public PhotosPage()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            currentPage = 1;
            picture = App.DB.Pictures.ToList();
            MaxPageCount = (int)Math.Ceiling((double)picture.Count / countInPage);
            GetPicturePage();
        }

        private void GetPicturePage()
        {
            ListTb.Text = $"{currentPage}/{(MaxPageCount > 0 ? MaxPageCount : 1)}";
            LVPicture.ItemsSource = picture.Skip((currentPage - 1) * countInPage).Take(countInPage);
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
                case "BNext":
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

            GetPicturePage();
        }

        private void MIDownload_Click(object sender, RoutedEventArgs e)
        {
            var selected = LVPicture.SelectedItem as Pictures;
            SaveImage(selected);
            MessageBox.Show("Изображение успешно скачано");
        }


        private void SaveImage(Pictures pictures) 
        {
            Uri imagePath = new Uri($"pack://application:,,,/Resources/Pictures/{pictures.Img}", UriKind.Absolute);

            Stream stream = Application.GetResourceStream(imagePath).Stream;

            string fileName = $"C:\\Users\\262023\\Downloads\\image{pictures.Id}.png";

            FileStream fileStream = new FileStream(fileName, FileMode.Create);

            byte[] buffer = new byte[1024];
            int bytesRead;
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fileStream.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();
            
        }

        private void BSaveAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (Pictures item in LVPicture.Items)
            {
                SaveImage(item);
            }
            MessageBox.Show("Изображение успешно скачано");
        }
    }
}
