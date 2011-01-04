using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using xbmc_json_async.System;

namespace xbmc_json_async.Media
{
    public class Movie : XbmcMediaItem
    {
        public int Year { get; set; }
        public float Rating { get; set; }
        public string File { get; set; }
        public string Thumbnail { get; set; }
        public string Fanart { get; set; }
        public string Plot  { get; set; }
        public string Director { get; set; }
        public string Writer  { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public string Runtime { get; set; }
        public string Tagline { get; set; }
        public string PlotOutline { get; set; }

        public Image ThumbnailImage
        {
            get { return XHelpers.GetImageFromThumbnail(Thumbnail); }
        }

        public Uri ThumbnailUri
        {
            get { return XHelpers.ThumbnailUri(Thumbnail); }
        }

        public Image FanartImage
        {
            get { return XHelpers.GetImageFromThumbnail(Fanart); }
        }

        public Uri FanartUri
        {
            get { return XHelpers.ThumbnailUri(Fanart); }
        }

        public Movie(int id, string file, string label, string thumbnail, string fanart, string plot, string director, string writer, string studio, string genre, int year, string runtime, float rating, string tagline, string plotOutline)
        {
            Id = id;
            File = file;
            Label = label;
            Thumbnail = thumbnail;
            Fanart = fanart;
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

        public static Movie FromJsonObject(JObject item)
        {
            var movie = new Movie(
                (item["movieid"] != null) ? Convert.ToInt32(item["movieid"].Value<JValue>().Value) : -1,
                item["file"].Value<JValue>().Value.ToString(),
                item["label"].Value<JValue>().Value.ToString(),
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "",
                (item["fanart"] != null) ? item["fanart"].Value<JValue>().Value.ToString() : "",
                (item["plot"] != null) ? item["plot"].Value<JValue>().Value.ToString() : "",
                (item["director"] != null) ? item["director"].Value<JValue>().Value.ToString() : "",
                (item["writer"] != null) ? item["writer"].Value<JValue>().Value.ToString() : "",
                (item["studio"] != null) ? item["studio"].Value<JValue>().Value.ToString() : "",
                (item["genre"] != null) ? item["genre"].Value<JValue>().Value.ToString() : "",
                (item["year"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value) : -1,
                (item["runtime"] != null) ? item["runtime"].Value<JValue>().Value.ToString() : "",
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"].Value<JValue>().Value) : -1,
                (item["tagline"] != null) ? item["tagline"].Value<JValue>().Value.ToString() : "",
                (item["plotoutline"] != null) ? item["plotoutline"].Value<JValue>().Value.ToString() : ""
                );

            return movie;
        }

        /*
        public static Movie MovieFromPlayListItem(PlaylistItem item)
        {
            Movie e = new Movie(
                item._id,
                item.File,
                item.Label,
                item.Thumbnail,
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
                item.PlotOutline
                );
            return e;
        }
        */

        public override string ToString()
        {
            return Label;
        }
    }
}
