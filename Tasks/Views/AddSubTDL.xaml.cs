using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Tasks.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Tasks.Views
{
    /// <summary>
    /// Interaction logic for AddSubTDL.xaml
    /// </summary>
    public partial class AddSubTDL : Window
    {
        TDL selectedTDL;
        ObservableCollection<BitmapImage> images;
        ObservableCollection<TDL> tDLs;

        public AddSubTDL(ObservableCollection<TDL> tDLs)
        {
            InitializeComponent();
            images = new ObservableCollection<BitmapImage>();
            images.Add(new BitmapImage(new Uri(@"/Images/home.png", UriKind.Relative)));
            images.Add(new BitmapImage(new Uri(@"/Images/shopping.png", UriKind.Relative)));
            images.Add(new BitmapImage(new Uri(@"/Images/work.png", UriKind.Relative)));
            imageSlide.Source = images[0];
            this.tDLs = tDLs;
        }

        public AddSubTDL(TDL selectedTDL)
        {
            InitializeComponent();
            this.selectedTDL = selectedTDL;
            images = new ObservableCollection<BitmapImage>();
            images.Add(new BitmapImage(new Uri(@"/Images/home.png", UriKind.Relative)));
            images.Add(new BitmapImage(new Uri(@"/Images/shopping.png", UriKind.Relative)));
            images.Add(new BitmapImage(new Uri(@"/Images/work.png", UriKind.Relative)));
            imageSlide.Source = images[0];
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            int index = images.IndexOf((BitmapImage)imageSlide.Source);
            if (index > 0)
            {
                imageSlide.Source = images[index - 1];
            }
            else
            {
                MessageBox.Show("There are no more images!", "Warning", MessageBoxButton.OK);
            }
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            int index = images.IndexOf((BitmapImage)imageSlide.Source);
            if (index < images.Count - 1)
            {
                imageSlide.Source = images[index + 1];
            }
            else
            {
                MessageBox.Show("There are no more images!", "Warning", MessageBoxButton.OK);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            BitmapImage image = (BitmapImage)imageSlide.Source;
            TDL newTDL = new TDL();
            newTDL.Name = name;
            newTDL.Image = image;
            if (selectedTDL != null)
            {
                selectedTDL.ToDLs.Add(newTDL);

            }
            else
            {
                tDLs.Add(newTDL);
            }
            this.Close();
        }
    }
}
