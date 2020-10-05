using Cinema.Services;
using LightInject;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Cinema
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// все действия при старте приложения.
        /// </summary>
        protected void Application_Start()
        {
            var container = new ServiceContainer();
            container.RegisterControllers();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            container.Register<ITicketService, JsonTicketService>(new PerRequestLifeTime());
            //container.Register<ITicketService, SqlTicketService>(new PerRequestLifeTime()); //for example
            container.EnableMvc();
        }
    }
}
