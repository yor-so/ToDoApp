using System.Collections.Generic;
using ToDoApp.Business.Models;

namespace ToDoApp.Services.Services.Interfaces
{
    public interface ITasksService
    {
        void CreateTask(TaskDto taskDto);

        TaskDto GetTask(int id);

        IEnumerable<TaskDto> GetAllTasks();

        void UpdateTask(TaskDto taskDto);

        void DeleteTask(int id);
    }
}
