using System;
using Jayrock.Json;

namespace XbmcJson
{
    public class XbmcVideoPlayer
    {
        private JsonRpcClient Client;

        public XbmcVideoPlayer(JsonRpcClient client)
        {
            Client = client;
        }

        public void PlayPause()
        {
            Client.Invoke("VideoPlayer.PlayPause");
        }

        public void Stop()
        {
            Client.Invoke("VideoPlayer.Stop");
        }

        public void SkipPrevious()
        {
            Client.Invoke("VideoPlayer.SkipPrevious");
        }

        public void SkipNext()
        {
            Client.Invoke("VideoPlayer.SkipNext");
        }

        public void BigSkipBackward()
        {
            Client.Invoke("VideoPlayer.BigSkipBackward");
        }

        public void BigSkipForward()
        {
            Client.Invoke("VideoPlayer.BigSkipForward");
        }

        public void SmallSkipBackward()
        {
            Client.Invoke("VideoPlayer.SmallSkipBackward");
        }

        public void SmallSkipForward()
        {
            Client.Invoke("VideoPlayer.SmallSkipForward");
        }

        public void Rewind()
        {
            Client.Invoke("VideoPlayer.Rewind");
        }

        public void Forward()
        {
            Client.Invoke("VideoPlayer.Forward");
        }

        public int GetTimePlayed()
        {
            JsonObject result = (JsonObject)Client.Invoke("VideoPlayer.GetTime");
            return Convert.ToInt32(result["time"]);
        }

        public int GetTimeTotal()
        {
            JsonObject result = (JsonObject)Client.Invoke("VideoPlayer.GetTime");
            return Convert.ToInt32(result["total"]);
        }

        public int GetTimeMs()
        {
            return Convert.ToInt32(Client.Invoke("VideoPlayer.GetTimeMS"));
        }

        public float GetPercentage()
        {
            return (float)Convert.ToDecimal(Client.Invoke("VideoPlayer.GetPercentage"));
        }

        public void SeekTime(int timeInSeconds)
        {
            Client.Invoke("VideoPlayer.SeekTime", timeInSeconds);
        }

        public void SeekPercentage(float percentage)
        {
            Client.Invoke("VideoPlayer.SeekPercentage", percentage);
        }
    }
}
