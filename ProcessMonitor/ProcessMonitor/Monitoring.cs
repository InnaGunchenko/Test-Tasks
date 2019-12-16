using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessMonitor
{
    public interface IMonitoring
    {
        void KillProcess(IAppParams appParams);
        CancellationTokenSource Cancellation { get; set; }
    }

    public class Monitoring : IMonitoring
    {
        ILogger logger;
        public CancellationTokenSource Cancellation { get; set; }

        public Monitoring(ILogger logger)
        {
            this.logger = logger;
            this.Cancellation = new CancellationTokenSource();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appParams"></param>
        public void KillProcess(IAppParams appParams)
        {
            while (!this.Cancellation.Token.IsCancellationRequested)
            {
                Process.GetProcessesByName(appParams.ProcessName).
                Where(proces => DateTime.Compare(proces.StartTime.Add(appParams.LifeTime), DateTime.Now) < 0).ToList().
                ForEach(proces =>
                {
                    try
                    {
                        proces.Kill();
                        logger.Log(string.Format("Process: {0} Start Time: {1} was killed", proces.ProcessName, proces.StartTime));
                    }
                    catch (InvalidOperationException e)
                    {
                        logger.Log(e.Message);
                    }

                    catch (Exception e)
                    {
                        logger.Log(e.Message);
                    }
                });
                Task.Delay(appParams.RefreshDelay).Wait();
            }
        }

    }
}
