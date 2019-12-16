using System;
using System.IO;

namespace ProcessMonitor
{
    public interface ILogger
    {
        void Log(string info);
    }

    public class Logger : ILogger
    {
        string filePath = ".\\log.txt";
        bool append = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public void Log(string info)
        {
            TraceConsole(info);
            TraceFile(info);
        }

        void TraceConsole(string info)
        {
            Console.WriteLine(Environment.NewLine + info);
        }

        async void TraceFile(string info)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, append, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(info);
                    append = true;
                }
            }

            catch (UnauthorizedAccessException e)
            {
               TraceConsole(e.Message);
            }

            catch (Exception e)
            {
                TraceConsole(e.Message);
            }
        }
    }
}