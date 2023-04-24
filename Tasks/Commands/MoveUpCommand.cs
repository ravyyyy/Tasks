using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Tasks.ViewModels;
using Tasks.Models;

namespace Tasks.Commands
{
    public class MoveUpCommand : ICommand
    {
        private TreeViewVM treeViewVM;
        public MoveUpCommand(TreeViewVM treeViewVM)
        {
            this.treeViewVM = treeViewVM;
        }

        public void MoveUp()
        {
            TDL selectedTDL = treeViewVM.selectedTdl;
            Models.Task selectedTask = treeViewVM.selectedTask;

            if(selectedTask != null)
            {
                int index = selectedTDL.Tasks.IndexOf(selectedTask);
                if(index > 0)
                {
                    Models.Task auxiliaryTask = selectedTDL.Tasks[index - 1];
                    //ListViewItem item = new ListView().ItemContainerGenerator.ContainerFromItem(selectedTDL.Tasks[index]) as ListViewItem;
                    //ListViewItem item2 = new ListView().ItemContainerGenerator.ContainerFromItem(selectedTDL.Tasks[index - 1]) as ListViewItem;
                    selectedTDL.Tasks[index - 1] = selectedTask;
                    if(selectedTask.Status == true)
                    {
                        Brush brush = new SolidColorBrush(Colors.Green);
                        //item.Background = null;
                        //item2.Background = brush;
                    }
                    //Brush brush = item.Background;
                    //item.Background = item2.Background;
                    //item2.Background = brush;
                    selectedTDL.Tasks[index] = auxiliaryTask;
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

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MoveUp();
        }

        public event EventHandler CanExecuteChanged;
    }
}
