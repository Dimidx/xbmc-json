using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace XbmcJson
{
    public class Episode
    {
        public int _id, EpisodeNum, Season, Year;
        public string File, Label, Thumbnail, Plot, Show; 

        public Episode(int id, string file, string label, string thumbnail, string plot, string show, int season, int episodeNum, int year)
        {
            _id = id;
            File = file;
            Label = label;
            Thumbnail = thumbnail;
            Plot = plot;
            Show = show;
            Season = season;
            EpisodeNum = episodeNum;
            Year = year;
        } 
 

        public static Episode EpisodeFromJsonObject(JObject item)
        {
            Episode e = new Episode(
                Convert.ToInt32(item["episodeid"].Value<JValue>().Value.ToString()), 
                item["file"].Value<JValue>().Value.ToString(), 
                item["label"].Value<JValue>().Value.ToString(), 
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "",
                (item["plot"] != null) ? item["plot"].Value<JValue>().Value.ToString() : "",
                (item["showtitle"] != null) ? item["showtitle"].Value<JValue>().Value.ToString() : "",
                (item["episode"] != null) ? Convert.ToInt32(item["episode"].Value<JValue>().Value.ToString()) : -1,
                (item["season"] != null) ? Convert.ToInt32(item["season"].Value<JValue>().Value.ToString()) : -1,
                (item["year"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value.ToString().ToString()) : -1);
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
                item.Year);
            return e;
        }
    }
}