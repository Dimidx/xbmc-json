using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                JObject query = (JObject)Client.Invoke("JSONRPC.Ping");

                if (query != null)
                {
                    if ((string)Client.Invoke("JSONRPC.Ping") == "pong")
                    {
                        isConnected = true;
                    }
                    else
                    {
                        isConnected = false;
                    }
                }
                else
                    isConnected = false;

                return isConnected; 
            }
        }
     }
}
