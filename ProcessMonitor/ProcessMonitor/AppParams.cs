using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProcessMonitor
{
    public interface IAppParams
    {
        bool Load(string[] args, int countArgs = 3);
        string ProcessName { get; set; }
        TimeSpan LifeTime { get; set; }
        TimeSpan RefreshDelay { get; set; }
    }

    public class AppParams : IAppParams
    {
        public string ProcessName { get; set; }
        public TimeSpan LifeTime { get; set; }
        public TimeSpan RefreshDelay { get; set; }

        /// <summary>
        /// Load application settings
        /// </summary>
        /// <param name="args"></param>
        /// <param name="countArgs"></param>
        /// <returns></returns>
        public bool Load(string[] args, int countArgs)
        {
            if (!this.CheckAndLoadArgs(args, countArgs))
            {
                return false;
            }

            return true;
        }

        private bool CheckAndLoadArgs(string[] args, int countArgs)
        {
            if (args.Length != countArgs)
                return false;

            this.ProcessName = args[0];
            TimeSpan timeSpan;

            if (!CheckTimeSpan(args[1], out timeSpan))
                return false;

            this.LifeTime = timeSpan;

            if (!CheckTimeSpan(args[2], out timeSpan))
                return false;

            this.RefreshDelay = timeSpan;
            return true;
        }

        private bool CheckNameProcess(string arg)
        {
            try
            {
                return Process.GetProcessesByName(arg).Length != 0;
            }
            catch
            {
                return false;
            }
        }

        private bool CheckTimeSpan(string arg, out TimeSpan timeSpan)
        {
            timeSpan = default(TimeSpan);
            try
            {
                timeSpan = TimeSpan.FromMinutes(Convert.ToInt32(arg));
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}