using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Repository.Interfaces;
using ToDoApp.Services.Models.Interfaces;
using ToDoApp.Services.Services.Interfaces;

namespace ToDoApp.Services.Services
{
    public class TasksService : ITasksService
    {
        private ITaskRepository _taskRepository;

        public TasksService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void CreateTask(ITaskModel taskModel)
        {
            
        }

        public void UpdateTask(ITaskModel taskModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITaskModel> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public ITaskModel GetTask(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
