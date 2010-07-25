using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public PlaylistItem GetCurrentItem()
        {
            return GetCurrentItem(null);
        }

        public PlaylistItem GetCurrentItem(string[] fields)
        {
            JObject args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));

            int currentId;
            PlaylistItem currentItem = null;

            JObject query = (JObject)Client.Invoke("VideoPlaylist.GetItems", args);
            List<PlaylistItem> list = new List<PlaylistItem>();

            if (query["items"] != null)
            {
                currentId = Convert.ToInt32(query["current"].Value<JValue>().Value);
                currentItem = PlaylistItem.PlaylistItemFromJsonObject(query["items"].Value<JObject>(currentId));
            }

            return currentItem;
        }

        public List<PlaylistItem> GetItemsAllFields()
        {
            return GetItems(AllPlaylistFields);
        }

        public List<PlaylistItem> GetItems()
        {
            return GetItems(null);
        }

        public List<PlaylistItem> GetItems(string[] fields)
        {
            JObject args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));

            JObject query = (JObject)Client.Invoke("VideoPlaylist.GetItems", args);
            List<PlaylistItem> list = new List<PlaylistItem>();

            if (query["items"] != null)
            {
                foreach (JObject item in (JArray)query["items"])
                {
                    list.Add(PlaylistItem.PlaylistItemFromJsonObject(item));
                }
            }

            return list;
        }

        public void Add(string file, int? songId, int? artistId, int? albumId)
        {
            var args = new JObject();

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
