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
        private Settings Settings;
        private JsonRpcClient Client; 

        public XbmcAudioPlayer(Settings Settings, JsonRpcClient client)
        {
            this.Settings = Settings;
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

        public string GetTimeMs()
        {
            return Client.Invoke("AudioPlayer.GetTimeMS").ToString();
        }

        public void GetPercentage()
        {
            Client.Invoke("AudioPlayer.GetPercentage");
        }

        public void SeekTime()
        {
            Client.Invoke("AudioPlayer.SeekTime");
        }

        public void SeekPercentage()
        {
            Client.Invoke("AudioPlayer.SeekPercentage");
        }

        public void Record()
        {
            Client.Invoke("AudioPlayer.Record");
        }

        public Image GetSongAlbumArt(String Thumbnail)
        {
           String ImageLocation = "http://" + Settings.XbmcIp + ":" + Settings.XbmcPort + "/vfs/" + Thumbnail;
           WebClient ImageGetter = new WebClient();
           Stream stream = ImageGetter.OpenRead(ImageLocation);
           Image RetreievedImage = Image.FromStream(stream);
           stream.Close();
           return RetreievedImage;
        } 
    }
}
