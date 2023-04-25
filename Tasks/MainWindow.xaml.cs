using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Tasks.Commands;
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
            if (TDLTreeView.SelectedItem is TDL selectedItem)
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
            if (TaskListView.SelectedItem is Models.Task selectedTask)
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
            if (TaskListView.SelectedItem is Models.Task selectedTask)
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
            if (TaskListView.SelectedItem is Models.Task selectedTask)
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

        //private void MoveUp_Click(object sender, RoutedEventArgs e)
        //{
        //    TDL selectedItem = TDLTreeView.SelectedItem as TDL;
        //    if (TaskListView.SelectedItem is Models.Task selectedTask)
        //    {
        //        int index = selectedItem.Tasks.IndexOf(selectedTask);
        //        if (index > 0)
        //        {
        //            Task auxiliaryTask = selectedItem.Tasks[index - 1];
        //            ListViewItem item = TaskListView.ItemContainerGenerator.ContainerFromItem(selectedItem.Tasks[index]) as ListViewItem;
        //            ListViewItem item2 = TaskListView.ItemContainerGenerator.ContainerFromItem(selectedItem.Tasks[index - 1]) as ListViewItem;
        //            selectedItem.Tasks[index - 1] = selectedTask;
        //            Brush brush = item.Background;
        //            item.Background = item2.Background;
        //            item2.Background = brush;
        //            selectedItem.Tasks[index] = auxiliaryTask;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Can't move anymore UP!", "Warning", MessageBoxButton.OK);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("You did not select a Task!", "Warning", MessageBoxButton.OK);
        //    }
        //}

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            TDL selectedItem = TDLTreeView.SelectedItem as TDL;
            if (TaskListView.SelectedItem is Models.Task selectedTask)
            {
                int index = selectedItem.Tasks.IndexOf(selectedTask);
                if (index < selectedItem.Tasks.Count - 1)
                {
                    ListViewItem item = TaskListView.ItemContainerGenerator.ContainerFromItem(selectedItem.Tasks[index]) as ListViewItem;
                    ListViewItem item2 = TaskListView.ItemContainerGenerator.ContainerFromItem(selectedItem.Tasks[index + 1]) as ListViewItem;
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
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            ObservableCollection<TDL> tdls = treeViewVM.TDLs;
            ManageCategory manageCategory = new ManageCategory(tdls);
            manageCategory.Show();
        }

        private void FindTask_Click(object sender, RoutedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            ObservableCollection<TDL> tdls = treeViewVM.TDLs;
            if (TDLTreeView.SelectedItem is TDL selectedTdl)
            {
                SearchTask searchTask = new SearchTask(treeViewVM.pairs, selectedTdl, tdls);
                searchTask.Show();
            }
            else
            {
                MessageBox.Show("You did not select a view!", "Warning", MessageBoxButton.OK);
            }
        }

        private void Deadline_Click(object sender, RoutedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            foreach (TDL tdl in treeViewVM.TDLs)
            {
                tdl.Tasks = new ObservableCollection<Task>(tdl.Tasks.OrderBy(t => t.Deadline));
            }
            TaskListView.ItemsSource = treeViewVM.TDLs;
        }

        private void Priority_Click(object sender, RoutedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            foreach (TDL tdl in treeViewVM.TDLs)
            {
                ObservableCollection<Models.Task> lowTaks = new ObservableCollection<Models.Task>();
                ObservableCollection<Models.Task> mediumTaks = new ObservableCollection<Models.Task>();
                ObservableCollection<Models.Task> highTaks = new ObservableCollection<Models.Task>();
                foreach(Models.Task task in tdl.Tasks)
                {
                    if(task.Priority == Models.Priority.Low)
                    {
                        lowTaks.Add(task);
                    }
                    else if(task.Priority == Models.Priority.Medium)
                    {
                        mediumTaks.Add(task);
                    }
                    else
                    {
                        highTaks.Add(task);
                    }
                }
                tdl.Tasks.Clear();
                tdl.Tasks = lowTaks;
                foreach (Models.Task task in mediumTaks)
                {
                    tdl.Tasks.Add(task);
                }
                foreach (Models.Task task in highTaks)
                {
                    tdl.Tasks.Add(task);
                }
            }
            TaskListView.ItemsSource = treeViewVM.TDLs;
        }

        private void FinishedTasks_Click(object sender, RoutedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            if (treeViewVM != null)
            {
                //treeViewVM.TDLs = treeViewVM.TDLsCopy;
                treeViewVM.TDLs = treeViewVM.LoopThroughTDLFilter4(treeViewVM.TDLs);
            }
        }

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            ObservableCollection<int> ints = treeViewVM.LoopThroughAllTDLs(treeViewVM.TDLs);
            tasksDueTodayText.Text = ints[0].ToString();
            tasksDueTomorrowText.Text = ints[1].ToString();
            tasksOverdueText.Text = ints[2].ToString();
            tasksDoneText.Text = ints[3].ToString();
            tasksToBeDoneText.Text = ints[4].ToString();
            for(int i = 0;i < ints.Count; i++)
            {
                ints[i] = 0;
            }
            treeViewVM.ints = ints;
        }

        private void TaskListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            if(treeViewVM != null)
            {
                Task selectedTask = TaskListView.SelectedItem as Task;
                treeViewVM.selectedTask = selectedTask;
                treeViewVM.TDLs = treeViewVM.TDLsCopy;
                TDL selectedTDL = TDLTreeView.SelectedItem as TDL;
                treeViewVM.selectedTdl = selectedTDL;
            }
        }

        private void UnfinishedTasksDeadline_Click(object sender, RoutedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            if(treeViewVM != null)
            {
                treeViewVM.TDLs = treeViewVM.TDLsCopy;
                treeViewVM.TDLs = treeViewVM.LoopThroughTDLFilter1(treeViewVM.TDLs);
            }
        }

        private void UnfinishedTasksOverdue_Click(object sender, RoutedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            if(treeViewVM != null)
            {
                treeViewVM.TDLs = treeViewVM.TDLsCopy;
                treeViewVM.TDLs = treeViewVM.LoopThroughTDLFilter2(treeViewVM.TDLs);
            }    
        }

        private void OverdueTasks_Click(object sender, RoutedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            if (treeViewVM != null)
            {
                treeViewVM.TDLs = treeViewVM.TDLsCopy;
                treeViewVM.TDLs = treeViewVM.LoopThroughTDLFilter3(treeViewVM.TDLs);
            }
        }

        private void CategorySelected_Click(object sender, RoutedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            if (treeViewVM != null)
            {
                MenuItem menuItem = sender as MenuItem;
                Category category = menuItem.DataContext as Category;
                treeViewVM.TDLs = treeViewVM.TDLsCopy;
                treeViewVM.TDLs = treeViewVM.LoopThroughTDLFilter5(treeViewVM.TDLs, category);
            }
        }

        private void MoveUpTDL_Click(object sender, RoutedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            TDL selectedTDL = TDLTreeView.SelectedItem as TDL;
            if (treeViewVM != null && selectedTDL != null)
            {
                int indexTDL = treeViewVM.GetIndex(treeViewVM.TDLs, selectedTDL);
                if(indexTDL > 0)
                {
                    TDL auxiliaryTDL = treeViewVM.TDLs[indexTDL - 1];
                    treeViewVM.TDLs[indexTDL - 1] = selectedTDL;
                    treeViewVM.TDLs[indexTDL] = auxiliaryTDL;
                }
                else
                {
                    MessageBox.Show("TDL can not move UP!", "Warning", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Please select a TDL!", "Warning", MessageBoxButton.OK);
            }
        }

        private void MoveDownTDL_Click(object sender, RoutedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            TDL selectedTDL = TDLTreeView.SelectedItem as TDL;
            if (treeViewVM != null && selectedTDL != null)
            {
                int indexTDL = treeViewVM.GetIndex(treeViewVM.TDLs, selectedTDL);
                if (indexTDL < selectedTDL.ToDLs.Count - 1)
                {
                    TDL auxiliaryTDL = treeViewVM.TDLs[indexTDL + 1];
                    treeViewVM.TDLs[indexTDL + 1] = selectedTDL;
                    treeViewVM.TDLs[indexTDL] = auxiliaryTDL;
                }
                else
                {
                    MessageBox.Show("TDL can not move DOWN!", "Warning", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Please select a TDL!", "Warning", MessageBoxButton.OK);
            }
        }

        private void DeleteTDL_Click(object sender, RoutedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            TDL selectedTDL = TDLTreeView.SelectedItem as TDL;
            if(treeViewVM != null && selectedTDL != null)
            {
                treeViewVM.TDLs = treeViewVM.DeleteTDL(treeViewVM.TDLs, selectedTDL);
            }
            else
            {
                MessageBox.Show("Please select a TDL!", "Warning", MessageBoxButton.OK);
            }    
        }

        private void EditTDL_Click(object sender, RoutedEventArgs e)
        {
            TDL selectedTDL = TDLTreeView.SelectedItem as TDL;
            if(selectedTDL != null)
            {
                EditTDL editTDL = new EditTDL(selectedTDL);
                editTDL.Show();
            }
            else
            {
                MessageBox.Show("You did not select a TDL!", "Warning", MessageBoxButton.OK);
            }
        }

        private void AddSubTDL_Click(object sender, RoutedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            ObservableCollection<TDL> tDLS = treeViewVM.TDLs;
            TDL selectedTDL = TDLTreeView.SelectedItem as TDL;
            AddSubTDL addSubTDL = new AddSubTDL(tDLS ,selectedTDL);
            addSubTDL.Show();
        }

        private void AddRootTDL_Click(object sender, RoutedEventArgs e)
        {
            TreeViewVM treeViewVM = this.DataContext as TreeViewVM;
            TDL selectedTDL = TDLTreeView.SelectedItem as TDL;
            if( selectedTDL != null && treeViewVM != null)
            {
                AddRootTDL addRootTDL = new AddRootTDL(treeViewVM, selectedTDL);
                addRootTDL.Show();
            }
            else
            {
                MessageBox.Show("Please select TDL!", "Warning", MessageBoxButton.OK);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NewDatabase_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = null;
            TreeViewVM treeViewVM = new TreeViewVM();
            treeViewVM.TDLs = new ObservableCollection<TDL>();
            this.DataContext = treeViewVM;
        }
    }
}
