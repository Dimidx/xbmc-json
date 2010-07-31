using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

namespace XbmcJson
{
    public class XbmcAudioPlaylist
    {
        private JsonRpcClient Client;
        private string[] AllAudioFields  = new string[] { "songid", "title", "artist", "genre", "year", "rating", "album" };

        public XbmcAudioPlaylist(JsonRpcClient client)
        {
            Client = client;
        }

        public void Play(int playlistIndex)
        {
            Client.Invoke("AudioPlaylist.Play", playlistIndex);
        }

        public void SkipPrevious()
        {
            Client.Invoke("AudioPlaylist.SkipPrevious");
        }

        public void SkipNext()
        {
            Client.Invoke("AudioPlaylist.SkipNext");
        }

        public Song GetCurrentItemAllFields()
        {
            return GetCurrentItem(AllAudioFields);
        }

        public Song GetCurrentItem()
        {
            return GetCurrentItem(null);
        }

        public Song GetCurrentItem(string[] fields)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));

            int currentId;
            Song currentSong = null;

            JObject query = (JObject)Client.Invoke("AudioPlaylist.GetItems", args);
            List<Song> list = new List<Song>();

            if (query["items"] != null)
            {
                if (query["current"] != null)
                {
                    currentId = Convert.ToInt32(query["current"].Value<JValue>().Value);
                    currentSong = Song.SongFromJsonObject(query["items"].Value<JObject>(currentId));
                }
            }

            return currentSong;
        }

        public List<Song> GetItemsAllFields()
        {
            return GetItems(AllAudioFields);
        }

        public List<Song> GetItems()
        {
            return GetItems(null);
        }

        public List<Song> GetItems(string[] fields)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));

            JObject query = (JObject)Client.Invoke("AudioPlaylist.GetItems", args);
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

        public void Add(string file)
        {
            var args = new JObject();

            args.Add(new JProperty("file", file));

            Client.Invoke("AudioPlaylist.Add", args);
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
