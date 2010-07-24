using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace XbmcJson
{
    public class Season
    {
        public int Year;
        public float Rating;
        public string Label, Thumbnail,  Genre;

        public Season(string label, string thumbnail, string genre, int? year, float? rating)
        {
            Label = label;
            Thumbnail = thumbnail;
            Genre = genre;
            Year = (int)year;
            Rating = (float)rating;
        }

        public static Season SeasonFromJsonObject(JObject item)
        {
            Season e = new Season(
                item["label"].Value<JValue>().Value.ToString(), 
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "", 
                (item["genre"] != null) ? item["genre"].Value<JValue>().Value.ToString() : "", 
                (item["year"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value) : 0, 
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"].Value<JValue>().Value) : 0);
            return e;
        }
    }
}
