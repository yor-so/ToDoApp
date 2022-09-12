using System.Collections.Generic;
using System.Web.Http;
using ToDoApp.Business.Models;
using ToDoApp.Services.Services.Interfaces;

namespace ToDoApp.Web.Controllers
{
    public class TaskController : ApiController
    {
        private readonly ITasksService _tasksService;

        public TaskController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        // GET: api/Task
        public IEnumerable<TaskDto> Get()
        {
            IEnumerable<TaskDto> tasks = _tasksService.GetAllTasks();

            return tasks;
        }

        // GET: api/Task/5
        public TaskDto Get(int id)
        {
            TaskDto taskDto = _tasksService.GetTask(id);

            return taskDto;
        }

        // POST: api/Task
        public void Post(TaskDto taskDto)
        {
            _tasksService.CreateTask(taskDto);
        }

        // PUT: api/Task/5
        public void Put(int id, [FromBody]TaskDto taskDto)
        {
            _tasksService.UpdateTask(taskDto);
        }

        // DELETE: api/Task/5
        public void Delete(int id)
        {
            _tasksService.DeleteTask(id);
        }
    }
}
