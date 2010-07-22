using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XbmcJson
{
    public class XbmcVideoPlayer
    {

        private Settings Settings;
        private JsonRpcClient Client;

        public XbmcVideoPlayer(Settings Settings, JsonRpcClient client)
        {
            this.Settings = Settings;
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

        public string GetTime()
        {
            return Client.Invoke("VideoPlayer.GetTime").ToString();
        }

        public string GetTimeMs()
        {
            return Client.Invoke("VideoPlayer.GetTimeMS").ToString();
        }

        public void GetPercentage()
        {
            Client.Invoke("VideoPlayer.GetPercentage");
        }

        public void SeekTime()
        {
            Client.Invoke("VideoPlayer.SeekTime");
        }

        public void SeekPercentage()
        {
            Client.Invoke("VideoPlayer.SeekPercentage");
        }
    }
}
