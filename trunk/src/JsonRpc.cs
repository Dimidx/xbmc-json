using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XbmcJson
{
    public class XbmcJsonRpc
    {
        private Settings Settings;
        private JsonRpcClient Client;

        public XbmcJsonRpc(Settings Settings, JsonRpcClient client)
        {
            this.Settings = Settings;
            Client = client;
        }

        public object Introspect()
        {
            return Client.Invoke("JSONRPC.Introspect");
        }

        public object Version()
        {
            return Client.Invoke("JSONRPC.Version");
        }

        public object Permission()
        {
            return Client.Invoke("JSONRPC.Permission");
        }

        public object Ping()
        {
            return Client.Invoke("JSONRPC.Ping");
        }

     /*   public void Announce()
        {
            return Client.Invoke("JSONRPC.Ping");
        } */
    }
}
