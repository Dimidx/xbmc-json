using Jayrock.Json;
using System.Collections.Generic;
using System;

namespace XbmcJson
{
    public class XbmcVideoPlaylist
    {
        private JsonRpcClient Client;

        private string[] AllPlaylistFields = new string[] { "episodeid", "movieid", "plot", "director", "writer", "studio", "genre", "year", "runtime", "rating", "tagline", "plotoutline", "showtitle", "season", "episode" };

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

        public PlaylistItem GetCurrentItemAllFields()
        {
            return GetCurrentItem(AllPlaylistFields);
        }

        public PlaylistItem GetCurrentItem(string[] fields = null)
        {
            JsonObject args = new JsonObject();

            if (fields != null)
                args["fields"] = fields;

            int currentId;
            PlaylistItem currentItem = null;

            JsonObject query = (JsonObject)Client.Invoke("VideoPlaylist.GetItems", args);
            List<PlaylistItem> list = new List<PlaylistItem>();

            if (query["items"] != null)
            {
                currentId = Convert.ToInt32(query["current"]);
                currentItem = PlaylistItem.PlaylistItemFromJsonObject((JsonObject)((JsonArray)query["items"])[currentId]);
            }

            return currentItem;
        }

        public List<PlaylistItem> GetItemsAllFields()
        {
            return GetItems(AllPlaylistFields);
        }

        public List<PlaylistItem> GetItems(string[] fields = null)
        {
            JsonObject args = new JsonObject();

            if(fields != null)
                args["fields"] =  fields;
            
            JsonObject query = (JsonObject)Client.Invoke("VideoPlaylist.GetItems", args);
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
