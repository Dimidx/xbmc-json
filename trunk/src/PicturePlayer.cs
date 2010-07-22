using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XbmcJson
{
    public class XbmcPicturePlayer
    {

        private Settings Settings;
        private JsonRpcClient Client;

        public XbmcPicturePlayer(Settings Settings, JsonRpcClient client)
        {
            this.Settings = Settings;
            Client = client;
        }

        public void PlayPause()
        {
            Client.Invoke("PicturePlayer.PlayPause");
        }

        public void Stop()
        {
            Client.Invoke("PicturePlayer.Stop");
        }

        public void SkipPrevious()
        {
            Client.Invoke("PicturePlayer.SkipPrevious");
        }

        public void SkipNext()
        {
            Client.Invoke("PicturePlayer.SkipNext");
        }
    }
}