using System;
using System.Collections.Generic;
using ToDoApp.Business.Models;
using ToDoApp.Repository.Interfaces;
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

        public void CreateTask(TaskDto taskModel)
        {
            
        }

        public void UpdateTask(TaskDto taskModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskDto> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public TaskDto GetTask(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
