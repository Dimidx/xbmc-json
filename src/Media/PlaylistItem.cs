using System;
using Jayrock.Json;

namespace XbmcJson
{
    public class PlaylistItem
    {
        public string File, Label, Thumbnail;

        public PlaylistItem(string file, string label, string thumbnail = "")
        {
            File = file;
            Label = label;
            Thumbnail = thumbnail;
        }

        public static PlaylistItem PlaylistItemFromJsonObject(JsonObject item)
        {
            PlaylistItem e = new PlaylistItem(item["file"].ToString(), item["label"].ToString(), (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "");
            return e;
        }
    }
}