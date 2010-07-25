using System;
using Jayrock.Json;

namespace XbmcJson
{
    public class PlaylistItem
    {
        public int _id, Year, EpisodeNum, Season;
        public float Rating;
        public string File, Label, Thumbnail, Plot, Director, Writer, Studio, Genre, Runtime, Tagline, PlotOutline, Show;

        public PlaylistItem(string file, string label, string thumbnail, string plot, string director, string writer, string studio, string genre, int year, string runtime, float rating, string tagline, string plotOutline, string show, int season, int episodeNum)
        {
            File = file;
            Label = label;
            Thumbnail = thumbnail;
            Plot = plot;
            Director = director;
            Writer = writer;
            Studio = studio;
            Genre = genre;
            Year = year;
            Runtime = runtime;
            Rating = rating;
            Tagline = tagline;
            PlotOutline = plotOutline;
            Show = show;
            Season = season;
            EpisodeNum = episodeNum;
        }

        public static PlaylistItem PlaylistItemFromJsonObject(JsonObject item)
        {
            PlaylistItem e = new PlaylistItem(
                item["file"].ToString(), 
                item["label"].ToString(), 
                (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "", 
                (item["plot"] != null) ? item["plot"].ToString() : "", 
                (item["director"] != null) ? item["director"].ToString() : "", 
                (item["writer"] != null) ? item["writer"].ToString() : "",
                (item["studio"] != null) ? item["studio"].ToString() : "", 
                (item["genre"] != null) ? item["genre"].ToString() : "", 
                (item["year"] != null) ? Convert.ToInt32(item["year"]) : -1, 
                (item["runtime"] != null) ? item["runtime"].ToString() : "", 
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"]) : -1, 
                (item["tagline"] != null) ? item["tagline"].ToString() : "", 
                (item["plotoutline"] != null) ? item["plotoutline"].ToString() : "",
                (item["showtitle"] != null) ? item["showtitle"].ToString() : "", 
                (item["episode"] != null) ? Convert.ToInt32(item["episode"]) : -1, 
                (item["season"] != null) ? Convert.ToInt32(item["season"]) : -1
                );

            return e;
        }
    }
}