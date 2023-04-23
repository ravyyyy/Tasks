using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                        Category = Category.Work,
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
    }
}
