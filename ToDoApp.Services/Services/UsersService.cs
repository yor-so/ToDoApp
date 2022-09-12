using System.Collections.Generic;
using ToDoApp.Business.Models;
using ToDoApp.Repository.Interfaces;
using ToDoApp.Services.Services.Interfaces;

namespace ToDoApp.Services.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<AppUserDto> _usersRepository;

        public UsersService(IRepository<AppUserDto> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IEnumerable<AppUserDto> GetAllUsers()
        {
            var allUsers = _usersRepository.GetAll();

            return allUsers;
        }
    }
}
