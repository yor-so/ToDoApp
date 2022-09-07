using System.Collections.Generic;
using System.Linq;
using Mapster;
using ToDoApp.Business.Models;
using ToDoApp.Database;
using ToDoApp.Repository.Interfaces;
using ToDoApp.Repository.Utilities;

namespace ToDoApp.Repository.Repositories
{
    public abstract class TaskRepository : ITaskRepository
    {
        private readonly ToDoAppContext _context;
        private readonly IMapper<Task, TaskDto> _mapper;

        protected TaskRepository(ToDoAppContext context, IMapper<Task, TaskDto> mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateTask(TaskDto taskDto)
        {
            Task taskToCreate = _mapper.MapToType(taskDto);
            
            _ = _context.Tasks.Add(taskToCreate);
            _ = _context.SaveChanges();
        }

        public void UpdateTask(TaskDto taskDto)
        {
            Task task = _mapper.MapToType(taskDto);
                
            Task taskToUpdate = _context.Tasks.SingleOrDefault(t => t.Id == taskDto.Id);
            taskToUpdate = task;

            _ = _context.SaveChanges();
        }

        public IEnumerable<TaskDto> GetTasks()
        {
            IEnumerable<Task> tasks = _context.Tasks;
            IEnumerable<TaskDto> tasksDto = _mapper.Adapt<IEnumerable<TaskDto>>();
            
            return tasksDto;
        }

        public void DeleteTask(TaskDto taskDto)
        {
            // todo: soft delete tasks by updating a status column
            Task task = _mapper.MapToType(taskDto);
            Task taskToDelete = _context.Tasks.SingleOrDefault(t => t.Id == task.Id);
            
            _ = _context.Tasks.Remove(taskToDelete);
            _ = _context.SaveChanges();
        }
    }
}
