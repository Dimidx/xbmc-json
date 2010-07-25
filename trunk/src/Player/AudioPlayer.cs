using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XbmcJson
{
    public class XbmcAudioPlayer
    {
        private JsonRpcClient Client; 

        public XbmcAudioPlayer(JsonRpcClient client)
        {
            Client = client;
        }

        public bool PlayPause()
        {
            JObject query = (JObject)Client.Invoke("AudioPlayer.PlayPause");

            if (query["paused"] != null)
                return (bool)query["paused"].Value<JValue>().Value;
            else
                return false;
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
            JObject query = (JObject)Client.Invoke("AudioPlayer.GetTime");

            if(query["time"] != null)
                return Convert.ToInt32(query["time"].Value<JValue>().Value);
            else
                return -1;
        }

        public int GetTimeTotalSeconds()
        {
            JObject query = (JObject)Client.Invoke("AudioPlayer.GetTime");

            if (query["total"] != null)
                return Convert.ToInt32(query["total"].Value<JValue>().Value);
            else
                return -1;
        }

        public int GetTimePlayedMs()
        {
            JObject query = (JObject)Client.Invoke("AudioPlayer.GetTimeMs");

            if (query["time"] != null)
                return Convert.ToInt32(query["time"].Value<JValue>().Value);
            else
                return -1;
        }

        public int GetTimeTotalMs()
        {
            JObject query = (JObject)Client.Invoke("AudioPlayer.GetTimeMs");

            if (query["total"] != null)
                return Convert.ToInt32(query["total"].Value<JValue>().Value);
            else
                return -1;
        }

        public float GetPercentagePlayed()
        {
           JObject query = (JObject)Client.Invoke("AudioPlayer.GetPercentage");

           if (query != null)
               return (float)Convert.ToDouble(query.Value<JValue>().Value);
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
