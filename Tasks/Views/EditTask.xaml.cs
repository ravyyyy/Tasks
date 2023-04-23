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
using Tasks.Models;

namespace Tasks.Views
{
    /// <summary>
    /// Interaction logic for EditTask.xaml
    /// </summary>
    public partial class EditTask : Window
    {
        TDL tdl;
        Models.Task task;
        int index;

        public EditTask(TDL tdl, Models.Task task, int index)
        {
            InitializeComponent();
            this.DataContext = Application.Current.MainWindow.DataContext;
            this.tdl = tdl;
            this.task = task;
            this.index = index;
            nameTextBox.Text = task.Name;
            descriptionTextBox.Text = task.Description;
            typeComboBox.Text = task.Type.ToString();
            categoryComboBox.Text = task.Category.ToString();
            priorityComboBox.Text = task.Priority.ToString();
            deadlineDatePicker.Text = task.Deadline.ToString();
            dateOfFinishDatePicker.Text = task.DateOfFinish.ToString();
            if(task.Status == true)
            {
                statusCheckBox.IsChecked = true;
            }
            else
            {
                statusCheckBox.IsChecked = false;
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string description = descriptionTextBox.Text;
            string type = typeComboBox.Text;
            Models.Type type2 = Models.Type.Minor;
            if (type == "Minor")
            {
                type2 = Models.Type.Minor;
            }
            if (type == "Major")
            {
                type2 = Models.Type.Major;
            }
            string category = categoryComboBox.Text;
            string priority = priorityComboBox.Text;
            Models.Priority priority2 = Models.Priority.Low;
            if (priority == "Low")
            {
                priority2 = Models.Priority.Low;
            }
            if (priority == "Medium")
            {
                priority2 = Models.Priority.Medium;
            }
            if (priority == "High")
            {
                priority2 = Models.Priority.High;
            }
            DateTime deadline = deadlineDatePicker.SelectedDate ?? DateTime.MinValue;
            DateTime dateOfFinish = dateOfFinishDatePicker.SelectedDate ?? DateTime.MinValue;
            bool status;
            if (statusCheckBox.IsChecked == true)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            Models.Task task2 = new Models.Task();
            task2.Name = name;
            task2.Description = description;
            task2.Status = status;
            task2.Deadline = deadline;
            task2.DateOfFinish = dateOfFinish;
            task2.Category = category;
            task2.Priority = priority2;
            task2.Type = type2;
            tdl.Tasks[index] = task2;
            this.Close();
        }
    }
}
