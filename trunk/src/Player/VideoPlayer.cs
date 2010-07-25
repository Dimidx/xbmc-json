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

        public bool PlayPause()
        {
            JsonObject query = (JsonObject)Client.Invoke("VideoPlayer.PlayPause");

            if (query["paused"] != null)
                return (bool)query["paused"];
            else
                return false;
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

        public string GetTimeFormatted()
        {
            string TimeFormatted = "";

            int? TimePlayed = GetTimePlayedSeconds();
            int? TimeTotal = GetTimeTotalSeconds();

            if (TimePlayed != null && TimeTotal != null)
                TimeFormatted = String.Format("{0:00}", (TimePlayed / 60)) + ":" + String.Format("{0:00}", (TimePlayed % 60)) + " / " + String.Format("{0:00}", (TimeTotal / 60)) + ":" + String.Format("{0:00}", (TimeTotal % 60));

            return TimeFormatted;
        }

        public int GetTimePlayedSeconds()
        {
            JsonObject query = (JsonObject)Client.Invoke("VideoPlayer.GetTime");

            if (query["time"] != null)
                return Convert.ToInt32(query["time"]);
            else
                return -1;
        }

        public int GetTimeTotalSeconds()
        {
            JsonObject query = (JsonObject)Client.Invoke("VideoPlayer.GetTime");

            if (query["total"] != null)
                return Convert.ToInt32(query["total"]);
            else
                return -1;
        }

        public int GetTimePlayedMs()
        {
            JsonObject query = (JsonObject)Client.Invoke("VideoPlayer.GetTimeMs");

            if (query["time"] != null)
                return Convert.ToInt32(query["time"]);
            else
                return -1;
        }

        public int GetTimeTotalMs()
        {
            JsonObject query = (JsonObject)Client.Invoke("VideoPlayer.GetTimeMs");

            if (query["total"] != null)
                return Convert.ToInt32(query["total"]);
            else
                return -1;
        }

        public float GetPercentagePlayed()
        {
            JsonObject query = (JsonObject)Client.Invoke("VideoPlayer.GetPercentage");

            if (query != null)
                return (float)Convert.ToDouble(query);
            else
                return -1;
        }

        public void SeekTime(int timeInSeconds)
        {
            Client.Invoke("VideoPlayer.SeekTime", timeInSeconds);
        }

        public void SeekPercentage(float percentage)
        {
            if (percentage < 0)
                percentage = 0;

            if (percentage > 100)
                percentage = 100;

            Client.Invoke("VideoPlayer.SeekPercentage", percentage);
        }
    }
}
