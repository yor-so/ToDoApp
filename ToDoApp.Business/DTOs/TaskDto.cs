namespace ToDoApp.Business.Models
{
    public class TaskDto
    {
        public int Id { get; set; }

        public bool IsCompleted { get; set; }

        public string Title { get; set; }

        public int EstimatedHours { get; set; }

        public int AppUserId { get; set; }

        public AppUserDto AppUserDto { get; set; }
    }
}
