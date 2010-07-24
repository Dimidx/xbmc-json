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

        public TvShow(int id, string label, string thumbnail, string plot,  string genre, int? year, float? rating)
        {
            _id = id;
            Label = label;
            Thumbnail = thumbnail;
            Plot = plot;
            Genre = genre;
            Year = (int)year;
            Rating = (float)rating;
        }

        public static TvShow TvShowFromJsonObject(JObject item)
        {
            TvShow e = new TvShow(Convert.ToInt32(item["tvshowid"]), item["label"].ToString(), (item["thumbnail"].HasValues == true) ? item["thumbnail"].ToString() : "", (item["plot"].HasValues == true) ? item["plot"].ToString() : "", (item["genre"].HasValues == true) ? item["genre"].ToString() : "", (item["year"].HasValues == true) ? Convert.ToInt32(item["year"]) : 0, (item["rating"].HasValues == true) ? (float)Convert.ToDouble(item["rating"]) : 0);
            return e;
        }
    }
}
