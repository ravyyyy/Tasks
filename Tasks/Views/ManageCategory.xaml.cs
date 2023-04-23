using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Tasks.Models;
using Tasks.ViewModels;

namespace Tasks.Views
{
    /// <summary>
    /// Interaction logic for ManageCategory.xaml
    /// </summary>
    public partial class ManageCategory : Window
    {
        string category;
        ObservableCollection<TDL> tdls;

        public ManageCategory(ObservableCollection<TDL> tdls)
        {
            InitializeComponent();
            this.DataContext = Application.Current.MainWindow.DataContext;
            this.tdls = tdls;
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
            if(categoryComboBox.SelectedItem != null)
            {
                Models.Category category2 = categoryComboBox.SelectedItem as Category;
                ((TreeViewVM)Application.Current.MainWindow.DataContext).RemoveCategory(category2.Name);
                foreach(TDL tdl in tdls)
                {
                    foreach (Task task in tdl.Tasks.ToList())
                    {
                        if(task.Category == category2.Name)
                        {
                            tdl.Tasks.Remove(task);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a category!", "Warning", MessageBoxButton.OK);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (category != null || categoryComboBox.SelectedItem != null)
            {
                category = categoryTextBox.Text;
                Category category2 = categoryComboBox.SelectedItem as Category;
                ((TreeViewVM)Application.Current.MainWindow.DataContext).EditCategory(category2.Name, category);
                foreach(TDL tDL in tdls)
                {
                    foreach(Task task in tDL.Tasks.ToList())
                    {
                        if(task.Category == category2.Name)
                        {
                            ((TreeViewVM)Application.Current.MainWindow.DataContext).EditTaskCategory(task, category);
                        }
                    }    
                }
            }
            else
            {
                MessageBox.Show("Please enter and select a category!", "Warning", MessageBoxButton.OK);
            }
        }
    }
}
