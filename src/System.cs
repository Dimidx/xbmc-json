using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace XbmcJson
{
   public class XbmcSystem
    {
        private Settings Settings;
        private JsonRpcClient Client;

        public XbmcSystem(Settings settings, JsonRpcClient client)
        {
            Settings = settings;
            Client = client;
        }

        public object GetInfoLabels()
        {
            return Client.Invoke("System.GetInfoLabels");
        }

        public object GetInfoBooleans()
        {
            return Client.Invoke("System.GetInfoBooleans");
        }

        public void ShutDown()
        {
            Client.Invoke("System.Shutdown");
        }

        public void Suspend()
        {
            Client.Invoke("System.Suspend");
        }

        public void Hibernate()
        {
            Client.Invoke("System.Hibernate");
        }

        public void Reboot()
        {
            Client.Invoke("System.Reboot");
        }
    }
}
