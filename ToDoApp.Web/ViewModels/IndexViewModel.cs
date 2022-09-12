using System.Collections.Generic;
using System.Linq;
using ToDoApp.Business.Models;

namespace ToDoApp.Web.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel(IEnumerable<TaskDto> tasks)
        {
            var taskDtos = tasks.ToList();

            Tasks = taskDtos;
        }

        public IEnumerable<TaskDto> Tasks;
    }
}