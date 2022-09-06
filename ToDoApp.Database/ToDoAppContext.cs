using System.Data.Entity;
using ToDoApp.Database.DTOs;

namespace ToDoApp.Database
{
    public class ToDoAppContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) { 
            
        }
    }
}
