using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

using NLog;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

using Project.WebClient.Filters;
using Project.Business;
using Project.Common.Contracts;

namespace Project.WebClient
{
    public class MvcApplication : System.Web.HttpApplication
    {
        readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            _logger.Info("Application Start");

            MvcHandler.DisableMvcResponseHeader = true;
            HtmlHelper.ClientValidationEnabled =
            HtmlHelper.UnobtrusiveJavaScriptEnabled = false;

            GlobalFilters.Filters.Add(new HandleErrorAttribute());
            GlobalFilters.Filters.Add(new AuthorizeAttribute());
            GlobalFilters.Filters.Add(new LogAttribute());

            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteTable.Routes.MapRoute("Default", "{controller}/{action}", new { controller = "Home", action = "Index" });

            RegisterDependencies();
        }

        private static void RegisterDependencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<IPersonService, PersonService>();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            _logger.Error(exception, "Application Error");
        }
    }
}
