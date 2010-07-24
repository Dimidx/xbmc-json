using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace XbmcJson
{
    public class Album
    {
        public int _id;
        public string Label, Thumbnail;

        public Album(int id, string label, string thumbnail)
        {
            _id = id;
            Label = label;
            Thumbnail = thumbnail;
        }

        public static Album AlbumFromJsonObject(JObject item)
        {
            Album e = new Album(
                Convert.ToInt32(item["albumid"].Value<JValue>().Value.ToString()), 
                item["label"].Value<JValue>().Value.ToString(), 
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "");
            return e;
        }
    }
}
