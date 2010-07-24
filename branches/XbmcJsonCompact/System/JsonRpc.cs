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

        public JsonObject Introspect(bool getDescriptions = true, bool getPermissions = true, bool filterByTransport = true)
        {
            var args = new JsonObject();

            args["getdescriptions"] = getDescriptions;
            args["getpermissions"] = getPermissions;
            args["filterbytransport"] = filterByTransport;

            return (JsonObject)Client.Invoke("JSONRPC.Introspect", args);
        }

        public JsonObject Version()
        {
            return (JsonObject)Client.Invoke("JSONRPC.Version");
        }

        public JsonObject Permission()
        {
            return (JsonObject)Client.Invoke("JSONRPC.Permission");
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
