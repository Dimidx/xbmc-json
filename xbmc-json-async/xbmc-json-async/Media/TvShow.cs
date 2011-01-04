using System;
using Newtonsoft.Json.Linq;
using System.Drawing;
using xbmc_json_async.System;

namespace xbmc_json_async.Media
{
    public class TvShow : XbmcMediaItem
    {
        public int Year { get; set; }
        public float Rating { get; set; }
        public string Thumbnail { get; set;}
        public string Fanart { get; set; }
        public string Plot { get; set; }
        public string PlotOutline { get; set; }
        public string Genre { get; set; }

        public Image ThumbnailImage
        {
            get { return XHelpers.GetImageFromThumbnail(Thumbnail); }
        }

        public Uri ThumbnailUri
        {
            get { return XHelpers.ThumbnailUri(Thumbnail); }
        }

        public TvShow(int id, string label, string thumbnail, string fanart, string plot,  string genre, int year, float rating)
        {
            Id = id;
            Label = label;
            Thumbnail = thumbnail;
            Fanart = fanart;
            Plot = plot;
            Genre = genre;
            Year = year;
            Rating = rating;

            var temp = plot.Length > 200 ? plot.Substring(0, 200) : plot;

            PlotOutline = temp.Substring(0, temp.LastIndexOf("")) + "...";
        }

        public static TvShow FromJsonObject(JObject item)
        {
            var tvShow = new TvShow(
                Convert.ToInt32(item["tvshowid"].Value<JValue>().Value),
                item["label"].Value<JValue>().Value.ToString(),
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "",
                (item["fanart"] != null) ? item["fanart"].Value<JValue>().Value.ToString() : "",
                (item["plot"] != null) ? item["plot"].Value<JValue>().Value.ToString() : "",
                (item["genre"] != null) ? item["genre"].Value<JValue>().Value.ToString() : "",
                (item["year"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value) : -1,
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"].Value<JValue>().Value) : -1
                );

            return tvShow;
        }

        public override string ToString()
        {
            return Label;
        }
    }
}
