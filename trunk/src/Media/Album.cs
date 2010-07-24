using System;
using Jayrock.Json;

namespace XbmcJson
{
    public class Album
    {
        public int _id;
        public string Label, Thumbnail;

        public Album(int id, string label, string thumbnail = "")
        {
            _id = id;
            Label = label;
            Thumbnail = thumbnail;
        }

        public static Album AlbumFromJsonObject(JsonObject item)
        {
            Album e = new Album(Convert.ToInt32(item["albumid"]), item["label"].ToString(), (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "");
            return e;
        }
    }
}
