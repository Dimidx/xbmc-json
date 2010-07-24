using Jayrock.Json;
using System;

namespace XbmcJson
{
    public class TvShow
    {
        public int _id, Year;
        public float Rating;
        public string Label, Thumbnail, Plot, Genre;

        public TvShow(int id, string label, string thumbnail = "", string plot = "",  string genre = "", int? year = 0, float? rating = 0)
        {
            _id = id;
            Label = label;
            Thumbnail = thumbnail;
            Plot = plot;
            Genre = genre;
            Year = (int)year;
            Rating = (float)rating;
        }

        public static TvShow TvShowFromJsonObject(JsonObject item)
        {
            TvShow e = new TvShow(Convert.ToInt32(item["tvshowid"]), item["label"].ToString(), (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "", (item["plot"] != null) ? item["plot"].ToString() : "", (item["genre"] != null) ? item["genre"].ToString() : "", (item["year"] != null) ? Convert.ToInt32(item["year"]) : 0, (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"]) : 0);
            return e;
        }
    }
}
