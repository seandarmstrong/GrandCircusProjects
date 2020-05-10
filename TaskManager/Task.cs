using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    //the task class sets the properties for the Task list when adding and editing and the constructor makes sure the information is entered
    //before adding the task to the list.
    public class Task
    {
        public Task(string dueDate, string name, string description)
        {
            DueDate = dueDate;
            Name = name;
            Description = description;
        }
        public bool Status { get; set; }
        public string DueDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
