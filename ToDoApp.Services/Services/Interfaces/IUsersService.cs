using System.Collections.Generic;
using ToDoApp.Business.Models;

namespace ToDoApp.Services.Services.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<AppUserDto> GetAllUsers();
    }
}
