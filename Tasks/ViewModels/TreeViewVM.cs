using System;
using System.Collections.ObjectModel;
using System.Linq;
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
        private ObservableCollection<Category> categories = new ObservableCollection<Category>() 
        { 
            new Category() { Name = "Work" },
            new Category() { Name = "Home" },
            new Category() { Name = "School" },
            new Category() { Name = "Outside" }
        };

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set 
            { 
                categories = value;
                OnPropertyChanged("Categories");
            }
        }

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
                        Category = new Category() { Name = "Home" }.ToString(),
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
            Category category1 = new Category();
            category1.Name = category;
            Categories.Add(category1);
            OnPropertyChanged("Categories");
        }

        public void RemoveCategory(string category)
        {
            Category categoryToRemove = Categories.FirstOrDefault(c => c.Name == category);
            Categories.Remove(categoryToRemove);
        }

        public void EditCategory(string categoryToSearch, string categoryToChange)
        {
            Category categoryToEdit = Categories.FirstOrDefault(c => c.Name == categoryToSearch);
            if (categoryToEdit != null)
            {
                int index = Categories.IndexOf(categoryToEdit);
                Categories[index] = new Category { Name = categoryToChange };
            }
        }
    }
}
