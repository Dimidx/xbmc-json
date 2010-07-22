using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XbmcJson
{
    public class XbmcFiles
    {
        private Settings Settings;
        private JsonRpcClient Client; 

        public XbmcFiles(Settings settings, JsonRpcClient client)
        {
            Settings = settings;
            Client = client;
        }
    }
}
