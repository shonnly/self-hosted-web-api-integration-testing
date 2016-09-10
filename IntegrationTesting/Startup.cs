namespace IntegrationTesting
{
    using System;
    using System.Web;
    using System.Web.Http;
    using Ninject;
    using Ninject.Web.Common;
    using Owin;
    using ServiceLayer;

    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);

            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);

            var resolver = new NinjectDependencyResolver(kernel);
            config.DependencyResolver = resolver;
        }


        private static void RegisterServices(StandardKernel kernel)
        {
            kernel.Bind<IValuesService>().To<PersonsService>();
        }
    }
}
