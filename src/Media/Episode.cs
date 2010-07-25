using Jayrock.Json;
using System;

namespace XbmcJson
{
    public class Episode
    {
        public int _id, EpisodeNum, Season, Year;
        public string File, Label, Thumbnail, Plot;

        public Episode(int id, string file, string label, string thumbnail = "", string plot = "", int? episodeNum = 0, int? season = 0, int? year = 0)
        {
            _id = id;
            File = file;
            Label = label;
            Thumbnail = thumbnail;
            Plot = plot;
            EpisodeNum = (int)episodeNum;
            Season = (int)season;
            Year = (int)year;
        }

        public static Episode EpisodeFromJsonObject(JsonObject item)
        {
            Episode e = new Episode(
                Convert.ToInt32(item["episodeid"]), 
                item["file"].ToString(), item["label"].ToString(), 
                (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "", 
                (item["plot"] != null) ? item["plot"].ToString() : "", 
                (item["episode"] != null) ? Convert.ToInt32(item["episode"]) : 0, 
                (item["season"] != null) ? Convert.ToInt32(item["season"]) : 0, 
                (item["episode"] != null) ? Convert.ToInt32(item["year"]) : 0
                );

            return e;
        }
    }
}