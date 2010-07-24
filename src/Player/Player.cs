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
           JsonObject query = (JsonObject)Client.Invoke("Player.GetActivePlayers");

           if (query["audio"] != null)
           {
               if (query["audio"].ToString() == "True")
                   return true;
               else
                   return false;
           }

           return false;
        }

        public bool IsVideoPlayerActive()
        {
            JsonObject query = (JsonObject)Client.Invoke("Player.GetActivePlayers");

            if (query["video"] != null)
            {
                if (query["video"].ToString() == "True")
                    return true;
                else
                    return false;
            }

            return false;
        }

        public bool IsPicturePlayerActive()
        {
            JsonObject query = (JsonObject)Client.Invoke("Player.GetActivePlayers");

            if (query["picture"] != null)
            {
                if (query["picture"].ToString() == "True")
                    return true;
                else
                    return false;
            }

            return false;
        }
    }
}
