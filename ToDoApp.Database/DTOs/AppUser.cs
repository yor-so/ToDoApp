using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Database.DTOs
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }
    }
}
