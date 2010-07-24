using System;
using Jayrock.Json;

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

        public static JsonMethod JsonMethodFromJsonObject(JsonObject item)
        {
            JsonMethod e = new JsonMethod(item["command"].ToString(), item["description"].ToString(), item["permission"].ToString());
            return e;
        }
    }
}
