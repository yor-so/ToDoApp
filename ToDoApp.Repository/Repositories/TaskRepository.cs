using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MapsterMapper;
using ToDoApp.Business.Models;
using ToDoApp.Database;
using ToDoApp.Repository.Interfaces;

namespace ToDoApp.Repository.Repositories
{
    public class TaskRepository : IRepository<TaskDto>
    {
        // todo: figure out how to create an interface for ToDoAppContext
        private readonly ToDoAppContext _context;
        private readonly IMapper _mapper;

        // todo: figure out how to create an interface for ToDoAppContext
        public TaskRepository(IMapper mapper)
        {
            _context = new ToDoAppContext();
            _mapper = mapper;
        }

        public void Create(TaskDto taskDto)
        {
            Task taskToCreate = _mapper.Map<Task>(taskDto);

            _ = _context.Tasks.Add(taskToCreate);
            _ = _context.SaveChanges();
        }

        public void Update(TaskDto taskDto)
        {
            Task task = _mapper.Map<Task>(taskDto);
            Task taskToUpdate = _context.Tasks.Single(t => t.Id == taskDto.Id);

            if (taskToUpdate != null)
            {
                taskToUpdate = task;
                _context.Set<Task>().AddOrUpdate(taskToUpdate);
                _ = _context.SaveChanges();
            }
        }

        public TaskDto Get(int id)
        {
            Task task = _context.Tasks.SingleOrDefault(t => t.Id == id);
            TaskDto taskDto = _mapper.Map<TaskDto>(task);

            return taskDto;
        }

        public List<TaskDto> GetAll()
        {
            IEnumerable<Task> tasks = _context.Tasks;
            var tasksDtos = new List<TaskDto>();
            TaskDto taskDto = new TaskDto();

            foreach (Task task in tasks)
            {
                taskDto = _mapper.Map<TaskDto>(task);
                taskDto.AppUserDto = _mapper.Map<AppUserDto>(task.AppUser);
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
