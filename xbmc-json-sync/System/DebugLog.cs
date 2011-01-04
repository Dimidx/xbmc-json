using System;
using System.IO;

namespace XbmcJson
{
    public class DebugLog
    {
        private static string LogName = "xbmc-json-debug.log";

        public static void EraseLog(String logFile)
        {
            if (File.Exists(logFile))
            {
                File.Delete(logFile);
            }
        }

        public static void EraseLog()
        {
            #if PocketPC
            string LogFile = (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + LogName).Replace("file:\\", "");
            #else
            string LogFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + LogName;
            #endif

            if (File.Exists(LogFile))
            {
                File.Delete(LogFile);
            }
        }

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
            #if PocketPC
            string LogFile = (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + LogName).Replace("file:\\", "");
            #else
            string LogFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + LogName;
            #endif

            using (StreamWriter logWriter = new StreamWriter(LogFile, true))
            {
                DateTime dateTime = DateTime.Now;
                logWriter.WriteLine("{0:G}", dateTime + " - " + logContent);
            }
        }
    }
}
