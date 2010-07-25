using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public static Episode EpisodeFromJsonObject(JObject item)
        {
            Episode e = new Episode(
                Convert.ToInt32(item["episodeid"].Value<JValue>().Value.ToString()),
                item["file"].ToString(), item["label"].Value<JValue>().Value.ToString(),
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "",
                (item["plot"] != null) ? item["plot"].Value<JValue>().Value.ToString() : "",
                (item["showtitle"] != null) ? item["showtitle"].Value<JValue>().Value.ToString() : "",
                (item["episode"] != null) ? Convert.ToInt32(item["episode"].Value<JValue>().Value) : -1,
                (item["season"] != null) ? Convert.ToInt32(item["season"].Value<JValue>().Value) : -1,
                (item["year"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value) : -1
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