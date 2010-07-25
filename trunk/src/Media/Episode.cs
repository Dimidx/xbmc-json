using Jayrock.Json;
using System;

namespace XbmcJson
{
    public class Episode
    {
        public int _id, EpisodeNum, Season, Year;
        public string File, Label, Thumbnail, Plot, Show;

        public Episode(int id, string file, string label, string thumbnail, string plot, string show, int episodeNum, int season, int year)
        {
            _id = id;
            File = file;
            Label = label;
            Thumbnail = thumbnail;
            Plot = plot;
            Show = show;
            EpisodeNum = episodeNum;
            Season = season;
            Year = year;
        }

        public static Episode EpisodeFromJsonObject(JsonObject item)
        {
            Episode e = new Episode(
                Convert.ToInt32(item["episodeid"]), 
                item["file"].ToString(), item["label"].ToString(), 
                (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "", 
                (item["plot"] != null) ? item["plot"].ToString() : "",
                (item["showtitle"] != null) ? item["showtitle"].ToString() : "",
                (item["episode"] != null) ? Convert.ToInt32(item["episode"]) : -1, 
                (item["season"] != null) ? Convert.ToInt32(item["season"]) : -1, 
                (item["year"] != null) ? Convert.ToInt32(item["year"]) : -1
                );

            return e;
        }

        public static Episode EpisodeFromPlayListItem(PlaylistItem item)
        {
            Episode e = new Episode(
                item._id,
                item.File,
                item.Label,
                item.Thumbnail,
                item.Plot,
                item.Show,
                item.EpisodeNum,
                item.Season,
                item.Year
                );
            return e;
        }
    }
}