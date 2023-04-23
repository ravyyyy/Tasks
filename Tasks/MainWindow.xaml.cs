using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Tasks.Models;
using Tasks.ViewModels;
using Tasks.Views;

namespace Tasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Efrim Dragos-Alexandru \n Grupa 10LF211 \n dragos.efrim@student.unitbv.ro", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TDL selectedItem = TDLTreeView.SelectedItem as TDL;
            if (selectedItem != null)
            {
                AddTask addTask = new AddTask(selectedItem);
                addTask.Show();
            }
            else
            {
                MessageBox.Show("You did not select a ToDoList!", "Warning", MessageBoxButton.OK);
            }
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TDL selectedTDL)
            {
                TaskListView.ItemsSource = selectedTDL.Tasks;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            TDL selectedItem = TDLTreeView.SelectedItem as TDL;
            Task selectedTask = TaskListView.SelectedItem as Task;
            if (selectedTask != null)
            {
                int index = selectedItem.Tasks.IndexOf(selectedTask);
                EditTask editTask = new EditTask(selectedItem, selectedTask, index);
                editTask.Show();
            }
            else
            {
                MessageBox.Show("You did not select a Task!", "Warning", MessageBoxButton.OK);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            TDL selectedItem = TDLTreeView.SelectedItem as TDL;
            Task selectedTask = TaskListView.SelectedItem as Task;
            if (selectedTask != null)
            {
                selectedItem.Tasks.Remove(selectedTask);
            }
            else
            {
                MessageBox.Show("You did not select a Task!", "Warning", MessageBoxButton.OK);
            }
        }

        private void SetDone_Click(object sender, RoutedEventArgs e)
        {
            Task selectedTask = TaskListView.SelectedItem as Task;
            if (selectedTask != null)
            {
                selectedTask.Status = true;
                SolidColorBrush brush = new SolidColorBrush(Colors.Green);
                ListViewItem item = TaskListView.ItemContainerGenerator.ContainerFromItem(selectedTask) as ListViewItem;
                item.Background = brush;
            }
            else
            {
                MessageBox.Show("You did not select a Task!", "Warning", MessageBoxButton.OK);
            }
        }

        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            TDL selectedItem = TDLTreeView.SelectedItem as TDL;
            Task selectedTask = TaskListView.SelectedItem as Task;
            if (selectedTask != null)
            { 
                int index = selectedItem.Tasks.IndexOf(selectedTask);
                if (index > 0)
                {
                    Task auxiliaryTask = selectedItem.Tasks[index - 1];
                    ListViewItem item = TaskListView.ItemContainerGenerator.ContainerFromItem(selectedItem.Tasks[index]) as ListViewItem;
                    ListViewItem item2 = TaskListView.ItemContainerGenerator.ContainerFromItem(selectedItem.Tasks[index - 1]) as ListViewItem;
                    selectedItem.Tasks[index - 1] = selectedTask;
                    Brush brush = item.Background;
                    item.Background = item2.Background;
                    item2.Background = brush;
                    selectedItem.Tasks[index] = auxiliaryTask;
                }
                else
                {
                    MessageBox.Show("Can't move anymore UP!", "Warning", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("You did not select a Task!", "Warning", MessageBoxButton.OK);
            }
        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            TDL selectedItem = TDLTreeView.SelectedItem as TDL;
            Task selectedTask = TaskListView.SelectedItem as Task;
            if (selectedTask != null)
            {
                int index = selectedItem.Tasks.IndexOf(selectedTask);
                if (index < selectedItem.Tasks.Count - 1)
                {
                    ListViewItem item = TaskListView.ItemContainerGenerator.ContainerFromItem(selectedItem.Tasks[index]) as ListViewItem;
                    ListViewItem item2 = TaskListView.ItemContainerGenerator.ContainerFromItem(selectedItem.Tasks[index +1]) as ListViewItem;
                    Brush brush = item.Background;
                    item.Background = item2.Background;
                    item2.Background = brush;
                    Task auxiliaryTask = selectedItem.Tasks[index + 1];
                    selectedItem.Tasks[index + 1] = selectedTask;
                    selectedItem.Tasks[index] = auxiliaryTask;
                }
                else
                {
                    MessageBox.Show("Can't move anymore DOWN!", "Warning", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("You did not select a Task!", "Warning", MessageBoxButton.OK);
            }
        }

        private void ManageCategory_Click(object sender, RoutedEventArgs e)
        {
            ManageCategory manageCategory = new ManageCategory();
            manageCategory.Show();
        }
    }
}
