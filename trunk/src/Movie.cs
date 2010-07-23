using Jayrock.Json;
using System;

namespace XbmcJson
{
    public class Movie
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

        public Movie(int id, string file, string label, string thumbnail)
        {
            _id = id;
            File = file;
            Label = label;
            Thumbnail = thumbnail;
        }

        public static Movie MovieFromJsonObject(JsonObject item)
        {
            Movie e = new Movie(Convert.ToInt32(item["movieid"]), item["file"].ToString(), item["label"].ToString(), (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "");
            return e;
        }
    }
}
