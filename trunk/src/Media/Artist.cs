using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XbmcJson
{
    public class Artist
    {
        public int _id;
        public string Label, Thumbnail;

        public Artist(int id, string label, string thumbnail)
        {
            _id = id;
            Label = label;
            Thumbnail = thumbnail;
        }

        public static Artist ArtistFromJsonObject(JObject item)
        {
            Artist e = new Artist(
                Convert.ToInt32(item["artistid"].Value<JValue>().Value),
                item["label"].Value<JValue>().Value.ToString(),
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : ""
                );

            return e;
        }
    }
}