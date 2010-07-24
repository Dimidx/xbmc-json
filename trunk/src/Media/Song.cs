using System;
using Jayrock.Json;

namespace XbmcJson
{
    public class Song
    {
        public string File, Label, Thumbnail;

        public Song(string file, string label, string thumbnail = "")
        {
            File = file;
            Label = label;
            Thumbnail = thumbnail;
        }

        public static Song SongFromJsonObject(JsonObject item)
        {
            Song e = new Song(item["file"].ToString(), item["label"].ToString(), (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "");
            return e;
        }
    }
}