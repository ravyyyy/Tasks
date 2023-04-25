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
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        TDL tdl { get; set; }

        public AddTask(TDL tdl2)
        {
            InitializeComponent();
            this.DataContext = Application.Current.MainWindow.DataContext;
            tdl = tdl2;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string description = descriptionTextBox.Text;
            string type = typeComboBox.Text;
            Models.Type type2 = Models.Type.Minor;
            if(type == "Minor")
            {
                type2 = Models.Type.Minor;
            }
            if(type == "Major")
            {
                type2 = Models.Type.Major;
            }
            string category = categoryComboBox.Text;
            string priority = priorityComboBox.Text;
            Models.Priority priority2 = Models.Priority.Low;
            if(priority == "Low")
            {
                priority2 = Models.Priority.Low;
            }
            if(priority == "Medium")
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
            if(statusCheckBox.IsChecked == true)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            Models.Task task = new Models.Task
            {
                Name = name,
                Description = description,
                Status = status,
                Deadline = deadline,
                DateOfFinish = dateOfFinish,
                Category = category,
                Priority = priority2,
                Type = type2
            };
            if(tdl.Tasks == null)
            {
                tdl.Tasks = new ObservableCollection<Models.Task>();
            }
            tdl.Tasks.Add(task);
            this.Close();
        }
    }
}
