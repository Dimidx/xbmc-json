using System;
using Jayrock.Json;

namespace XbmcJson
{
    public class Share
    {
        public string File, Label;

        public Share(string file, string label)
        {
            File = file;
            Label = label;
        }

        public static Share ShareFromJsonObject(JsonObject item)
        {
            Share e = new Share(item["file"].ToString(), (item["label"] != null) ? item["label"].ToString() : "");
            return e;
        }
    }
}