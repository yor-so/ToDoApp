namespace ToDoApp.Services.Models.Interfaces
{
    public interface ITaskModel
    {
        int Id { get; set; }

        int IsCompleted { get; set; }

        string Title { get; set; }

        int EstimatedHours { get; set; }

        int AppUserId { get; set; }
    }
}
