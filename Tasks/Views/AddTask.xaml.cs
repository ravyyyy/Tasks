﻿using System;
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
            Models.Category category2 = Models.Category.Work;
            if(category == "Work")
            {
                category2 = Models.Category.Work;
            }
            if(category == "Home")
            {
                category2 = Models.Category.Home;
            }
            if(category == "Outside")
            {
                category2 = Models.Category.Outside;
            }
            if(category == "Shopping")
            {
                category2 = Models.Category.Shopping;
            }
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
            Models.Task task = new Models.Task();
            task.Name = name;
            task.Description = description;
            task.Status = status;
            task.Deadline = deadline;
            task.DateOfFinish = dateOfFinish;
            task.Category = category2;
            task.Priority = priority2;
            task.Type = type2;
            tdl.Tasks.Add(task);
            this.Close();
        }
    }
}