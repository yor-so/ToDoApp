using System.Collections.Generic;
using ToDoApp.Business.Models;
using ToDoApp.Database;

namespace ToDoApp.Repository.Interfaces
{
    public interface ITaskRepository
    {
        void CreateTask(TaskDto task);

        void UpdateTask(TaskDto task);

        IEnumerable<TaskDto> GetTasks();

        void DeleteTask(TaskDto task);
    }
}
