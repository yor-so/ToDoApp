using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoApp.Business.Models;
using ToDoApp.Services.Services.Interfaces;

namespace ToDoApp.Web.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: api/User
        public IEnumerable<AppUserDto> Get()
        {
            IEnumerable<AppUserDto> allUsers = _usersService.GetAllUsers();

            return allUsers;
        }
    }
}
