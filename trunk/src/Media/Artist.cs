using System;
using Jayrock.Json;

namespace XbmcJson
{
    public class Artist
    {
        public int _id;
        public string Label, Thumbnail;

        public Artist(int id, string label, string thumbnail = "")
        {
            _id = id;
            Label = label;
            Thumbnail = thumbnail;
        }

        public static Artist ArtistFromJsonObject(JsonObject item)
        {
            Artist e = new Artist(Convert.ToInt32(item["artistid"]), item["label"].ToString(), (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "");
            return e;
        }
    }
}