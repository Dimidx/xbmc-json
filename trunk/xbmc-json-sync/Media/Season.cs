using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace XbmcJson
{
    public class Season
    {
        public int Year, _Season;
        public float Rating;
        public string Label, Thumbnail,  Genre;

        public Season(int season, string label, string thumbnail, string genre, int year, float rating)
        {
            _Season = season;
            Label = label;
            Thumbnail = thumbnail;
            Genre = genre;
            Year = year;
            Rating = rating;
        }

        public static Season SeasonFromJsonObject(JObject item)
        {
            Season e = new Season(
                (item["season"] != null) ? Convert.ToInt32(item["season"].Value<JValue>().Value) : -1,
                item["label"].Value<JValue>().Value.ToString(),
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "",
                (item["genre"] != null) ? item["genre"].Value<JValue>().Value.ToString() : "",
                (item["year"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value) : -1,
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"].Value<JValue>().Value) : -1
                );

            return e;
        }
    }
}
