using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;

namespace XbmcJson
{
    public class XbmcStatus
    {
        private JsonRpcClient Client;
        private bool isConnected;

        public XbmcStatus(JsonRpcClient client)
        {
            Client = client;
        }

        public bool IsConnected
        {
            get
            {
                if (Client.Invoke("JSONRPC.Ping").ToString() == "pong")
                {
                    isConnected = true;
                }
                else
                {
                    isConnected = false;
                }

                return isConnected;
            }
        }
     }
}
