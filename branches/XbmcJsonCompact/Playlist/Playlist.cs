using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            var args = new JObject();

            args.Add(new JProperty("playlist", playlist));

            Client.Invoke("Playlist.Create", args);
        }

        public void Destroy(string playlist)
        {
            var args = new JObject();

            args.Add(new JProperty("playlist", playlist));

            Client.Invoke("Playlist.Destroy", args);
        }

        public List<PlaylistItem> GetItems(string playlist)
        {
            var args = new JObject();
            args.Add(new JProperty("playlist", playlist));

            JObject query = (JObject)Client.Invoke("Playlist.GetItems", args);
            List<PlaylistItem> list = new List<PlaylistItem>();

            foreach (JObject item in (JArray)query["items"])
            {
                list.Add(PlaylistItem.PlaylistItemFromJsonObject(item));
            }

            return list;
        } 

        public void Add(string playlist, string file, int? songId, int? artistId, int? albumId)
        {
            var args = new JObject();

            args.Add(new JProperty("playlist", playlist));

            if (file != null)
                args.Add(new JProperty("file", file));
            if (songId != null)
                args.Add(new JProperty("songid", songId));
            if (artistId != null)
                args.Add(new JProperty("artistid", artistId));
            if (albumId != null)
                args.Add(new JProperty("albumid", albumId));

            Client.Invoke("Playlist.Add", args);
        }

        public void Remove(string playlist, int itemIndex)
        {
            var args = new JObject();

            args.Add(new JProperty("playlist", playlist));
            args.Add(new JProperty("item", itemIndex));

            Client.Invoke("Playlist.Remove", args);
        }

        public void Swap(string playlist, int item1, int item2)
        {
            var args = new JObject();

            args.Add(new JProperty("playlist", playlist));
            args.Add(new JProperty("item1", item1));
            args.Add(new JProperty("item2", item2));

            Client.Invoke("Playlist.Swap", args);
        }

        public void Shuffle(string playlist)
        {
            var args = new JObject();

            args.Add(new JProperty("playlist", playlist));

            Client.Invoke("Playlist.Shuffle", args);
        }
    }
}
