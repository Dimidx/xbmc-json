using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XbmcJson
{
    public class XbmcPlayer
    {
        private JsonRpcClient Client;

        public XbmcPlayer(JsonRpcClient client)
        {
            Client = client;
        }

        public bool IsAudioPlayerActive()
        {
           JObject query = (JObject)Client.Invoke("Player.GetActivePlayers");

           if (query["audio"] != null)
           {
               if (query["audio"].Value<JValue>().Value.ToString() == "True")
                   return true;
               else
                   return false;
           }

           return false;
        }

        public bool IsVideoPlayerActive()
        {
            JObject query = (JObject)Client.Invoke("Player.GetActivePlayers");

            if (query["video"] != null)
            {
                if (query["video"].Value<JValue>().Value.ToString() == "True")
                    return true;
                else
                    return false;
            }

            return false;
        }

        public bool IsPicturePlayerActive()
        {
            JObject query = (JObject)Client.Invoke("Player.GetActivePlayers");

            if (query["picture"] != null)
            {
                if (query["picture"].Value<JValue>().Value.ToString() == "True")
                    return true;
                else
                    return false;
            }

            return false;
        }
    }
}
