using System.Collections.Generic;
using System.Linq;
using ToDoApp.Business.Models;
using ToDoApp.Database;
using ToDoApp.Repository.Interfaces;
using ToDoApp.Repository.Utilities;

namespace ToDoApp.Repository.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        // todo: figure out how to create an interface for ToDoAppContext
        private readonly ToDoAppContext _context;
        private readonly IMapper<Task, TaskDto> _taskMapper;
        private readonly IMapper<TaskDto, Task> _taskDtoMapper;

        // todo: figure out how to create an interface for ToDoAppContext
        public TaskRepository(
            IMapper<Task, TaskDto> taskMapper,
            IMapper<TaskDto, Task> taskDtoMapper)
        {
            _context = new ToDoAppContext();
            _taskMapper = taskMapper;
            _taskDtoMapper = taskDtoMapper;
        }

        public void CreateTask(TaskDto taskDto)
        {
            Task taskToCreate = _taskMapper.MapToType(taskDto);
            
            _ = _context.Tasks.Add(taskToCreate);
            _ = _context.SaveChanges();
        }

        public void UpdateTask(TaskDto taskDto)
        {
            Task task = _taskMapper.MapToType(taskDto);
                
            Task taskToUpdate = _context.Tasks.SingleOrDefault(t => t.Id == taskDto.Id);
            taskToUpdate = task;

            _ = _context.SaveChanges();
        }

        public TaskDto GetTask(int id)
        {
            Task task = _context.Tasks.SingleOrDefault(t => t.Id == id);
            TaskDto taskDto = _taskDtoMapper.MapToType(task);
            return taskDto;
        }

        public List<TaskDto> GetAllTasks()
        {
            IEnumerable<Task> tasks = _context.Tasks;
            var tasksDto = new List<TaskDto>();

            foreach (Task task in tasks)
            {
                TaskDto taskDto = _taskDtoMapper.MapToType(task);
                tasksDto.Add(taskDto);
            }
            
            return tasksDto;
        }

        public void DeleteTask(TaskDto taskDto)
        {
            // todo: soft delete tasks by updating a status column
            Task task = _taskMapper.MapToType(taskDto);
            Task taskToDelete = _context.Tasks.SingleOrDefault(t => t.Id == task.Id);
            
            _ = _context.Tasks.Remove(taskToDelete);
            _ = _context.SaveChanges();
        }
    }
}
