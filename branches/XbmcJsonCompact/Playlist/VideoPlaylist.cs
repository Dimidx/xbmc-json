﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
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

        /*
        * This should reheaallyy return a Movie/Episode instead
        */
        public PlaylistItem GetCurrentItem()
        {
            int currentId;
            PlaylistItem currentItem = null;

            JObject query = (JObject)Client.Invoke("VideoPlaylist.GetItems");
            List<PlaylistItem> list = new List<PlaylistItem>();

            if (query["items"] != null)
            {
                currentId = Convert.ToInt32(query["current"].Value<JValue>().Value);
                currentItem = PlaylistItem.PlaylistItemFromJsonObject(query["items"].Value<JObject>(currentId));
            }

            return currentItem;
        } 

        public List<PlaylistItem> GetItems()
        {
            JObject query = (JObject)Client.Invoke("VideoPlaylist.GetItems");
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
