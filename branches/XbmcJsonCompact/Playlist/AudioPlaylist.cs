using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            JObject query = (JObject)Client.Invoke("AudioPlaylist.GetItems");
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
