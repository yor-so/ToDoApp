using System;
using ToDoApp.Database;

namespace TodoApp.ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            var user = new AppUser()
            {
                FullName = "Roy Ramosu",
            };
             
            using (var context = new ToDoAppContext())
            {
                context.Database.Log = Console.WriteLine;
                context.AppUsers.Add(user);
                context.SaveChanges();

                Console.ReadKey();
            }
        }
    }
}
