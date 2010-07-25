using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
﻿using System;

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

        public static PlaylistItem PlaylistItemFromJsonObject(JObject item) 
        {
            PlaylistItem e = new PlaylistItem(
                item["file"].Value<JValue>().Value.ToString(),
                item["label"].Value<JValue>().Value.ToString(),
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "",
                (item["plot"] != null) ? item["plot"].Value<JValue>().Value.ToString() : "",
                (item["director"] != null) ? item["director"].Value<JValue>().Value.ToString() : "",
                (item["writer"] != null) ? item["writer"].Value<JValue>().Value.ToString() : "",
                (item["studio"] != null) ? item["studio"].Value<JValue>().Value.ToString() : "",
                (item["genre"] != null) ? item["genre"].Value<JValue>().Value.ToString() : "",
                (item["year"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value) : -1,
                (item["runtime"] != null) ? item["runtime"].Value<JValue>().Value.ToString() : "",
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"].Value<JValue>().Value) : -1,
                (item["tagline"] != null) ? item["tagline"].Value<JValue>().Value.ToString() : "",
                (item["plotoutline"] != null) ? item["plotoutline"].Value<JValue>().Value.ToString() : "",
                (item["showtitle"] != null) ? item["showtitle"].Value<JValue>().Value.ToString() : "",
                (item["season"] != null) ? Convert.ToInt32(item["season"].Value<JValue>().Value) : -1,
                (item["episode"] != null) ? Convert.ToInt32(item["episode"].Value<JValue>().Value) : -1);
 
            return e; 
        }
    }
}