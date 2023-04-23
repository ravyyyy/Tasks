using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Models
{
    //public enum Status { Created, InProgress, Done };
    public enum Type { Minor, Major }
    //public enum Category { Work, Home, Outside, Shopping }
    public enum Priority { Low, Medium, High };

    public class Task : BaseVM
    {
        private bool status;
        private string name;
        private string description;
        //private Status status;
        private Type type;
        //private Category category;
        private Priority priority;
        private DateTime deadline;
        private DateTime dateOfFinish;
        private string category;

        public string Category
        {
            get { return category; }
            set 
            { 
                category = value; 
                OnPropertyChanged("Category");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

       //public Status Status
       // {
       //     get { return status; }
       //     set
       //     {
       //         status = value;
       //         OnPropertyChanged("Status");
       //     }
       // }

        public bool Status
        {
            get { return status; }
            set
            { status = value;
                OnPropertyChanged("Statsus");
            }
        }

        public Type Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        //public Category Category
        //{
        //    get { return category; }
        //    set
        //    {
        //        category = value;
        //        OnPropertyChanged("Category");
        //    }
        //}

        public Priority Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                OnPropertyChanged("Priority");
            }
        }

        public DateTime Deadline
        {
            get { return deadline; }
            set
            {
                deadline = value;
                OnPropertyChanged("Deadline");
            }
        }

        public DateTime DateOfFinish
        {
            get { return dateOfFinish; }
            set
            {
                dateOfFinish = value;
                OnPropertyChanged("DateOfFinish");
            }
        }

        
    }
}
