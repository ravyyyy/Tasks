using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Models.Task> tasks;

        public ObservableCollection<Models.Task> Tasks
        {
            get { return tasks; }
            set 
            { 
                tasks = value;
                OnPropertyChanged("Tasks");
            }
        }

        public TaskViewModel()
        {
            tasks = new ObservableCollection<Models.Task>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
