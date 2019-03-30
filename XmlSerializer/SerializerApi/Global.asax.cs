using SerializerApi.Migrations;
using SerializerApi.ModelContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SerializerApi.DependencyInjection;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;

namespace SerializerApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        private static IWindsorContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeDatabase();
            ConfigureWindsor(GlobalConfiguration.Configuration);
        }

        private void InitializeDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion< XmlSerializerDatabase, Migrations.Configuration>());
            var context = new XmlSerializerDatabase();
            context.Database.Initialize(true);
        }

        private static void ConfigureWindsor(HttpConfiguration configuration)
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());
            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel, true));
            var dependencyResolver = new WindsorDependencyResolver(_container);
            configuration.DependencyResolver = dependencyResolver;
        }
    }
}
