using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using ToDoApp.Business.Models;
using ToDoApp.Database;
using ToDoApp.Repository.Interfaces;
using ToDoApp.Repository.Repositories;
using ToDoApp.Repository.Utilities;
using ToDoApp.Services.Services; 
using ToDoApp.Services.Services.Interfaces;

namespace ToDoApp.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // dependency injection config for web api
            var webApiContainer = new Container();
            webApiContainer.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // registering web api dependencies
            webApiContainer.Register<IUsersService, UsersService>(Lifestyle.Scoped);
            webApiContainer.Register<ITasksService, TasksService>(Lifestyle.Scoped);
            webApiContainer.Register<IRepository<AppUserDto>, AppUserRepository>(Lifestyle.Scoped);
            webApiContainer.Register<IRepository<TaskDto>, TaskRepository>(Lifestyle.Scoped);
            webApiContainer.Register<IMapper<Task, TaskDto>, MapsterMapper<Task, TaskDto>>(Lifestyle.Scoped);
            webApiContainer.Register<IMapper<TaskDto, Task>, MapsterMapper<TaskDto, Task>>(Lifestyle.Scoped);
            webApiContainer.Register<IMapper<AppUser, AppUserDto>, MapsterMapper<AppUser, AppUserDto>>(Lifestyle.Scoped);
            webApiContainer.Register<IMapper<AppUserDto, AppUser>, MapsterMapper<AppUserDto, AppUser>>(Lifestyle.Scoped);

            webApiContainer.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            webApiContainer.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(webApiContainer);
        }
    }
}
