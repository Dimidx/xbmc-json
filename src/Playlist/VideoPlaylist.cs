using Jayrock.Json;
using System.Collections.Generic;

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

        public List<PlaylistItem> GetItems()
        {
            JsonObject query = (JsonObject)Client.Invoke("VideoPlaylist.GetItems");
            List<PlaylistItem> list = new List<PlaylistItem>();

            if (query["items"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["items"])
                {
                    list.Add(PlaylistItem.PlaylistItemFromJsonObject(item));
                }
            }

            return list;
        }

        public void Add(string file = null, int? songId = null, int? artistId = null, int? albumId = null)
        {
            var args = new JsonObject();

            if (file != null)
                args["file"] = file;
            if (songId != null)
                args["songid"] = songId;
            if (artistId != null)
                args["artistid"] = artistId;
            if (albumId != null)
                args["albumid"] = albumId;

            Client.Invoke("VideoPlaylist.Add", args);
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
