using System;
using Newtonsoft.Json.Linq;

namespace xbmc_json_async.Media
{
    public class Season : XbmcMediaItem
    {
        public int Year { get; set; }
        public float Rating { get; set; }
        public string Thumbnail { get; set; }
        public string Genre { get; set; }

        public Season(int id, string label, string thumbnail, string genre, int year, float rating)
        {
            Id = id;
            Label = label;
            Thumbnail = thumbnail;
            Genre = genre;
            Year = year;
            Rating = rating;
        }

        public static Season FromJsonObject(JObject item)
        {
            var season = new Season(
                (item["SeasonId"] != null) ? Convert.ToInt32(item["SeasonId"].Value<JValue>().Value) : -1,
                item["label"].Value<JValue>().Value.ToString(),
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "",
                (item["genre"] != null) ? item["genre"].Value<JValue>().Value.ToString() : "",
                (item["year"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value) : -1,
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"].Value<JValue>().Value) : -1
                );

            return season;
        }

        public override string ToString()
        {
            return Label;
        }
    }
}
