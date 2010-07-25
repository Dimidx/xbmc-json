using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace XbmcJson
{
    public class Movie
    {
        public int _id, Year;
        public float Rating;
        public string File, Label, Thumbnail, Plot, Director, Writer, Studio, Genre, Runtime, Tagline, PlotOutline;

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
 
        public static Movie MovieFromJsonObject(JObject item)
        {
            Movie e = new Movie(
                Convert.ToInt32(item["movieid"].Value<JValue>().Value), 
                item["file"].Value<JValue>().Value.ToString(), 
                item["label"].Value<JValue>().Value.ToString(), 
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "", 
                (item["plot"] != null) ? item["plot"].Value<JValue>().Value.ToString() : "", 
                (item["director"] != null) ? item["director"].Value<JValue>().Value.ToString() : "", 
                (item["writer"] != null) ? item["writer"].Value<JValue>().Value.ToString() : "", 
                (item["studio"] != null) ? item["studio"].Value<JValue>().Value.ToString() : "", 
                (item["genre"] != null) ? item["genre"].Value<JValue>().Value.ToString() : "", 
                (item["year"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value) : 0, 
                (item["runtime"] != null) ? item["runtime"].Value<JValue>().Value.ToString() : "", 
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"].Value<JValue>().Value) : 0, 
                (item["tagline"] != null) ? item["tagline"].Value<JValue>().Value.ToString() : "", 
                (item["plotoutline"] != null) ? item["plotoutline"].Value<JValue>().Value.ToString() : "");
            return e;
        }

        public static Movie MovieFromPlayListItem(PlaylistItem item)
        {
            Movie e = new Movie(
                item._id,
                item.File,
                item.Label,
                item.Thumbnail,
                item.Plot,
                item.Director,
                item.Writer,
                item.Studio,
                item.Genre,
                item.Year,
                item.Runtime,
                item.Rating,
                item.Tagline,
                item.PlotOutline);
            return e;
        }
    }
}
