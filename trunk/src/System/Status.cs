using Jayrock.Json;

namespace XbmcJson
{
    public class XbmcStatus
    {
        private JsonRpcClient Client;

        public XbmcStatus(JsonRpcClient client)
        {
            Client = client;
        }

        public bool IsConnected
        {
            get
            {
                string query = (string)Client.Invoke("JSONRPC.Ping");

                if (query != null)
                {
                    if (query == "pong")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
        }
     }
}