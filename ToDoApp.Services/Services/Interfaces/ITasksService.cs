using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Services.Models.Interfaces;

namespace ToDoApp.Services.Services.Interfaces
{
    /// todo: I can use genetic interface with CRUD methods for different T classes
    public interface ITasksService
    {
        void CreateTask(ITaskModel taskModel);

        void UpdateTask(ITaskModel taskModel);

        IEnumerable<ITaskModel> GetAllTasks();

        ITaskModel GetTask(int id);

        void DeleteTask(int id);
    }
}
