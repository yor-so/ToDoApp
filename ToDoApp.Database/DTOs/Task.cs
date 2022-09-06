using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Database.DTOs
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int EstimatedHours { get; set; }

        [Required]
        public AppUser AppUser { get; set; }

        [Required]
        public int AppUserId { get; set; }
    }
}
