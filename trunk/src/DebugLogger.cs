using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XbmcJson
{
    public class DebugLogger
    {
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
            using (StreamWriter logWriter = new StreamWriter(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\xbmc remote.log", true))
            {
                DateTime dateTime = DateTime.Now;
                logWriter.WriteLine("{0:G}", dateTime + " - " + logContent);
            }
        }
    }
}
