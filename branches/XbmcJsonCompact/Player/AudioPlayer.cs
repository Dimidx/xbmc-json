using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.IO;

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
            JObject result = (JObject)Client.Invoke("AudioPlayer.GetTime");
            return Convert.ToInt32(result["time"].Value<JValue>().Value);
        }

        public int GetTimeTotal()
        {
            JObject result = (JObject)Client.Invoke("AudioPlayer.GetTime");
            return Convert.ToInt32(result["total"].Value<JValue>().Value);
        }

        public int GetTimePlayedMs()
        {
            return Convert.ToInt32(((JObject)Client.Invoke("AudioPlayer.GetTimeMS")).Value<JValue>().Value);
        }

        public float GetPercentagePlayed()
        {
            return (float)Convert.ToDecimal(((JObject)Client.Invoke("AudioPlayer.GetPercentage")).Value<JValue>().Value);
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
