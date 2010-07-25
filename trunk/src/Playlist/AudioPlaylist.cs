using Jayrock.Json;
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

        public List<Song> GetItemsAllFields()
        {
            return GetItems(AllAudioFields);
        }

        public Song GetCurrentItemAllFields()
        {
            return GetCurrentItem(AllAudioFields);
        }

        public Song GetCurrentItem(string[] fields = null)
        {
            var args = new JsonObject();

            if(fields !=null)
               args["fields"] = fields;

            int currentId;
            Song currentSong = null;

            JsonObject query = (JsonObject)Client.Invoke("AudioPlaylist.GetItems", args);
            List<Song> list = new List<Song>();

            if (query["items"] != null)
            {
                currentId = Convert.ToInt32(query["current"]);
                currentSong = Song.SongFromJsonObject((JsonObject)((JsonArray)query["items"])[currentId]);
            }

            return currentSong;
        } 

        public List<Song> GetItems(string[] fields = null)
        {
            JsonObject args = new JsonObject();

            if (fields != null)
                args["fields"] = fields;

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
