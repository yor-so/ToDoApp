using System.Data.Entity;
using ToDoApp.Database.DTOs;

namespace ToDoApp.Database
{
    public class ToDoAppContext : DbContext
    {
        DbSet<AppUser> AppUsers { get; set; }
        DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { 
            
        }
    }
}
