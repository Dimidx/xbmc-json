using System;
using Jayrock.Json;

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

        public static Album AlbumFromJsonObject(JsonObject item)
        {
            Album e = new Album(
                Convert.ToInt32(item["albumid"]), 
                item["label"].ToString(), 
                (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "",
                (item["artist"] != null) ? item["artist"].ToString() : "",
                (item["genre"] != null) ? item["genre"].ToString() : "",
                (item["year"] != null) ? Convert.ToInt32(item["year"]) : -1,
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"]) : -1
                );

            return e;
        }
    }
}
