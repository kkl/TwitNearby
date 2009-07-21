using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using TwitsNearby.Models;

namespace TwitsNearby
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication, IContainerAccessor
    {

        private static UnityContainer _container;

        public static IUnityContainer Container
        {
            get { return _container; }
        }

        IUnityContainer IContainerAccessor.Container 
        {
            get { return Container; }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
               "Tweet",                                              // Route name
               "Tweet/{id}/{fmt}",                           // URL with parameters
               new { controller = "Tweet", action = "Tweet", id = "", fmt="html" }  // Parameter defaults
            );

            routes.MapRoute(
               "Nearby",                                              // Route name
               "Nearby/{id}",                           // URL with parameters
               new { controller = "Home", action = "NearBy", id = "" }  // Parameter defaults
            );
            routes.MapRoute(
                "byScreenName",                                              // Route name
                "{id}",                           // URL with parameters
                new { controller = "Home", action = "Home", id = "" }  // Parameter defaults
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Home", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            InitializeContainer();
            RegisterRoutes(RouteTable.Routes);
        }

        private void InitializeContainer()
        {
            if (_container == null)
                _container = new UnityContainer();

            IControllerFactory controllerFactory =
              new UnityControllerFactory(_container);

            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            _container.RegisterType<IStatusesService, StatusesService>(new ContainerControlledLifetimeManager());

        }
    }
}