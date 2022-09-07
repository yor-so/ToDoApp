using ToDoApp.Services.Models.Interfaces;

namespace ToDoApp.Services.Models
{
    public class TaskModel : ITaskModel
    {
        public int Id { get; set; }
        public int IsCompleted { get; set; }
        public string Title { get; set; }
        public int EstimatedHours { get; set; }
        public int AppUserId { get; set; }
    }
}
