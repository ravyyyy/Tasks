using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Tasks.Models;

namespace Tasks.ViewModels
{
    public class TDLViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TDL> tdlCollection;
        private ObservableCollection<Models.Task> tasks;


        public ObservableCollection<TDL> TdlCollection
        {
            get { return tdlCollection; }
            set
            {
                tdlCollection = value;
                OnPropertyChanged("TDLCollection");
            }
        }

        public ObservableCollection<Models.Task> Tasks
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

        public TDLViewModel() 
        {
            TaskViewModel taskViewModel = new TaskViewModel();
            Tasks = taskViewModel.Tasks;

            TdlCollection = new ObservableCollection<TDL>();
            TdlCollection.Add(new TDL
            {
                Name = "Home",
                Image = new BitmapImage(new Uri(@"/Images/home.png", UriKind.Relative)),
                TDLs = new ObservableCollection<TDL>
                {
                    new TDL() { Name = "RC" }
                },
                Tasks = tasks
            });
            TdlCollection[0].Tasks.Add(new Models.Task() { Status = false, Name = "Orice", Description = "asdadas", Type = Models.Type.Major, Category = Category.Work, Priority = Priority.Medium,
                Deadline = new DateTime(2023, 4, 22), DateOfFinish = new DateTime(2023, 4, 23) });
        }
    }
}
