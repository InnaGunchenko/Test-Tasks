using Autofac;

namespace ProcessMonitor
{
    public static class ContainerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<AppParams>().As<IAppParams>();
            builder.RegisterType<Logger>().As<ILogger>();
            builder.RegisterType<Monitoring>().As<IMonitoring>();
            return builder.Build();
        }
    }
}
