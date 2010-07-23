using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XbmcJson
{
    public class XbmcVideoPlaylist
    {
        private JsonRpcClient Client;

        public XbmcVideoPlaylist(JsonRpcClient client)
        {
            Client = client;
        }

        public void Play()
        {
            Client.Invoke("VideoPlaylist.Play");
        }

        public void SkipPrevious()
        {
            Client.Invoke("VideoPlaylist.SkipPrevious");
        }

        public void SkipNext()
        {
            Client.Invoke("VideoPlaylist.SkipNext");
        }

        public object GetItems()
        {
            return Client.Invoke("VideoPlaylist.GetItems");
        }

        public void Add()
        {
            Client.Invoke("VideoPlaylist.Add");
        }

        public void Clear()
        {
            Client.Invoke("VideoPlaylist.Clear");
        }

        public void Shuffle()
        {
            Client.Invoke("VideoPlaylist.Shuffle");
        }

        public void UnShuffle()
        {
            Client.Invoke("VideoPlaylist.UnShuffle");
        }
    }
}
