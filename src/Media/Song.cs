using System;
using Jayrock.Json;

namespace XbmcJson
{
    public class Song
    {
        public int _id;
        public string File, Label, Thumbnail;

        public Song(int id, string file, string label, string thumbnail = "")
        {
            _id = id;
            File = file;
            Label = label;
            Thumbnail = thumbnail;
        }

        public static Song SongFromJsonObject(JsonObject item)
        {
            Song e = new Song(Convert.ToInt32(item["artistid"]), item["file"].ToString(), item["label"].ToString(), (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "");
            return e;
        }
    }
}