using Newtonsoft.Json.Linq;

namespace xbmc_json_async.Media
{
    public class SortParams
    {
        private int? Start, Stop;
        private string Sortmethod, Sortorder;

        public SortParams(string sortmethod, string sortorder, int? start, int? stop)
        {
            Sortmethod = sortmethod;
            Sortorder = sortorder;
            Start = start;
            Stop = stop;
        }

        public JObject ToJObject()
        {
            var sortParams = new JObject();
            if (Sortorder != null)
                sortParams.Add(new JProperty("order", Sortorder));
            if (Sortmethod != null)
                sortParams.Add(new JProperty("method", Sortmethod));

            var sortObj = new JObject();
            if (Start != null)
                sortObj.Add(new JProperty("start", Start));
            if (Stop != null)
                sortObj.Add(new JProperty("end", Stop));

            sortObj.Add(new JProperty("sort", sortParams));

            return sortObj;
        }
    }
}