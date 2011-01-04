using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using xbmc_json_async.System;

namespace xbmc_json_async.Media
{
    public class Album : XbmcMediaItem
    {
        public int Year;
        public float Rating;
        public string Thumbnail { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }

        public Image ThumbnailImage
        {
            get { return XHelpers.GetImageFromThumbnail(Thumbnail); }
        }

        public Uri ThumbnailUri
        {
            get { return XHelpers.ThumbnailUri(Thumbnail); }
        }

        public Album(int id, string label, string thumbnail, string artist, string genre, int year, float rating)
        {
            Id = id;
            Label = label;
            Thumbnail = thumbnail;
            Artist = artist;
            Genre = genre;
            Year = year;
            Rating = rating;
        }

        public static Album FromJsonObject(JObject item)
        {
            var album = new Album(
                Convert.ToInt32(item["albumid"].Value<JValue>().Value.ToString()),
                item["label"].Value<JValue>().Value.ToString(),
                (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : "",
                (item["artist"] != null) ? item["artist"].Value<JValue>().Value.ToString() : "",
                (item["genre"] != null) ? item["genre"].Value<JValue>().Value.ToString() : "",
                (item["year"] != null) ? Convert.ToInt32(item["year"].Value<JValue>().Value) : -1,
                (item["rating"] != null) ? (float)Convert.ToDouble(item["rating"].Value<JValue>().Value) : -1
                );

            return album;
        }

        public override string ToString()
        {
            return Label;
        }
    }
}
