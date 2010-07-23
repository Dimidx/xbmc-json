using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;

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

        public string GetTime()
        {
           return Client.Invoke("AudioPlayer.GetTime").ToString();
        }

        public int GetTimeMs()
        {
            return Convert.ToInt32(Client.Invoke("AudioPlayer.GetTimeMS"));
        }

        public float GetPercentage()
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
