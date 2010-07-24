﻿using System;
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
            using (StreamWriter logWriter = new StreamWriter(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()) + "\\xbmcjson debug.log", true))
            {
                DateTime dateTime = DateTime.Now;
                logWriter.WriteLine("{0:G}", dateTime + " - " + logContent);
            }
        }
    }
}
