using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace XbmcJson
{
    public class Song
    {
        public int _id, Year;
        public float Rating;
        public string File, Label, Thumbnail, Artist, Title, Genre, Album;

        public Song(int id, string file, string label, string thumbnail, string artist, string title, string genre, string album, int year, float rating)
        {
            _id = id;
            File = file;
            Label = label;
            Thumbnail = thumbnail;
            Artist = artist;
            Title = title;
            Genre = genre;
            Album = album;
            Year = year;
            Rating = rating;
        }

        public static Song SongFromJsonObject(JObject item)
        {
            Song e = new Song(
                (item["songid"] != null) ? Convert.ToInt32(item["songid"].Value<JValue>().Value) : -1,
                item["file"].Value<JValue>().Value.ToString(),
                item["label"].Value<JValue>().Value.ToString(),
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "",
                (item["artist"] != null) ? item["artist"].Value<JValue>().Value.ToString() : "",
                (item["title"] != null) ? item["title"].Value<JValue>().Value.ToString() : "",
                (item["genre"] != null) ? item["genre"].Value<JValue>().Value.ToString() : "",
                (item["album"] != null) ? item["album"].Value<JValue>().Value.ToString() : "",
                (item["year"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value) : -1,
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"].Value<JValue>().Value) : -1
                );
            return e;
        }
    }
}