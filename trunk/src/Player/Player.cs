using Jayrock.Json;

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
           JsonObject result = (JsonObject)Client.Invoke("Player.GetActivePlayers");
           if (result["audio"].ToString() == "True")
               return true;
           else
               return false;
        }

        public bool IsVideoPlayerActive()
        {
            JsonObject result = (JsonObject)Client.Invoke("Player.GetActivePlayers");
            if (result["video"].ToString() == "True")
                return true;
            else
                return false;
        }

        public bool IsPicturePlayerActive()
        {
            JsonObject result = (JsonObject)Client.Invoke("Player.GetActivePlayers");
            if (result["picture"].ToString() == "True")
                return true;
            else
                return false;
        }
    }
}
