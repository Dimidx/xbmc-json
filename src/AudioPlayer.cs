using System;
using System.Net;
using System.IO;
using Jayrock.Json;

namespace XbmcJson
{
    public class XbmcAudioPlayer
    {
        private JsonRpcClient Client; 

        public XbmcAudioPlayer(JsonRpcClient client)
        {
            Client = client;
        }

        public void PlayPause()
        {
            Client.Invoke("AudioPlayer.PlayPause");
        }

        public void Stop()
        {
            Client.Invoke("AudioPlayer.Stop");
        }

        public void SkipPrevious()
        {
            Client.Invoke("AudioPlayer.SkipPrevious");
        }

        public void SkipNext()
        {
            Client.Invoke("AudioPlayer.SkipNext");
        }

        public void BigSkipBackward()
        {
            Client.Invoke("AudioPlayer.BigSkipBackward");
        }

        public void BigSkipForward()
        {
            Client.Invoke("AudioPlayer.BigSkipForward");
        }

        public void SmallSkipBackward()
        {
            Client.Invoke("AudioPlayer.SmallSkipBackward");
        }

        public void SmallSkipForward()
        {
            Client.Invoke("AudioPlayer.SmallSkipForward");
        }

        public void Rewind()
        {
            Client.Invoke("AudioPlayer.Rewind");
        }

        public void Forward()
        {
            Client.Invoke("AudioPlayer.Forward");
        }

        public int GetTimePlayed()
        {
            JsonObject result = (JsonObject)Client.Invoke("AudioPlayer.GetTime");
            return Convert.ToInt32(result["time"]);
        }

        public int GetTimeTotal()
        {
            JsonObject result = (JsonObject)Client.Invoke("AudioPlayer.GetTime");
            return Convert.ToInt32(result["total"]);
        }
        /// <summary>
        /// Returns the time played in millseconds of the current song
        /// </summary>
        public int GetTimePlayedMs()
        {
            return Convert.ToInt32(Client.Invoke("AudioPlayer.GetTimeMS"));
        }

        /// <summary>
        /// Returns the percentage played of the current song
        /// </summary>
        public float GetPercentagePlayed()
        {
           return (float)Convert.ToDecimal(Client.Invoke("AudioPlayer.GetPercentage"));
        }

        public void SeekTime(int timeInSeconds)
        {
            Client.Invoke("AudioPlayer.SeekTime", timeInSeconds);
        }

        public void SeekPercentage(float percentage)
        {
            Client.Invoke("AudioPlayer.SeekPercentage", percentage);
        }

        public void Record()
        {
            Client.Invoke("AudioPlayer.Record");
        }
    }
}
