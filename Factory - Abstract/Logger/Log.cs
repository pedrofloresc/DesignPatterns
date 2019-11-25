using System;
using System.IO;

namespace Logger
{
    public sealed class Log : ILog
    {
        private static readonly Log instance = new Log();
        public static Log GetInstance
        {
            get
            {
                return instance;
            }
        }
        private Log()
        {
        }

        public void LogException(string message)
        {
            string filename = "Log_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".log";
            string path = AppDomain.CurrentDomain.BaseDirectory + filename;
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message + " - " + DateTime.Now.ToString());
                writer.Flush();
            }
        }
    }



}
