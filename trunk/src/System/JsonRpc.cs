using Jayrock.Json;
using System.Collections.Generic;
using System;

namespace XbmcJson
{
    public class XbmcJsonRpc
    {
        private JsonRpcClient Client;

        public XbmcJsonRpc(JsonRpcClient client)
        {
            Client = client;
        }

        public List<JsonMethod> Introspect()
        {
            var args = new JsonObject();

            args["getdescriptions"] = true;
            args["getpermissions"] = true;
            args["filterbytransport"] = true;

            JsonObject query = (JsonObject)Client.Invoke("JSONRPC.Introspect", args);
            List<JsonMethod> list = new List<JsonMethod>();

            foreach (JsonObject item in (JsonArray)query["commands"])
            {
                list.Add(JsonMethod.JsonMethodFromJsonObject(item));
            }

            return list;
        }

        public int GetVersion()
        {
            JsonObject query = (JsonObject)Client.Invoke("JSONRPC.Version");
            return Convert.ToInt32(query["version"]);
        }

        public List<string> GetPermissions()
        {
            JsonObject query = (JsonObject)Client.Invoke("JSONRPC.Permission");

            List<string> list = new List<string>();

            foreach (string item in ((JsonArray)query["permission"]))
            {
                list.Add(item);
            }

            return list;
        }

        public string Ping()
        {
            return Client.Invoke("JSONRPC.Ping").ToString();
        }

        public void Announce(string sender, string message, object data = null)
        {
            var args = new JsonObject();

            args["sender"] = sender;
            args["message"] = message;
            if (data != null)
                args["data"] = data;

            Client.Invoke("JSONRPC.Announce", args);
        }
    }
}
