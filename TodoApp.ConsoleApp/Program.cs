using System;
using ToDoApp.Database;
using ToDoApp.Database.DTOs;

namespace TodoApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = new AppUser()
            {
                FullName = "Roy Ramos",
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
