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

        public void CreateTask(TaskDto taskDto)
        {
            _taskRepository.CreateTask(taskDto);
        }

        public void UpdateTask(TaskDto taskDto)
        {
            _taskRepository.UpdateTask(taskDto);
        }

        public IEnumerable<TaskDto> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public TaskDto GetTask(int id)
        {
            return _taskRepository.GetTask(id);
        }

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
