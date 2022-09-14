using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage Post(TaskDto taskDto)
        {
            if (ModelState.IsValid)
            {
                _tasksService.CreateTask(taskDto);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

        }

        // PUT: api/Task/5
        public HttpResponseMessage Put(int id, [FromBody]TaskDto taskDto)
        {
            if (ModelState.IsValid)
            {
                _tasksService.UpdateTask(taskDto);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        // DELETE: api/Task/5
        public void Delete(int id)
        {
            _tasksService.DeleteTask(id);
        }
    }
}
