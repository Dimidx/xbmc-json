using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace XbmcJson
{
   public class XbmcSystem
    {
        private JsonRpcClient Client;

        public XbmcSystem(JsonRpcClient client)
        {
            Client = client;
        }

        public float GetFPS()
        {
            string[] label = new string[] {"System.FPS"};
            JObject query = (JObject)Client.Invoke("System.GetInfoLabels", label);

            if (query != null)
                return (float)Convert.ToDouble(query["System.FPS"].Value<JValue>().Value);
            else
                return -1;
        }

        public string GetFreeMemory()
        {
            string[] label = new string[] {"System.FreeMemory"};
            JObject query = (JObject)Client.Invoke("System.GetInfoLabels", label);

            if (query != null)
                return (string)query["System.FreeMemory"].Value<JValue>().Value;
            else
                return "";
        }

        //Will fix later
        public Dictionary<string, string> GetInfoLabels(string[] labels)
        {
            JArray query = (JArray)Client.Invoke("System.GetInfoLabels", labels);
            Dictionary<string, string> list = new Dictionary<string, string>();

            if (query != null)
            {
                foreach (JObject item in (JArray)query)
                {
                    list.Add("test1", "test2");
                }
            }

            return list;
        }

        //Will fix later
        public void GetInfoBooleans()
        {
            Client.Invoke("System.GetInfoBooleans");
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
