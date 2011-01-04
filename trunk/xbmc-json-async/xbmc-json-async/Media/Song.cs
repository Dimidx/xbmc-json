using Newtonsoft.Json.Linq;
using System;

namespace xbmc_json_async.Media
{
    public class Song : XbmcMediaItem
    {
        public int Year;
        public float Rating;
        public string File { get; set; }
        public string Thumbnail { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; } 
        public string Genre { get; set; }
        public string Album { get; set; }

        public Song(int id, string file, string label, string thumbnail, string artist, string title, string genre, string album, int year, float rating)
        {   
            Id = id;
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

        public static Song FromJsonObject(JObject item)
        {
            var song = new Song(
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
            return song;
        }

        public override string ToString()
        {
            return Label;
        }
    }
}