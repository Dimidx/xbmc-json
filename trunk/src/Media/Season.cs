using Jayrock.Json;
using System;

namespace XbmcJson
{
    public class Season
    {
        public int Year;
        public float Rating;
        public string Label, Thumbnail,  Genre;

        public Season(string label, string thumbnail = "", string genre = "", int? year = 0, float? rating = 0)
        {
            Label = label;
            Thumbnail = thumbnail;
            Genre = genre;
            Year = (int)year;
            Rating = (float)rating;
        }

        public static Season SeasonFromJsonObject(JsonObject item)
        {
            Season e = new Season(
                item["label"].ToString(), 
                (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "", 
                (item["genre"] != null) ? item["genre"].ToString() : "", 
                (item["year"] != null) ? Convert.ToInt32(item["year"]) : 0, 
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"]) : 0
                );

            return e;
        }
    }
}
