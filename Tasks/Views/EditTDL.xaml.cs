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

namespace Tasks.Views
{
    /// <summary>
    /// Interaction logic for EditTDL.xaml
    /// </summary>
    public partial class EditTDL : Window
    {
        TDL selectedTDL;
        ObservableCollection<BitmapImage> images;

        public EditTDL(TDL selectedTDL)
        {
            InitializeComponent();
            this.selectedTDL = selectedTDL;
            images = new ObservableCollection<BitmapImage>();
            images.Add(new BitmapImage(new Uri(@"/Images/home.png", UriKind.Relative)));
            images.Add(new BitmapImage(new Uri(@"/Images/shopping.png", UriKind.Relative)));
            images.Add(new BitmapImage(new Uri(@"/Images/work.png", UriKind.Relative)));
            imageSlide.Source = selectedTDL.Image;
            nameTextBox.Text = selectedTDL.Name;
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            int index = images.IndexOf((BitmapImage)imageSlide.Source);
            if(index > 0)
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

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            BitmapImage image = (BitmapImage)imageSlide.Source;
            selectedTDL.Name = name;
            selectedTDL.Image = image;
            this.Close();
        }
    }
}
