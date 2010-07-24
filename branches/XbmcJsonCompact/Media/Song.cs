using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace XbmcJson
{
    public class Song
    {
        public int _id;
        public string File, Label, Thumbnail;

        public Song(int id, string file, string label, string thumbnail)
        {
            _id = id;
            File = file;
            Label = label;
            Thumbnail = thumbnail;
        }

        public static Song SongFromJsonObject(JObject item)
        {
            Song e = new Song(Convert.ToInt32(item["artistid"].Value<JValue>().Value), item["file"].Value<JValue>().Value.ToString(), item["label"].Value<JValue>().Value.ToString(), (item["thumbnail"].HasValues == true) ? item["thumbnail"].Value<JValue>().Value.ToString() : "");
            return e;
        }
    }
}