using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Tasks.Commands;
using Tasks.Models;

namespace Tasks.ViewModels
{
    public class TreeViewVM : Models.BaseVM
    {
        public Models.Task selectedTask;
        public int index;
        public TDL selectedTdl;
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
        public ObservableCollection<KeyValuePair<string, TDL>> pairs { get; set; }
        public ObservableCollection<TDL> TDLsCopy { get; set; }

        public ObservableCollection<int> ints {  get; set; }

        private MoveUpCommand moveUpCommand;

        public ICommand MoveUpCommand
        {
            get
            {
                return moveUpCommand;
            }
        }

        private ObservableCollection<Category> categories = new ObservableCollection<Category>()
        {
            new Category() { Name = "Work" },
            new Category() { Name = "Home" },
            new Category() { Name = "School" }
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
            index = 0;
            selectedTdl = new TDL();
            selectedTask = new Models.Task();
            moveUpCommand = new MoveUpCommand(this);
            ints = new ObservableCollection<int>();
            for (int i = 0; i < 5; i++)
            {
                ints.Add(0);
            }
            pairs = new ObservableCollection<KeyValuePair<string, TDL>>();
            TDLs = new ObservableCollection<TDL>
            {
                new TDL
                {
                    Name = "a",
                    Image = new BitmapImage(new Uri(@"/Images/home.png", UriKind.Relative)),
                    ToDLs = new ObservableCollection<TDL>
                {
                    new TDL { Name = "b", Image = new BitmapImage(new Uri(@"/Images/work.png", UriKind.Relative)), Tasks = new ObservableCollection<Models.Task>{
                    new Models.Task
                    {
                        Name = "c",
                        Category = categories[2].Name,
                        Status = false,
                        DateOfFinish = new DateTime(2023, 4, 25),
                        Deadline = new DateTime(2023, 4, 26),
                        Description = "o scurta descriere",
                        Priority = Priority.High,
                        Type = Models.Type.Minor
                    }
                }, ToDLs = new ObservableCollection<TDL>
                {
                    new TDL
                    {
                        Name = "b",
                        Image = new BitmapImage(new Uri(@"/Images/home.png", UriKind.Relative)),
                        ToDLs = new ObservableCollection<TDL>(),
                        Tasks = new ObservableCollection<Models.Task>
                        {
                            new Models.Task
                            {
                                Name = "e",
                        Category = categories[2].Name,
                        Status = false,
                        DateOfFinish = new DateTime(2023, 4, 25),
                        Deadline = new DateTime(2023, 4, 26),
                        Description = "o scurta descriere",
                        Priority = Priority.High,
                        Type = Models.Type.Minor
                            }
                        }
                    }
                } },
                    new TDL
                {
                    Name = "x",
                },
                },
                    Tasks = new ObservableCollection<Models.Task>
                {
                    new Models.Task
                    {
                        Name = "c",
                        Category = categories[1].Name,
                        Status = false,
                        DateOfFinish = new DateTime(2023, 4, 25),
                        Deadline = new DateTime(2023, 4, 26),
                        Description = "o scurta descriere",
                        Priority = Priority.High,
                        Type = Models.Type.Minor
                    }
                }
                },
                
                new TDL
                {
                    Name = "d",
                    Image = new BitmapImage(new Uri(@"/Images/home.png", UriKind.Relative)),
                    ToDLs = new ObservableCollection<TDL>
                {
                    new TDL { Name = "b", Image = new BitmapImage(new Uri(@"/Images/work.png", UriKind.Relative)), Tasks = new ObservableCollection<Models.Task>{
                    new Models.Task
                    {
                        Name = "c",
                        Category = categories[2].Name,
                        Status = false,
                        DateOfFinish = new DateTime(2023, 4, 25),
                        Deadline = new DateTime(2023, 4, 26),
                        Description = "o scurta descriere",
                        Priority = Priority.High,
                        Type = Models.Type.Minor
                    }
                }, ToDLs = new ObservableCollection<TDL>()},
                },
                    Tasks = new ObservableCollection<Models.Task>
                {
                    new Models.Task
                    {
                        Name = "c",
                        Category = categories[1].Name,
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
            TDLsCopy = new ObservableCollection<TDL>(TDLs);
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

        public void EditTaskCategory(Task task, string category)
        {
            task.Category = category;
        }

        public ObservableCollection<int> LoopThroughAllTDLs(ObservableCollection<TDL> tdlCollection)
        {
            foreach(var tdl in tdlCollection)
            {
                if (tdl.Tasks == null) continue;
                foreach (Models.Task task in tdl.Tasks)
                {
                    if (task.Deadline == DateTime.Today)
                    {
                        ints[0]++;
                    }
                    if (task.Deadline == DateTime.Today.AddDays(1))
                    {
                        ints[1]++;
                    }
                    if (task.Deadline < DateTime.Today)
                    {
                        ints[2]++;
                    }
                    if (task.Status == true)
                    {
                        ints[3]++;
                    }
                    if (task.Status == false)
                    {
                        ints[4]++;
                    }
                }
                if (tdl.ToDLs != null && tdl.ToDLs.Count > 0)
                {
                    LoopThroughAllTDLs(tdl.ToDLs);
                }
            }
            return ints;
        }

        public ObservableCollection<TDL> LoopThroughTDLFilter1(ObservableCollection<TDL> tdlCollection)
        {
            ObservableCollection<TDL> tdls = new ObservableCollection<TDL>(tdlCollection);

            foreach (var tdl in tdls)
            {
                if (tdl.Tasks == null) continue;

                var tasksCopy = new List<Models.Task>(tdl.Tasks);

                foreach (Models.Task task in tasksCopy)
                {
                    if (task.Status == false && task.Deadline > DateTime.Today)
                    {
                        //continue;
                        task.IsHidden = false;
                    }
                    else
                    {
                        //tdl.Tasks.Remove(task);
                        task.IsHidden = true;
                    }
                }

                if (tdl.ToDLs != null && tdl.ToDLs.Count > 0)
                {
                    LoopThroughTDLFilter1(tdl.ToDLs);
                }
            }

            return tdls;
        }

        public ObservableCollection<TDL> LoopThroughTDLFilter2(ObservableCollection<TDL> tdlCollection)
        {
            ObservableCollection<TDL> tdls = new ObservableCollection<TDL>(tdlCollection);
            foreach (var tdl in tdls)
            {
                if (tdl.Tasks == null) continue;
                var tasksCopy = new List<Models.Task>(tdl.Tasks);
                foreach(Models.Task task in tasksCopy)
                {
                    if (task.Status == false && task.Deadline < DateTime.Today)
                    {
                        //continue;
                        task.IsHidden = false;
                    }
                    else
                    {
                        //tdl.Tasks.Remove(task);
                        task.IsHidden = true;
                    }
                }
                if(tdl.ToDLs != null && tdl.ToDLs.Count > 0)
                {
                    LoopThroughTDLFilter2(tdl.ToDLs);
                }    
            }
            return tdls;
        }

        public ObservableCollection<TDL> LoopThroughTDLFilter3(ObservableCollection<TDL> tdlCollection)
        {
            ObservableCollection<TDL> tdls = new ObservableCollection<TDL>(tdlCollection);
            foreach (var tdl in tdls)
            {
                if (tdl.Tasks == null) continue;
                var tasksCopy = new List<Models.Task>(tdl.Tasks);
                foreach (Models.Task task in tasksCopy)
                {
                    if (task.Deadline < task.DateOfFinish)
                    {
                        //continue;
                        task.IsHidden = false;
                    }
                    else
                    {
                        //tdl.Tasks.Remove(task);
                        task.IsHidden = true;
                    }
                }
                if (tdl.ToDLs != null && tdl.ToDLs.Count > 0)
                {
                    LoopThroughTDLFilter3(tdl.ToDLs);
                }
            }
            return tdls;
        }

        public ObservableCollection<TDL> LoopThroughTDLFilter4(ObservableCollection<TDL> tdlCollection)
        {
            ObservableCollection<TDL> tdls = new ObservableCollection<TDL>(tdlCollection);
            foreach (var tdl in tdls)
            {
                if (tdl.Tasks == null) continue;
                var tasksCopy = new List<Models.Task>(tdl.Tasks);
                foreach (Models.Task task in tasksCopy)
                {
                    if (task.Status == true)
                    {
                        //continue;
                        task.IsHidden = false;
                    }
                    else
                    {
                        //tdl.Tasks.Remove(task);
                        task.IsHidden = true;
                    }
                }
                if (tdl.ToDLs != null && tdl.ToDLs.Count > 0)
                {
                    LoopThroughTDLFilter4(tdl.ToDLs);
                }
            }
            return tdls;
        }

        public ObservableCollection<TDL> LoopThroughTDLFilter5(ObservableCollection<TDL> tdlCollection, Category category)
        {
            ObservableCollection<TDL> tdls = new ObservableCollection<TDL>(tdlCollection);
            foreach (var tdl in tdls)
            {
                if (tdl.Tasks == null) continue;
                var tasksCopy = new List<Models.Task>(tdl.Tasks);
                foreach (Models.Task task in tasksCopy)
                {
                    if (task.Category == category.Name)
                    {
                        task.IsHidden = false;
                    }
                    else
                    {
                        //tdl.Tasks.Remove(task);
                        task.IsHidden = true;
                    }
                }
                if (tdl.ToDLs != null && tdl.ToDLs.Count > 0)
                {
                    LoopThroughTDLFilter5(tdl.ToDLs, category);
                }
            }
            return tdls;
        }

        public int GetIndex(ObservableCollection<TDL> tDLs, TDL tdl2)
        {
            for(int i =0;i<tDLs.Count;i++)
            {
                if (tDLs[i].Name == tdl2.Name)
                {
                    index = i;
                    break;
                }
                if(tDLs[i].ToDLs != null && tDLs[i].ToDLs.Count > 0)
                {
                    index = GetIndex(tDLs[i].ToDLs, tdl2);
                }
            }
            return index;
        }

        public ObservableCollection<TDL> DeleteTDL(ObservableCollection<TDL> tDLs, TDL selectedTDL)
        {
            foreach(TDL tdl in tDLs)
            {
                if(tdl == selectedTDL)
                {
                    tDLs.Remove(tdl);
                    break;
                }
                if(tdl.ToDLs != null && tdl.ToDLs.Count > 0)
                {
                    DeleteTDL(tdl.ToDLs, selectedTDL);
                }
            }
            return tDLs;
        }
    }
}
