using System;
using System.Threading.Tasks;

namespace ProcessMonitor
{
    public interface IApplication
    {
        void Run(string[] args);
    }

    public class Application : IApplication
    {
        IMonitoring monitoring;
        IAppParams appParams;

        public Application(IMonitoring monitoring, IAppParams appParams)
        {
            this.monitoring = monitoring;
            this.appParams = appParams;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public void Run(string[] args)
        {
            if (!appParams.Load(args))
            {
                Console.WriteLine("Incorrect input params!");
                Console.ReadKey();
                return;
            }

            Task.Factory.StartNew(() => monitoring.KillProcess(appParams));
            Console.WriteLine("Monitoring... press <Esc> to exit");

            while (!monitoring.Cancellation.IsCancellationRequested)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    monitoring.Cancellation.Cancel();
                }
            }
        }
    }
}
