using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Business.Models
{
    public class Task
    {
        public int Id { get; set; }

        public bool IsCompleted { get; set; }

        public string Title { get; set; }

        public int EstimatedHours { get; set; }

        public int UserId { get; set; }
    }
}
