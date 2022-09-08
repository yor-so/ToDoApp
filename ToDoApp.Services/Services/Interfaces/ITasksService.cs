using System.Collections.Generic;
using ToDoApp.Business.Models;

namespace ToDoApp.Services.Services.Interfaces
{
    /// todo: I can use generic interface with CRUD methods for different T classes
    public interface ITasksService
    {
        void CreateTask(TaskDto taskModel);

        void UpdateTask(TaskDto taskModel);

        IEnumerable<TaskDto> GetAllTasks();

        TaskDto GetTask(int id);

        void DeleteTask(int id);
    }
}
