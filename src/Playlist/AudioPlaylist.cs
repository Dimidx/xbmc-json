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

        public List<Song> GetItems()
        {
            //These fields aren't parsed by xbmc, always returns file, label and thumbnail only.
            JsonObject args = new JsonObject();
            args["fields"] = new string[] { "songid", "title", "artist", "genre", "year", "rating" };

            JsonObject query =  (JsonObject)Client.Invoke("AudioPlaylist.GetItems", args);
            List<Song> list = new List<Song>();

            if (query["items"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["items"])
                {
                    list.Add(Song.SongFromJsonObject(item));
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
