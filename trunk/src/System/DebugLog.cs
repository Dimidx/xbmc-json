using System;
using System.IO;

namespace XbmcJson
{
    public class DebugLog
    {
        private static string LogName = "xbmc-json-debug.log";          

        public static void WriteLog(String logFile, String logContent)
        {
            using (StreamWriter logWriter = new StreamWriter(logFile, true))
            {
                DateTime dateTime = DateTime.Now;
                logWriter.WriteLine("{0:G}", dateTime + " - " + logContent);
            }
        }

        public static void WriteLog(String logContent)
        {
            string LogFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + LogName;

            using (StreamWriter logWriter = new StreamWriter(LogFile, true))
            {
                DateTime dateTime = DateTime.Now;
                logWriter.WriteLine("{0:G}", dateTime + " - " + logContent);
            }
        }
    }
}
