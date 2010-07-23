using Jayrock.Json;

namespace XbmcJson
{
    public class Season
    {
        private string File;
        private string Label;
        private string Thumbnail;

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

        public Season(string file, string label, string thumbnail)
        {
            File = file;
            Label = label;
            Thumbnail = thumbnail;
        }

        public static Season SeasonFromJsonObject(JsonObject item)
        {
            Season e = new Season(item["file"].ToString(), item["label"].ToString(), (item["thumbnail"] != null) ? item["thumbnail"].ToString() : "");
            return e;
        }
    }
}
