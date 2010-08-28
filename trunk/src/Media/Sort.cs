using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace XbmcJson
{
    public class SortParams
    {
        private int Start = -1, Stop = -1;
        private string Sortmethod, Sortorder;

        public SortParams(string sortmethod, string sortorder, int start, int stop)
        {
            Sortmethod = sortmethod;
            Sortorder = sortorder;
            Start = start;
            Stop = stop;
        }

        public JObject ToJObject()
        {
            JObject sortParams = new JObject();
            if (this.Sortorder != null)
                sortParams.Add(new JProperty("order", Sortorder));
            if (this.Sortmethod != null)
                sortParams.Add(new JProperty("method", Sortmethod));

            JObject sortObj = new JObject();
            if (this.Start != -1)
                sortObj.Add(new JProperty("start", Start));
            if (this.Stop != -1)
                sortObj.Add(new JProperty("stop", Stop));

            if (sortParams != null)
                sortObj.Add(new JProperty("sort", sortParams));

            return sortObj;
        }
    }
}