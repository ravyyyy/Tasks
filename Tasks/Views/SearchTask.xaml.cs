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
        BitmapImage image = new BitmapImage(new Uri(@"/Images/find_task.png", UriKind.Relative));
        public ObservableCollection<string> tasks { get; set; }
        //public ObservableCollection<TDL> tdlsLocations { get; set; }
        public ObservableCollection<TDL> tdls { get; set; }
        public ObservableCollection<KeyValuePair<string, TDL>> pairs { get; set; }
        TDL selectedTdl { get; set; }

        public SearchTask(ObservableCollection<KeyValuePair<string, TDL>> pairs, TDL selectedTdl, ObservableCollection<TDL> tdls)
        {
            InitializeComponent();
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

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            string taskName = findTaskTextBox.Text;
            pairs.Clear();
            if(findTaskCheckBox.IsChecked == false)
            {
                foreach(TDL tdl in tdls)
                {
                    if(tdl.ToDLs != null)
                    {
                        foreach(TDL tdl2 in tdl.ToDLs)
                        {
                            foreach(Models.Task task2 in tdl2.Tasks)
                            {
                                if(task2.Name == taskName)
                                {
                                    pairs.Add(new KeyValuePair<string, TDL>(taskName, tdl2));
                                }
                            }    
                        }
                    }
                    foreach(Models.Task task in tdl.Tasks)
                    {
                        if(task.Name == taskName)
                        {
                            //tasks.Add(taskName);
                            //tdlsLocations.Add(tdl);
                            pairs.Add(new KeyValuePair<string, TDL>(taskName, tdl));
                        }
                    }
                }
            }
            else
            {
                foreach(Models.Task task in selectedTdl.Tasks)
                {
                    if(task.Name == taskName)
                    {
                        //tasks.Add(taskName);
                        //tdlsLocations.Add(selectedTdl);
                        pairs.Add(new KeyValuePair<string, TDL>(taskName, selectedTdl));

                    }
                }
            }
            count = pairs.Count;
            string message = count.ToString();
            message += " item(s) found";
            findTaskItemsFound.Text = message;
            findTaskListView.ItemsSource = pairs;
            //tasks.Clear();
            //tdlsLocations.Clear();
            //pairs.Clear();
        }
    }
}
