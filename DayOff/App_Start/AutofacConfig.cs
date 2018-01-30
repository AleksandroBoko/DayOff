using Autofac;
using Autofac.Integration.WebApi;
using DayOff.Services.Controls;
using DayOff.Services.Controls.Implementation;
using System.Reflection;
using System.Web.Http;

namespace DayOff.App_Start
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<InfoService>()
                .As<IService>()
                .InstancePerRequest();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}