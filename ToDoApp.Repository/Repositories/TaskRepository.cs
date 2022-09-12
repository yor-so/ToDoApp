using System.Collections.Generic;
using System.Linq;
using ToDoApp.Business.Models;
using ToDoApp.Database;
using ToDoApp.Repository.Interfaces;
using ToDoApp.Repository.Utilities;

namespace ToDoApp.Repository.Repositories
{
    public class TaskRepository : IRepository<TaskDto>
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

        public void Create(TaskDto taskDto)
        {
            Task taskToCreate = _taskMapper.MapToType(taskDto);
            
            _ = _context.Tasks.Add(taskToCreate);
            _ = _context.SaveChanges();
        }

        public void Update(TaskDto taskDto)
        {
            Task task = _taskMapper.MapToType(taskDto);
            Task taskToUpdate = _context.Tasks.Single(t => t.Id == taskDto.Id);

            if (taskToUpdate != null)
            {
                taskToUpdate = task;
                _ = _context.SaveChanges();
            }
        }

        public TaskDto Get(int id)
        {
            Task task = _context.Tasks.SingleOrDefault(t => t.Id == id);
            TaskDto taskDto = _taskDtoMapper.MapToType(task);

            return taskDto;
        }

        public List<TaskDto> GetAll()
        {
            IEnumerable<Task> tasks = _context.Tasks;
            var tasksDtos = new List<TaskDto>();
            TaskDto taskDto = new TaskDto();

            foreach (Task task in tasks)
            {
                taskDto = _taskDtoMapper.MapToType(task);
                tasksDtos.Add(taskDto);
            }
            
            return tasksDtos;
        }

        public void Delete(int id)
        {
            // todo: soft delete tasks by updating a status column
            Task taskToDelete = _context.Tasks.Single(t => t.Id == id);

            if (taskToDelete != null)
            {
                _ = _context.Tasks.Remove(taskToDelete);
                _ = _context.SaveChanges();
            }
        }
    }
}
