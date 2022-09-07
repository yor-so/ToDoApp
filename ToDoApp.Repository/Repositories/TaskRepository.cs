using System.Collections.Generic;
using System.Linq;
using ToDoApp.Database;
using ToDoApp.Repository.Interfaces;

namespace ToDoApp.Repository.Repositories
{
    public abstract class TaskRepository : ITaskRepository
    {
        protected readonly ToDoAppContext _context;

        protected TaskRepository(ToDoAppContext context)
        {
            _context = context;
        }

        public void CreateTask(Task task)
        {
            _ = _context.Tasks.Add(task);

            _ = _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            Task taskToUpdate = _context.Tasks.SingleOrDefault(t => t.Id == task.Id);
            taskToUpdate = task;

            _ = _context.SaveChanges();
        }

        public IEnumerable<Task> GetTasks()
        {
            return _context.Tasks;
        }

        public void DeleteTask(Task task)
        {
            // todo: soft delete tasks by updating a status column
            Task taskToDelete = _context.Tasks.SingleOrDefault(t => t.Id == task.Id);
            _context.Tasks.Remove(taskToDelete);

            _ = _context.SaveChanges();
        }
    }
}
