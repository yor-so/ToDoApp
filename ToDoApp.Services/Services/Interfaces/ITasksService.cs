using System.Collections.Generic;
using ToDoApp.Business.Models;

namespace ToDoApp.Services.Services.Interfaces
{
    /// todo: I can use generic interface with CRUD methods for different T classes
    public interface ITasksService
    {
        void CreateTask(TaskDto taskDto);

        TaskDto GetTask(int id);

        IEnumerable<TaskDto> GetAllTasks();

        void UpdateTask(TaskDto taskDto);

        void DeleteTask(int id);
    }
}
