using Jayrock.Json;
using System.Collections.Generic;

namespace XbmcJson
{
    public class XbmcPlaylist
    {
        private JsonRpcClient Client;

        public XbmcPlaylist(JsonRpcClient client)
        {
            Client = client;
        }

        public void Create(string playlist)
        {
            var args = new JsonObject();

            args["playlist"] = playlist;

            Client.Invoke("Playlist.Create", args);
        }

        public void Destroy(string playlist)
        {
            var args = new JsonObject();

            args["playlist"] = playlist;

            Client.Invoke("Playlist.Destroy", args);
        }

        public List<PlaylistItem> GetItems(string playlist)
        {
            var args = new JsonObject();
            args["playlist"] = playlist;

            JsonObject query = (JsonObject)Client.Invoke("Playlist.GetItems", args);
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

        public void Add(string playlist, string file = null, int? songId = null, int? artistId = null, int? albumId = null)
        {
            var args = new JsonObject();

            args["playlist"] = playlist;
            if(file != null)
                args["file"] = file;
            if (songId != null)
                args["songid"] = songId;
            if (artistId != null)
                args["artistid"] = artistId;
            if (albumId != null)
                args["albumid"] = albumId;

            Client.Invoke("Playlist.Add", args);
        }

        public void Remove(string playlist, int itemIndex)
        {
            var args = new JsonObject();

            args["playlist"] = playlist;
            args["item"] = itemIndex;

            Client.Invoke("Playlist.Remove", args);
        }

        public void Swap(string playlist, int item1, int item2)
        {
            var args = new JsonObject();

            args["item1"] = item1;
            args["item2"] = item2;

            Client.Invoke("Playlist.Swap", args);
        }

        public void Shuffle(string playlist)
        {
            var args = new JsonObject();

            args["playlist"] = playlist;

            Client.Invoke("Playlist.Shuffle", args);
        }
    }
}
