using System;
using Jayrock.Json;

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

        public static Song SongFromJsonObject(JsonObject item)
        {
            Song e = new Song(
                (item["songid"] !=null) ? Convert.ToInt32(item["songid"]) : -1, 
                item["file"].ToString(), 
                item["label"].ToString(), 
                (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "",
                (item["artist"] != null) ? item["artist"].ToString() : "",
                (item["title"] != null) ? item["title"].ToString() : "",
                (item["genre"] != null) ? item["genre"].ToString() : "",
                (item["album"] != null) ? item["album"].ToString() : "",
                (item["year"] !=null) ? Convert.ToInt32(item["year"]) : -1,
                (item["rating"] !=null) ? (float)Convert.ToDouble(item["rating"]) : -1
                );
            return e;
        }
    }
}