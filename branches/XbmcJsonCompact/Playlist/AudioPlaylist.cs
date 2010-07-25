using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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


        public Song GetCurrentItem()
        {
            string[] fields = new string[] { "songid", "title", "artist", "genre", "year", "rating" };

            var args = new JObject();
            args.Add(new JProperty("fields", fields));

            int currentId;
            Song currentSong = null;

            JObject query = (JObject)Client.Invoke("AudioPlaylist.GetItems", args);
            List<Song> list = new List<Song>();

            if (query["items"] != null)
            {
                currentId = Convert.ToInt32(query["current"].Value<JValue>().Value);
                currentSong = Song.SongFromJsonObject(query["items"].Value<JObject>(currentId));
            }

            return currentSong;
        } 

        public List<Song> GetItems()
        {
            string[] fields = new string[] { "songid", "title", "artist", "genre", "year", "rating" }; 

            var args = new JObject();
            args.Add(new JProperty("fields", fields));

            JObject query = (JObject)Client.Invoke("AudioPlaylist.GetItems");
            List<Song> list = new List<Song>();

            if (query["items"] != null)
            {
                foreach (JObject item in (JArray)query["items"])
                {
                    list.Add(Song.SongFromJsonObject(item));
                }
            }

            return list;
        } 


        public void Add(string file, int? songId, int? artistId, int? albumId)
        {
            var args = new JObject();

            if (file != null)
                args.Add(new JProperty("file", file));
            if (songId != null)
                args.Add(new JProperty("songid", songId));
            if (artistId != null)
                args.Add(new JProperty("artistid", artistId));
            if (albumId != null)
                args.Add(new JProperty("albumid", albumId));

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
