using System;
using System.Collections.Generic;
using ToDoApp.Business.Models;
using ToDoApp.Repository.Interfaces;
using ToDoApp.Services.Services.Interfaces;

namespace ToDoApp.Services.Services
{
    public class TasksService : ITasksService
    {
        private readonly IRepository<TaskDto> _taskRepository;

        public TasksService(IRepository<TaskDto> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void CreateTask(TaskDto taskDto)
        {
            _taskRepository.Create(taskDto);
        }

        public void UpdateTask(TaskDto taskDto)
        {
            _taskRepository.Update(taskDto);
        }

        public IEnumerable<TaskDto> GetAllTasks()
        {
            return _taskRepository.GetAll();
        }

        public TaskDto GetTask(int id)
        {
            return _taskRepository.Get(id);
        }

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
