﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

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
            JObject query = (JObject)Client.Invoke("VideoPlayer.PlayPause");

            if (query["paused"] != null)
                return (bool)query["paused"].Value<JValue>().Value;
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
            JObject query = (JObject)Client.Invoke("VideoPlayer.GetTime");

            if (query["time"] != null)
                return Convert.ToInt32(query["time"].Value<JValue>().Value);
            else
                return -1;
        }

        public int GetTimeTotalSeconds()
        {
            JObject query = (JObject)Client.Invoke("VideoPlayer.GetTime");

            if (query["total"] != null)
                return Convert.ToInt32(query["total"].Value<JValue>().Value);
            else
                return -1;
        }

        public int GetTimePlayedMs()
        {
            JObject query = (JObject)Client.Invoke("VideoPlayer.GetTimeMs");

            if (query["time"] != null)
                return Convert.ToInt32(query["time"].Value<JValue>().Value);
            else
                return -1;
        }

        public int GetTimeTotalMs()
        {
            JObject query = (JObject)Client.Invoke("VideoPlayer.GetTimeMs");

            if (query["total"] != null)
                return Convert.ToInt32(query["total"].Value<JValue>().Value);
            else
                return -1;
        }

        public float GetPercentagePlayed()
        {
            return (float)Client.Invoke("VideoPlayer.GetPercentage");
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
