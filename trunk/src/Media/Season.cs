using Jayrock.Json;
using System;

namespace XbmcJson
{
    public class Season
    {
        public int Year;
        public float Rating;
        public string Label, Thumbnail,  Genre;

        public Season(string label, string thumbnail, string genre, int year, float rating)
        {
            Label = label;
            Thumbnail = thumbnail;
            Genre = genre;
            Year = year;
            Rating = rating;
        }

        public static Season SeasonFromJsonObject(JsonObject item)
        {
            Season e = new Season(
                item["label"].ToString(), 
                (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "", 
                (item["genre"] != null) ? item["genre"].ToString() : "", 
                (item["year"] != null) ? Convert.ToInt32(item["year"]) : -1, 
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"]) : -1
                );

            return e;
        }
    }
}
