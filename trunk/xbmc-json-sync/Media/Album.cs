using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XbmcJson
{
    public class Album
    {
        public int _id, Year;
        public float Rating;
        public string Label, Thumbnail, Artist, Genre;

        public Album(int id, string label, string thumbnail, string artist, string genre, int year, float rating)
        {
            _id = id;
            Label = label;
            Thumbnail = thumbnail;
            Artist = artist;
            Genre = genre;
            Year = year;
            Rating = rating;
        }

        public static Album AlbumFromJsonObject(JObject item)
        {
            Album e = new Album(
                Convert.ToInt32(item["albumid"].Value<JValue>().Value.ToString()),
                item["label"].Value<JValue>().Value.ToString(),
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "",
                (item["artist"] != null) ? item["artist"].Value<JValue>().Value.ToString() : "",
                (item["genre"] != null) ? item["genre"].Value<JValue>().Value.ToString() : "",
                (item["year"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value) : -1,
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"].Value<JValue>().Value) : -1
                );

            return e;
        }
    }
}
