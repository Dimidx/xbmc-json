using System;

namespace xbmc_json_async.System
{
    public class XSettings
    {
        public string IpAddress;
        public int Port;
        public string UserName;
        public string Password;
        public Uri XJsonInterfaceAddress;
        public Uri BaseAddress;

        public XSettings(string ipAddress, int port, string userName, string password)
        {
            IpAddress = ipAddress;
            Port = port;
            UserName = userName;
            Password = password;
            XJsonInterfaceAddress = new Uri("http://" + ipAddress + ":" + port + "/jsonrpc");
            BaseAddress = new Uri("http://" + ipAddress + ":" + port);
        }
    }
}
