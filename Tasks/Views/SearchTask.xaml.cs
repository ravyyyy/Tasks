using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for SearchTask.xaml
    /// </summary>
    public partial class SearchTask : Window
    {
        int count {  get; set; }
        string taskName { get; set; }
        BitmapImage image = new BitmapImage(new Uri(@"/Images/find_task.png", UriKind.Relative));
        public ObservableCollection<string> tasks { get; set; }
        //public ObservableCollection<TDL> tdlsLocations { get; set; }
        public ObservableCollection<TDL> tdls { get; set; }
        public ObservableCollection<KeyValuePair<string, TDL>> pairs { get; set; }
        TDL selectedTdl { get; set; }

        public SearchTask(ObservableCollection<KeyValuePair<string, TDL>> pairs, TDL selectedTdl, ObservableCollection<TDL> tdls)
        {
            InitializeComponent();
            count = 0;
            imageSource.Source = image;
            this.tdls = tdls;
            this.selectedTdl = selectedTdl;
            //tasks = new ObservableCollection<string>();
            // = new ObservableCollection<TDL>();
            this.pairs = pairs;
            findTaskListView.ItemsSource = pairs;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public ObservableCollection<KeyValuePair<string, TDL>> GetPairs(ObservableCollection<TDL> ToDoLists)
        {
            taskName = findTaskTextBox.Text;
            if (findTaskCheckBox.IsChecked == false)
            {
                foreach (var tdl in ToDoLists)
                {
                    if (tdl.Tasks != null)
                    {
                        foreach (var task in tdl.Tasks)
                        {
                            if (task.Name == taskName)
                            {
                                pairs.Add(new KeyValuePair<string, TDL>(taskName, tdl));
                            }
                        }
                        if (tdl.ToDLs != null && tdl.ToDLs.Count > 0)
                        {
                            GetPairs(tdl.ToDLs);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                foreach (var tdl in ToDoLists)
                {
                    if (tdl.Tasks != null)
                    {
                        foreach (var task in tdl.Tasks)
                        {
                            if (task.Name == taskName && tdl == selectedTdl)
                            {
                                pairs.Add(new KeyValuePair<string, TDL>(taskName, selectedTdl));
                            }
                        }
                        if (tdl.ToDLs != null && tdl.ToDLs.Count > 0)
                        {
                            GetPairs(tdl.ToDLs);
                        }
                    }
                    else
                    {
                        continue;
                    }    
                }
            }
            return pairs;
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            pairs.Clear();
            GetPairs(tdls);
            count = pairs.Count;
            string message = count.ToString();
            message += " item(s) found";
            findTaskItemsFound.Text = message;
            findTaskListView.ItemsSource = pairs;
            //tasks.Clear();
            //tdlsLocations.Clear();
            //pairs.Clear();
            count = 0;
        }
    }
}
