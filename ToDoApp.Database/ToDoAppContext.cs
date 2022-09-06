using System.Data.Entity;
using ToDoApp.Business.Models;

namespace ToDoApp.Database
{
    public class ToDoAppContext : DbContext
    {
        DbSet<AppUser> AppUsers { get; set; }
        DbSet<Task> Tasks { get; set; }
    }
}
