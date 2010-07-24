using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace XbmcJson
{
    public class Share
    {
        public string File, Label;

        public Share(string file, string label)
        {
            File = file;
            Label = label;
        }

        public static Share ShareFromJsonObject(JObject item)
        {
            Share e = new Share(
                item["file"].Value<JValue>().Value.ToString(),
                (item["label"] != null) ? item["label"].Value<JValue>().Value.ToString() : "");
            return e;
        }
    }
}