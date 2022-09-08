using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Lifestyles;          // for web api
using SimpleInjector.Integration.WebApi;  // for web api
using ToDoApp.Business.Models;
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
            webApiContainer.Register<ITasksService, TasksService>(Lifestyle.Scoped);
            webApiContainer.Register<ITaskRepository, TaskRepository>(Lifestyle.Scoped);

            webApiContainer.Register<IMapper<Database.Task, TaskDto>, MapsterMapper<Database.Task, TaskDto>>(Lifestyle.Scoped);
            webApiContainer.Register<IMapper<TaskDto, Database.Task>, MapsterMapper<TaskDto, Database.Task>>(Lifestyle.Scoped);

            webApiContainer.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            webApiContainer.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(webApiContainer);
        }
    }
}
