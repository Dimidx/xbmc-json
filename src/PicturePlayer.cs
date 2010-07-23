using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XbmcJson
{
    public class XbmcPicturePlayer
    {

        private JsonRpcClient Client;

        public XbmcPicturePlayer(JsonRpcClient client)
        {
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