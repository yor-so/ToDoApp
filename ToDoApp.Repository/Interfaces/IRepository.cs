using System.Collections.Generic;
using ToDoApp.Database;

namespace ToDoApp.Repository.Interfaces
{
    public interface ITaskRepository
    {
        void CreateTask(Task task);

        void UpdateTask(Task task);

        IEnumerable<Task> GetTasks();

        void DeleteTask(Task task);
    }
}
