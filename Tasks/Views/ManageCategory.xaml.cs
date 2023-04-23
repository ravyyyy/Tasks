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
using Tasks.ViewModels;

namespace Tasks.Views
{
    /// <summary>
    /// Interaction logic for ManageCategory.xaml
    /// </summary>
    public partial class ManageCategory : Window
    {
        string category;
        string categorySelected;

        public ManageCategory()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            category = categoryTextBox.Text;
            if(category != null)
            {
                ((TreeViewVM)Application.Current.MainWindow.DataContext).AddCategory(category);
            }
            else
            {
                MessageBox.Show("Please enter a category!", "Warning", MessageBoxButton.OK);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(categorySelected != null)
            {
                ((TreeViewVM)Application.Current.MainWindow.DataContext).RemoveCategory(category);
            }
            else
            {
                MessageBox.Show("Please select a category!", "Warning", MessageBoxButton.OK);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if(category != null || categorySelected != null)
            {
                ((TreeViewVM)Application.Current.MainWindow.DataContext).EditCategory(categorySelected, category);
            }
            else
            {
                MessageBox.Show("Please enter and select a category!", "Warning", MessageBoxButton.OK);
            }
        }

        private void categoryComboBoxSelected(object sender, SelectionChangedEventArgs e)
        {
            categorySelected = categoryComboBox.SelectedItem as string;
        }
    }
}
