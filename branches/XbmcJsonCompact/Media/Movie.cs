using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace XbmcJson
{
    public class Movie
    {
        public int _id, Year;
        public float Rating;
        public string File, Label, Thumbnail, Plot, Director, Writer, Studio, Genre,  Runtime, Tagline, PlotOutline;

        public Movie(int id, string file, string label, string thumbnail, string plot, string director, string writer, string studio, string genre, int? year, string runtime, float? rating, string tagline, string plotOutline)
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
            Year = (int)year;
            Runtime = runtime;
            Rating = (float)rating;
            Tagline = tagline;
            PlotOutline = plotOutline;
        }

        public static Movie MovieFromJsonObject(JObject item)
        {
            Movie e = new Movie(Convert.ToInt32(item["movieid"].Value<JValue>().Value), item["file"].Value<JValue>().Value.ToString(), item["label"].Value<JValue>().Value.ToString(), (item["thumbnail"].HasValues == true) ? item["thumbnail"].Value<JValue>().Value.ToString() : "", (item["plot"].HasValues == true) ? item["plot"].Value<JValue>().Value.ToString() : "", (item["director"].HasValues == true) ? item["director"].Value<JValue>().Value.ToString() : "", (item["writer"].HasValues == true) ? item["writer"].Value<JValue>().Value.ToString() : "", (item["studio"].HasValues == true) ? item["studio"].Value<JValue>().Value.ToString() : "", (item["genre"].HasValues == true) ? item["genre"].Value<JValue>().Value.ToString() : "", (item["year"].HasValues == true) ? Convert.ToInt32(item["year"].Value<JValue>().Value) : 0, (item["runtime"].HasValues == true) ? item["runtime"].Value<JValue>().Value.ToString() : "", (item["rating"].HasValues == true) ? (float)Convert.ToDouble(item["rating"].Value<JValue>().Value) : 0, (item["tagline"].HasValues == true) ? item["tagline"].Value<JValue>().Value.ToString() : "", (item["plotoutline"].HasValues == true) ? item["plotoutline"].Value<JValue>().Value.ToString() : "");
            return e;
        }
    }
}
