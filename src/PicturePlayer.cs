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

        public void MoveLeft()
        {
            Client.Invoke("PicturePlayer.MoveLeft");
        }

        public void MoveRight()
        {
            Client.Invoke("PicturePlayer.MoveRight");
        }

        public void MoveDown()
        {
            Client.Invoke("PicturePlayer.MoveDown");
        }

        public void MoveUp()
        {
            Client.Invoke("PicturePlayer.MoveUp");
        }

        public void ZoomOut()
        {
            Client.Invoke("PicturePlayer.ZoomOut");
        }

        public void ZoomIn()
        {
            Client.Invoke("PicturePlayer.ZoomIn");
        }

        public void Zoom(int zoomLevel)
        {
            Client.Invoke("PicturePlayer.Zoom", zoomLevel);
        }

        public void Rotate()
        {
            Client.Invoke("PicturePlayer.Rotate");
        }
    }
}