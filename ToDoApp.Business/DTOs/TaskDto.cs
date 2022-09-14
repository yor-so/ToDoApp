using System.ComponentModel.DataAnnotations;
namespace ToDoApp.Business.Models
{
    public class TaskDto
    {
        public int Id { get; set; }

        public bool IsCompleted { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 4,
            ErrorMessage = "Value must be a string between {2} and {1} characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Range(1, 100, ErrorMessage = "Value for {0} must be a integer between {1} and {2}")]
        public int EstimatedHours { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int AppUserId { get; set; }

        public AppUserDto AppUserDto { get; set; }
    }
}
