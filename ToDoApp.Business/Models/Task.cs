namespace ToDoApp.Business.Models
{
    public class Task
    {
        public int Id { get; set; }

        public bool IsCompleted { get; set; }

        public string Title { get; set; }

        public int EstimatedHours { get; set; }

        public AppUser AppUser { get; set; }

        public int AppUserId { get; set; }
    }
}
