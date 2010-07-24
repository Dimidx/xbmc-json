using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
﻿using System;

namespace XbmcJson
{
    public class JsonMethod
    {
        public string Command, Description, Permission;

        public JsonMethod(string command, string description, string permission)
        {
            Command = command;
            Description = description;
            Permission = permission;
        }

        public static JsonMethod JsonMethodFromJsonObject(JObject item)
        {
            JsonMethod e = new JsonMethod(
                item["command"].Value<JValue>().Value.ToString(), 
                item["description"].Value<JValue>().Value.ToString(), 
                item["permission"].Value<JValue>().Value.ToString());
            return e;
        }
    }
}
