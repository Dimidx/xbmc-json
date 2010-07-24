using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace XbmcJson
{
    public class XbmcVideoLibrary
    {
        private JsonRpcClient Client;

        public XbmcVideoLibrary(JsonRpcClient client)
        {
            Client = client;
        }

        public List<Movie> GetMoviesAllFields(string sortMethod, string sortOrder, int? start, int? end) 
        { 
            string[] fields = new string[] { "plot", "director", "writer", "studio", "genre", "year", "runtime", "rating", "tagline", "plotoutline" }; 
            return GetMovies(fields, sortMethod, sortOrder, start, end); 
        }
 

        public List<Movie> GetMovies(string[] fields, string sortMethod, string sortOrder, int? start, int? end)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sortMethod != null)
                args.Add(new JProperty("sortmethod", sortMethod));
            if (sortOrder != null)
                args.Add(new JProperty("sortorder", sortOrder));
            if (start != null)
                args.Add(new JProperty("start", start));
            if (end != null)
                args.Add(new JProperty("end", sortOrder));
            
            List<Movie> list = new List<Movie>();
            JObject query = (JObject)Client.Invoke("VideoLibrary.GetMovies", args);
            
            if (query["movies"] != null)
            {
                foreach (JObject item in (JArray)query["movies"])
                {
                    list.Add(Movie.MovieFromJsonObject(item));
                }
            }

            return list;
        }

        public List<TvShow> GetTvShowsAllFields(string sortMethod, string sortOrder, int? start, int? end) 
        { 
            string[] fields = new string[] { "plot", "genre", "year", "rating"}; 
            return GetTvShows(fields, sortMethod, sortOrder, start, end); 
        } 
 

        public List<TvShow> GetTvShows(string[] fields, string sortMethod, string sortOrder, int? start, int? end)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sortMethod != null)
                args.Add(new JProperty("sortmethod", sortMethod));
            if (sortOrder != null)
                args.Add(new JProperty("sortorder", sortOrder));
            if (start != null)
                args.Add(new JProperty("start", start));
            if (end != null)
                args.Add(new JProperty("end", sortOrder));


            List<TvShow> list = new List<TvShow>();
            JObject query = (JObject)Client.Invoke("VideoLibrary.GetTvShows", args);

            if (query["tvshows"] != null)
            {
                foreach (JObject item in (JArray)query["tvshows"])
                {
                    list.Add(TvShow.TvShowFromJsonObject(item));
                }
            }

            return list;
        }

        public List<Season> GetSeasonsAllFields(int tvShowId, string sortMethod, string sortOrder, int? start, int? end) 
        { 
            string[] fields = new string[] { "genre", "year", "runtime", "rating" }; 
            return GetSeasons(tvShowId, fields, sortMethod, sortOrder, start, end); 
        }

        public List<Season> GetSeasons(int tvShowId, string[] fields, string sortMethod, string sortOrder, int? start, int? end)
        {
            var args = new JObject();

            args.Add(new JProperty("tvshowid", tvShowId));

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            else
                args.Add(new JProperty("fields", new string[] { "genre", "year", "runtime", "rating" }));
            if (sortMethod != null)
                args.Add(new JProperty("sortmethod", sortMethod));
            if (sortOrder != null)
                args.Add(new JProperty("sortorder", sortOrder));
            if (start != null)
                args.Add(new JProperty("start", start));
            if (end != null)
                args.Add(new JProperty("end", sortOrder));

            List<Season> list = new List<Season>();
            JObject query = (JObject)Client.Invoke("VideoLibrary.GetSeasons", args);

            if (query["seasons"] != null)
            {
                foreach (JObject item in (JArray)query["seasons"])
                {
                    list.Add(Season.SeasonFromJsonObject(item));
                }
            }

            return list;
        }

        public List<Episode> GetEpisodesAllFields(int tvShowId, int season, string sortMethod, string sortOrder, int? start, int? end) 
        { 
            string[] fields = new string[] { "season", "episode", "runtime", "year", "plot" }; 
            return GetEpisodes(tvShowId, season, fields, sortMethod, sortOrder, start, end); 
        } 

        public List<Episode> GetEpisodes(int tvShowId, int season, string[] fields, string sortMethod, string sortOrder, int? start, int? end)
        {
            var args = new JObject();

            args.Add(new JProperty("tvshowid", tvShowId));
            args.Add(new JProperty("season", season));

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            else
                args.Add(new JProperty("fields", new string[] { "genre", "year", "runtime", "rating"}));
            if (sortMethod != null)
                args.Add(new JProperty("sortmethod", sortMethod));
            if (sortOrder != null)
                args.Add(new JProperty("sortorder", sortOrder));
            if (start != null)
                args.Add(new JProperty("start", start));
            if (end != null)
                args.Add(new JProperty("end", sortOrder));

            List<Episode> list = new List<Episode>();
            JObject query = (JObject)Client.Invoke("VideoLibrary.GetEpisodes", args);

            if (query["episodes"] != null)
            {
                foreach (JObject item in (JArray)query["episodes"])
                {
                    list.Add(Episode.EpisodeFromJsonObject(item));
                }
            }

            return list;
        }

        public List<Movie> GetRecentlyAddedMoviesAllFields(string sortMethod, string sortOrder, int? start, int? end) 
         { 
             string[] fields = new string[] { "plot", "director", "writer", "studio", "genre", "year", "runtime", "rating", "tagline", "plotoutline" }; 
             return GetMovies(fields, sortMethod, sortOrder, start, end); 
         } 

        public List<Movie> GetRecentlyAddedMovies(string[] fields, string sortMethod, string sortOrder, int? start, int? end)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            else
                args.Add(new JProperty("fields", new string[] { "plot", "director", "writer", "studio", "genre", "year", "runtime", "rating", "tagline", "plotoutline" }));
            if (sortMethod != null)
                args.Add(new JProperty("sortmethod", sortMethod));
            if (sortOrder != null)
                args.Add(new JProperty("sortorder", sortOrder));
            if (start != null)
                args.Add(new JProperty("start", start));
            if (end != null)
                args.Add(new JProperty("end", sortOrder));

            List<Movie> list = new List<Movie>();
            JObject query = (JObject)Client.Invoke("VideoLibrary.GetRecentlyAddedMovies", args);

            if (query["movies"] != null)
            {
                foreach (JObject item in (JArray)query["movies"])
                {
                    list.Add(Movie.MovieFromJsonObject(item));
                }
            }

            return list;
        }

        public List<Episode> GetRecentlyAddedEpisodesAllFields(string sortMethod, string sortOrder, int? start, int? end) 
        { 
            string[] fields = new string[] { "season", "episode", "runtime", "year", "plot" }; 
            return GetRecentlyAddedEpisodes(fields, sortMethod, sortOrder, start, end); 
        }

        public List<Episode> GetRecentlyAddedEpisodes(string[] fields, string sortMethod, string sortOrder, int? start, int? end)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            else
                args.Add(new JProperty("fields", new string[] { "season", "episode", "runtime", "year", "plot" }));
            if (sortMethod != null)
                args.Add(new JProperty("sortmethod", sortMethod));
            if (sortOrder != null)
                args.Add(new JProperty("sortorder", sortOrder));
            if (start != null)
                args.Add(new JProperty("start", start));
            if (end != null)
                args.Add(new JProperty("end", sortOrder));

            List<Episode> list = new List<Episode>();
            JObject query = (JObject)Client.Invoke("VideoLibrary.GetRecentlyAddedEpisodes", args);

            if (query["movies"] != null)
            {
                foreach (JObject item in (JArray)query["movies"])
                {
                    list.Add(Episode.EpisodeFromJsonObject(item));
                }
            }

            return list;
        }

        /*     public JsonObject GetMusicVideos(int artistId, int albumId, string[] fields, string sortMethod, string sortOrder, int? start, int? end = null)
        {
            var args = new JsonObject();

            args["artistid"] = artistId;
            args["albumId"] = albumId;
            if (fields != null)
                args["fields"] = fields;
            if (sortMethod != null)
                args["sortmethod"] = sortMethod;
            if (sortOrder != null)
                args["sortorder"] = sortOrder;
            if (start != null)
                args["start"] = start;
            if (end != null)
                args["end"] = end;

            return (JsonObject)Client.Invoke("VideoLibrary.GetMusicVideos", args);
        }
    */

  /*      public JsonObject GetRecentlyAddedMusicVideos(string[] fields, string sortMethod, string sortOrder, int? start, int? end = null)
        {
            var args = new JsonObject();

            if (fields != null)
                args["fields"] = fields;
            if (sortMethod != null)
                args["sortmethod"] = sortMethod;
            if (sortOrder != null)
                args["sortorder"] = sortOrder;
            if (start != null)
                args["start"] = start;
            if (end != null)
                args["end"] = end;

            return (JsonObject)Client.Invoke("VideoLibrary.GetRecentlyAddedMusicVideos", args);
        } */

        public void ScanForContent()
        {
            Client.Invoke("VideoLibrary.ScanForContent");
        }
    }
}
