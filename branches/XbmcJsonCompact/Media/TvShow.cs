using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace XbmcJson
{
    public class TvShow
    {
        public int _id, Year;
        public float Rating;
        public string Label, Thumbnail, Plot, Genre;

        public TvShow(int id, string label, string thumbnail, string plot, string genre, int year, float rating)
        {
            _id = id;
            Label = label;
            Thumbnail = thumbnail;
            Plot = plot;
            Genre = genre;
            Year = year;
            Rating = rating;
        } 
 
        public static TvShow TvShowFromJsonObject(JObject item)
        {
            TvShow e = new TvShow(
                Convert.ToInt32(item["tvshowid"].Value<JValue>().Value), 
                item["label"].Value<JValue>().Value.ToString(),
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "", 
                (item["plot"] != null) ? item["plot"].Value<JValue>().Value.ToString() : "", 
                (item["genre"] != null) ? item["genre"].Value<JValue>().Value.ToString() : "", 
                (item["year"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value) : -1,
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"].Value<JValue>().Value) : -1);
            return e;
        }
    }
}
