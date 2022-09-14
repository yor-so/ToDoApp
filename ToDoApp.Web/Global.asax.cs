using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Mapster;
using MapsterMapper;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using ToDoApp.Business.Models;
using ToDoApp.Repository.Interfaces;
using ToDoApp.Repository.Repositories;
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

            webApiContainer.Register<IUsersService, UsersService>(Lifestyle.Scoped);
            webApiContainer.Register<ITasksService, TasksService>(Lifestyle.Scoped);
            webApiContainer.Register<IRepository<AppUserDto>, AppUserRepository>(Lifestyle.Scoped);
            webApiContainer.Register<IRepository<TaskDto>, TaskRepository>(Lifestyle.Scoped);
            webApiContainer.RegisterInstance(new TypeAdapterConfig());
            webApiContainer.Register<IServiceProvider, Container>(Lifestyle.Scoped);
            webApiContainer.Register<IMapper, ServiceMapper>(Lifestyle.Scoped);

            webApiContainer.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            webApiContainer.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(webApiContainer);
        }
    }
}
