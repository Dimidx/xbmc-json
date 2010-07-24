﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System; 
using System.Collections.Generic;
 
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
            var args = new JObject();

            args.Add(new JProperty("getdescriptions", true));
            args.Add(new JProperty("getpermissions", true));
            args.Add(new JProperty("filterbytransport", true));

            JObject query = (JObject)Client.Invoke("JSONRPC.Introspect", args);
            List<JsonMethod> list = new List<JsonMethod>();

            foreach (JObject item in (JArray)query["commands"])
            {
                list.Add(JsonMethod.JsonMethodFromJsonObject(item));
            }

            return list;
        }

        public int GetVersion()
        {
            JObject query = (JObject)Client.Invoke("JSONRPC.Version");
            return Convert.ToInt32(query["version"].Value<JValue>().Value.ToString());
        }

        public List<string> GetPermissions()
        {
            JObject query = (JObject)Client.Invoke("JSONRPC.Permission");

            List<string> list = new List<string>();

            foreach (string item in ((JArray)query["permission"]))
            {
                list.Add(item);
            }

            return list;
        } 
 

        public string Ping()
        {
            return Client.Invoke("JSONRPC.Ping").ToString();
        }

        public void Announce(string sender, string message, object data)
        {
            var args = new JObject();

            args.Add(new JProperty("sender", sender));
            args.Add(new JProperty("message", message));
            if (data != null)
                args.Add(new JProperty("data", data));

            Client.Invoke("JSONRPC.Announce", args);
        }
    }
}
