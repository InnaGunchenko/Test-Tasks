using Autofac;

namespace ProcessMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            var app = container.Resolve<IApplication>();
            app.Run(args);
        }
    }
}



