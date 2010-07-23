using Jayrock.Json;
using System;

namespace XbmcJson
{
    public class TvShow
    {
        private int _id;
        private string File;
        private string Label;
        private string Thumbnail;

        public int id
        {
            get
            {
                return _id;
            }
        }

        public string file
        {
            get
            {
                return File;
            }
        }

        public string label
        {
            get
            {
                return Label;
            }
        }

        public string thumbnail
        {
            get
            {
                return Thumbnail;
            }
        }

        public TvShow(int id, string file, string label, string thumbnail)
        {
            _id = id;
            File = file;
            Label = label;
            Thumbnail = thumbnail;
        }

        public static TvShow TvShowFromJsonObject(JsonObject item)
        {
            TvShow e = new TvShow(Convert.ToInt32(item["tvshowid"]), item["file"].ToString(), item["label"].ToString(), (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "");
            return e;
        }
    }
}
