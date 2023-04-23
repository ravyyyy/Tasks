using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Tasks.Models;

namespace Tasks.ViewModels
{
    public class TreeViewVM : Models.BaseVM
    {
        private TDL tdl;
        public TDL TDL
        {
            get { return tdl; } 
            set 
            { 
                tdl = value;
                OnPropertyChanged("TDL");
            }
        }
        public ObservableCollection<TDL> TDLs { get; set; }
        public ObservableCollection<string> categories { get; set; } = new ObservableCollection<string>() { "Work", "Home", "Outside", "Shopping" };

        public TreeViewVM() 
        {
        TDLs = new ObservableCollection<TDL>
            {
                new TDL
                {
                    Name = "a",
                    Image = new BitmapImage(new Uri(@"/Images/home.png", UriKind.Relative)),
                    ToDLs = new ObservableCollection<TDL>
                {
                    new TDL { Name = "b", Image = new BitmapImage(new Uri(@"/Images/work.png", UriKind.Relative)), Tasks = new ObservableCollection<Models.Task>(), ToDLs = new ObservableCollection<TDL>()},
                },
                    Tasks = new ObservableCollection<Models.Task>
                {
                    new Models.Task
                    {
                        Name = "c",
                        Category = categories[1],
                        Status = false,
                        DateOfFinish = new DateTime(2023, 4, 25),
                        Deadline = new DateTime(2023, 4, 26),
                        Description = "o scurta descriere",
                        Priority = Priority.High,
                        Type = Models.Type.Minor
                    }
                }
                }
            };
        }

        public void AddCategory(string category)
        {
            categories.Add(category);
            OnPropertyChanged(nameof(categories));
        }

        public void RemoveCategory(string category)
        {
            categories.Remove(category);
            OnPropertyChanged(nameof(categories));
        }

        public void EditCategory(string categoryToSearch, string categoryToChange)
        {
            int index = categories.IndexOf(categoryToSearch);
            categories[index] = categoryToChange;
            OnPropertyChanged(nameof(categories));
        }
    }
}
