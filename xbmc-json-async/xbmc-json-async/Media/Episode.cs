using System;
using System.Drawing;
using Newtonsoft.Json.Linq;
using xbmc_json_async.System;

namespace xbmc_json_async.Media
{
    public class Episode : XbmcMediaItem
    {
        public int Season { get; set; }
        public int Year { get; set; }
        public int EpisodeNumber { get; set; }
        public string File { get; set; }
        public string Thumbnail { get; set; }
        public string Fanart { get; set; }
        public string Plot { get; set; }
        public string Show { get; set; }

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

        public Episode(int id, string file, string label, string thumbnail, string fanart, string plot, string show,
               int episodeNumber, int season, int year)
        {
            Id = id;
            File = file;
            Label = label;
            Thumbnail = thumbnail;
            Fanart = fanart;
            Plot = plot;
            Show = show;
            EpisodeNumber = episodeNumber;
            Season = season;
            Year = year;
        }

        public static Episode FromJsonObject(JObject item)
        {
            var e = new Episode(
                Convert.ToInt32(item["episodeid"].Value<JValue>().Value.ToString()),
                item["file"].ToString(), item["label"].Value<JValue>().Value.ToString(),
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "",
                (item["fanart"] != null) ? item["fanart"].Value<JValue>().Value.ToString() : "",
                (item["plot"] != null) ? item["plot"].Value<JValue>().Value.ToString() : "",
                (item["showtitle"] != null) ? item["showtitle"].Value<JValue>().Value.ToString() : "",
                (item["episode"] != null) ? Convert.ToInt32(item["episode"].Value<JValue>().Value) : -1,
                (item["SeasonId"] != null) ? Convert.ToInt32(item["SeasonId"].Value<JValue>().Value) : -1,
                (item["year"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value) : -1
                );

            return e;
        }

        /*
        public static Episode FromPlayListItem(PlaylistItem item)
        {
            Episode e = new Episode(
                item._id,
                item.File,
                item.Label,
                item.Thumbnail,
                item.Thumbnail,
                item.Plot,
                item.Show,
                item.EpisodeNum,
                item.Season,
                item.Year
                );
            return e;
        }
        */

        public override string ToString()
        {
            if (Label != "")
                return Label;
            else
                return File;
        }
    }
}