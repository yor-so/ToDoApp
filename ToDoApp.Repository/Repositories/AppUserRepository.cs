using System.Collections.Generic;
using System.Linq;
using ToDoApp.Business.Models;
using ToDoApp.Database;
using ToDoApp.Repository.Interfaces;
using ToDoApp.Repository.Utilities;

namespace ToDoApp.Repository.Repositories
{
    public class AppUserRepository : IRepository<AppUserDto>
    {
        private readonly ToDoAppContext _context;
        private readonly IMapper<AppUser, AppUserDto> _appUserMapper;
        private readonly IMapper<AppUserDto, AppUser> _appUserDtoMapper;

        public AppUserRepository(
            IMapper<AppUser, AppUserDto> appUserMapper,
            IMapper<AppUserDto, AppUser> appUserDtoMapper)
        {
            _context = new ToDoAppContext();
            _appUserMapper = appUserMapper;
            _appUserDtoMapper = appUserDtoMapper;
        }

        public void Create(AppUserDto appUserDto)
        {
            AppUser appUser = _appUserMapper.MapToType(appUserDto);

            _ = _context.AppUsers.Add(appUser);
            _ = _context.SaveChanges();
        }

        public void Update(AppUserDto appUserDto)
        {
            AppUser appUser = _appUserMapper.MapToType(appUserDto);
            AppUser appUserToUpdate = _context.AppUsers.Single(a => a.Id == appUserDto.Id);

            if (appUserToUpdate != null)
            {
                appUserToUpdate = appUser;
                _ = _context.SaveChanges();
            }
        }

        public AppUserDto Get(int id)
        {
            AppUser appUser = _context.AppUsers.SingleOrDefault(a => a.Id == id);
            AppUserDto appUserDto = _appUserDtoMapper.MapToType(appUser);

            return appUserDto;
        }

        public List<AppUserDto> GetAll()
        {
            IEnumerable<AppUser> appUsers = _context.AppUsers;
            var appUsersDtos = new List<AppUserDto>();
            var appUserDto = new AppUserDto();

            foreach (AppUser appUser in appUsers)
            {
                appUserDto = _appUserDtoMapper.MapToType(appUser);
                appUsersDtos.Add(appUserDto);
            }

            return appUsersDtos;
        }

        public void Delete(int id)
        {
            AppUser appUserToDelete = _context.AppUsers.Single(a => a.Id == id);

            if (appUserToDelete != null)
            {
                _ = _context.AppUsers.Remove(appUserToDelete);
                _ = _context.SaveChanges();
            }
        }
    }
}
