using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Tasks.Models
{
    public class TDL : INotifyPropertyChanged
    {
        private string name;
        private BitmapImage image;
        private ObservableCollection<TDL> tDLs;
        private ObservableCollection<Task> tasks;

        public string Name 
        { 
            get { return name; } 
            set 
            { 
                name = value; 
                OnPropertyChanged("Name");
            }
        }

        public BitmapImage Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        public ObservableCollection<TDL> TDLs
        {
            get { return tDLs; }
            set
            {
                tDLs = value;
                OnPropertyChanged("TDLs");
            }
        }

        public ObservableCollection<Task> Tasks
        {
            get { return tasks; }
            set
            {
                tasks = value;
                OnPropertyChanged("Tasks");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
