using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XbmcJson
{
    public class Settings
    {
        public Uri XbmcUri;
        public string XbmcIp;
        public Int32 XbmcPort;
        public string XbmcUser;
        public string XbmcPass;

        public Settings(String XbmcIp, Int32 XbmcPort, String XbmcUser, String XbmcPass)
        {
            this.XbmcIp = XbmcIp;
            this.XbmcPort = XbmcPort;
            this.XbmcUser = XbmcUser;
            this.XbmcPass = XbmcPass;
            XbmcUri = new Uri("http://" + XbmcIp + ":" + XbmcPort + "/jsonrpc");
        }

        public static Settings SettingsFromFile(String File)
        {
            string xbmcIp;
            Int32 xbmcPort;
            string xbmcUser;
            string xbmcPass;

            using (StreamReader reader = new StreamReader(File))
            {
                xbmcIp = reader.ReadLine();
                xbmcPort = Convert.ToInt32(reader.ReadLine());
                xbmcUser = reader.ReadLine();
                xbmcPass = reader.ReadLine();
            }

            Settings ReturnSettings = new Settings(xbmcIp, xbmcPort, xbmcUser, xbmcPass);
            return ReturnSettings;
        }
    }
}
