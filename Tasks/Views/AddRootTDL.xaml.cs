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
using Tasks.ViewModels;

namespace Tasks.Views
{
    /// <summary>
    /// Interaction logic for AddRootTDL.xaml
    /// </summary>
    public partial class AddRootTDL : Window
    {
        TreeViewVM treeViewVM;
        ObservableCollection<BitmapImage> images;
        TDL selectedTDL;

        public AddRootTDL(TreeViewVM treeViewVM, TDL selectedTDL)
        {
            InitializeComponent();
            this.treeViewVM = treeViewVM;
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

        public (int index, TDL tdl) GetIndex(ObservableCollection<TDL> tdlS)
        {
            int index = -1;
            TDL tdl = null;

            for (int i = 0; i < tdlS.Count; i++)
            {
                if (tdlS[i].Name == selectedTDL.Name)
                {
                    index = i;
                    tdl = tdlS[i];
                    break;
                }
                if (tdlS[i].ToDLs != null)
                {
                    (index, tdl) = GetIndex(tdlS[i].ToDLs);
                    if (index != -1 && tdl != null)
                    {
                        tdl = tdlS[i];
                        break;
                    }
                }
            }

            return (index, tdl);
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            BitmapImage image = (BitmapImage)imageSlide.Source;
            //ObservableCollection<TDL> newRoot = new ObservableCollection<TDL>();
            TDL newTDL = new TDL();
            newTDL.Name = name;
            newTDL.Image = image;
            newTDL.ToDLs = new ObservableCollection<TDL>();
            newTDL.ToDLs.Add(selectedTDL);
            var (index, tdl) = GetIndex(treeViewVM.TDLs);
            tdl.ToDLs.Add(newTDL);
            tdl.ToDLs.Remove(selectedTDL);
            this.Close();
        }
    }
}
