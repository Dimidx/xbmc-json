using Jayrock.Json;
using System;

namespace XbmcJson
{
    public class Movie
    {
        public int _id, Year;
        public float Rating;
        public string File, Label, Thumbnail, Plot, Director, Writer, Studio, Genre,  Runtime, Tagline, PlotOutline;

        public Movie(int id, string file, string label, string thumbnail, string plot, string director, string writer, string studio, string genre, int year, string runtime, float rating, string tagline, string plotOutline)
        {
            _id = id;
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
        }

        public static Movie MovieFromJsonObject(JsonObject item)
        {
            Movie e = new Movie(
                Convert.ToInt32(item["movieid"]), 
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
                (item["plotoutline"] != null) ? item["plotoutline"].ToString() : ""
                );

            return e;
        }
    }
}
