using Jayrock.Json;
using System.Collections.Generic;

namespace XbmcJson
{
    public class XbmcAudioPlaylist
    {
        private JsonRpcClient Client;

        public XbmcAudioPlaylist(JsonRpcClient client)
        {
            Client = client;
        }

        public void Play()
        {
            Client.Invoke("AudioPlaylist.Play");
        }

        public void SkipPrevious()
        {
            Client.Invoke("AudioPlaylist.SkipPrevious");
        }

        public void SkipNext()
        {
            Client.Invoke("AudioPlaylist.SkipNext");
        }

        public List<PlaylistItem> GetItems()
        {
            JsonObject query =  (JsonObject)Client.Invoke("AudioPlaylist.GetItems");
            List<PlaylistItem> list = new List<PlaylistItem>();

            foreach (JsonObject item in (JsonArray)query["items"])
            {
                list.Add(PlaylistItem.PlaylistItemFromJsonObject(item));
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

            Client.Invoke("AudioPlaylist.Add", args);
        }

        public void Clear()
        {
            Client.Invoke("AudioPlaylist.Clear");
        }

        public void Shuffle()
        {
            Client.Invoke("AudioPlaylist.Shuffle");
        }

        public void UnShuffle()
        {
            Client.Invoke("AudioPlaylist.UnShuffle");
        }
    }
}
