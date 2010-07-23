using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;

namespace XbmcJson
{
    public class XbmcVideoLibrary
    {
        private JsonRpcClient Client;

        public XbmcVideoLibrary(JsonRpcClient client)
        {
            Client = client;
        }

        public JsonObject GetMovies()
        {
           return (JsonObject)Client.Invoke("VideoLibrary.GetMovies");
        }

        public JsonObject GetMovies(string[] fields)
        {
            var args = new JsonObject();
            args["fields"] = fields;
            return (JsonObject)Client.Invoke("VideoLibrary.GetMovies", args);
        }
    }
}
