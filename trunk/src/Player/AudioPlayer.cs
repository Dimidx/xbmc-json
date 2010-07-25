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

        public string GetTimeFormatted()
        {
            string TimeFormatted = "";

            int? TimePlayed = GetTimePlayedSeconds();
            int? TimeTotal = GetTimeTotalSeconds();
            
            if(TimePlayed != null && TimeTotal !=null)
                TimeFormatted = String.Format("{0:00}", (TimePlayed / 60)) + ":" + String.Format("{0:00}", (TimePlayed % 60)) + " / " + String.Format("{0:00}", (TimeTotal / 60)) + ":" + String.Format("{0:00}", (TimeTotal % 60));
            
            return TimeFormatted;
        }

        public int GetTimePlayedSeconds()
        {
            JsonObject query = (JsonObject)Client.Invoke("AudioPlayer.GetTime");

            if(query["time"] != null)
                return Convert.ToInt32(query["time"]);
            else
                return -1;
        }

        public int GetTimeTotalSeconds()
        {
            JsonObject query = (JsonObject)Client.Invoke("AudioPlayer.GetTime");

            if (query["total"] != null)
                return Convert.ToInt32(query["total"]);
            else
                return -1;
        }

        public int GetTimePlayedMs()
        {
            JsonObject query = (JsonObject)Client.Invoke("AudioPlayer.GetTimeMs");

            if (query["time"] != null)
                return Convert.ToInt32(query["time"]);
            else
                return -1;
        }

        public int GetTimeTotalMs()
        {
            JsonObject query = (JsonObject)Client.Invoke("AudioPlayer.GetTimeMs");

            if (query["total"] != null)
                return Convert.ToInt32(query["total"]);
            else
                return -1;
        }

        public float GetPercentagePlayed()
        {
           JsonObject query = (JsonObject)Client.Invoke("AudioPlayer.GetPercentage");

           if (query != null)
               return (float)Convert.ToDouble(query);
           else
               return -1;
        }

        public void SeekTime(int timeInSeconds)
        {
            Client.Invoke("AudioPlayer.SeekTime", timeInSeconds);
        }

        public void SeekPercentage(float percentage)
        {
            if (percentage < 0)
                percentage = 0;

            if (percentage > 100)
                percentage = 100;

            Client.Invoke("AudioPlayer.SeekPercentage", percentage);
        }

        public void Record()
        {
            Client.Invoke("AudioPlayer.Record");
        }
    }
}
