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
            JObject result = (JObject)Client.Invoke("Player.GetActivePlayers");
            if (result["audio"].Value<JValue>().Value.ToString() == "True")
                return true;
            else
                return false;
        }

        public bool IsVideoPlayerActive()
        {
            JObject result = (JObject)Client.Invoke("Player.GetActivePlayers");
            if (result["video"].Value<JValue>().Value.ToString() == "True")
                return true;
            else
                return false;
        }

        public bool IsPicturePlayerActive()
        {
            JObject result = (JObject)Client.Invoke("Player.GetActivePlayers");
            if (result["picture"].Value<JValue>().Value.ToString() == "True")
                return true;
            else
                return false;
        }
    }
}
