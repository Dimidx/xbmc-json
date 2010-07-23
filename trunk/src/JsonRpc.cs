using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;

namespace XbmcJson
{
    public class XbmcJsonRpc
    {
        private JsonRpcClient Client;

        public XbmcJsonRpc(JsonRpcClient client)
        {
            Client = client;
        }

        public JsonObject Introspect()
        {
            return (JsonObject)Client.Invoke("JSONRPC.Introspect");
        }

        public JsonObject Version()
        {
            return (JsonObject)Client.Invoke("JSONRPC.Version");
        }

        public JsonObject Permission()
        {
            return (JsonObject)Client.Invoke("JSONRPC.Permission");
        }

        public JsonObject Ping()
        {
            return (JsonObject)Client.Invoke("JSONRPC.Ping");
        }

     /*   public void Announce()
        {
            return Client.Invoke("JSONRPC.Ping");
        } */
    }
}
