using System.Collections.Generic;
using ToDoApp.Business.Models;
using ToDoApp.Database;

namespace ToDoApp.Repository.Interfaces
{
    public interface ITaskRepository
    {
        void CreateTask(TaskDto task);

        void UpdateTask(TaskDto task);

        TaskDto GetTask(int id);

        List<TaskDto> GetAllTasks();

        void DeleteTask(TaskDto task);
    }
}
