using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace XbmcJson
{
    public class Episode
    {
        public int _id, EpisodeNum, Season, Year;
        public string File, Label, Thumbnail, Plot;

        public Episode(int id, string file, string label, string thumbnail, string plot, int? episodeNum, int? season, int? year)
        {
            _id = id;
            File = file;
            Label = label;
            Thumbnail = thumbnail;
            Plot = plot;
            EpisodeNum = (int)episodeNum;
            Season = (int)season;
            Year = (int)year;
        }

        public static Episode EpisodeFromJsonObject(JObject item)
        {
            Episode e = new Episode(
                Convert.ToInt32(item["episodeid"].Value<JValue>().Value.ToString()), 
                item["file"].Value<JValue>().Value.ToString(), 
                item["label"].Value<JValue>().Value.ToString(), 
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "",
                (item["plot"] != null) ? item["plot"].Value<JValue>().Value.ToString() : "",
                (item["episode"] != null) ? Convert.ToInt32(item["episode"].Value<JValue>().Value.ToString()) : 0,
                (item["season"] != null) ? Convert.ToInt32(item["season"].Value<JValue>().Value.ToString()) : 0,
                (item["episode"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value.ToString().ToString()) : 0);
            return e;
        }
    }
}