using System.Collections.Generic;
using ToDoApp.Business.Models;
using ToDoApp.Database;

namespace ToDoApp.Repository.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T task);

        void Update(T task);

        T Get(int id);

        List<T> GetAll();

        void Delete(int id);
    }
}
