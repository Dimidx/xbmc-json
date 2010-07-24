namespace XbmcJson
{
   public class XbmcSystem
    {
        private JsonRpcClient Client;

        public XbmcSystem(JsonRpcClient client)
        {
            Client = client;
        }

       //Not implemented in xbmc yet so can't test
      /*  public object GetInfoLabels()
        {
            return Client.Invoke("System.GetInfoLabels");
        }

        public object GetInfoBooleans()
        {
            return Client.Invoke("System.GetInfoBooleans");
        } */

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
