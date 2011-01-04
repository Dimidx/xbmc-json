using System;
using Newtonsoft.Json.Linq;

namespace xbmc_json_async.Media
{
    public class Artist : XbmcMediaItem
    {
        public Artist(int id, string label)
        {
            Id = id;
            Label = label;
        }

        public static Artist FromJsonObject(JObject item)
        {
            var artist = new Artist(
                Convert.ToInt32(item["artistid"].Value<JValue>().Value),
                item["label"].Value<JValue>().Value.ToString()
                );

            return artist;
        }

        public override string ToString()
        {
            return Label;
        }
    }
}