using Jayrock.Json;
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

        public List<Movie> GetMoviesAllFields(string sortMethod = null, string sortOrder = null, int? start = null, int? end = null)
        {
            string[] fields = new string[] { "plot", "director", "writer", "studio", "genre", "year", "runtime", "rating", "tagline", "plotoutline" };
            return GetMovies(fields, sortMethod, sortOrder, start, end);
        }

        public List<Movie> GetMovies(string[] fields = null, string sortMethod = null, string sortOrder = null, int? start = null, int? end = null)
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
            
            List<Movie> list = new List<Movie>();
            JsonObject query = (JsonObject)Client.Invoke("VideoLibrary.GetMovies", args);

            if (query["movies"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["movies"])
                {
                    list.Add(Movie.MovieFromJsonObject(item));
                }
            }

            return list;
        }

        public List<TvShow> GetTvShowsAllFields(string sortMethod = null, string sortOrder = null, int? start = null, int? end = null)
        {
            string[] fields = new string[] { "plot", "genre", "year", "rating"};
            return GetTvShows(fields, sortMethod, sortOrder, start, end);
        }

        public List<TvShow> GetTvShows(string[] fields = null, string sortMethod = null, string sortOrder = null, int? start = null, int? end = null)
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

            List<TvShow> list = new List<TvShow>();
            JsonObject query = (JsonObject)Client.Invoke("VideoLibrary.GetTvShows", args);

            if (query["tvshows"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["tvshows"])
                {
                    list.Add(TvShow.TvShowFromJsonObject(item));
                }
            }

            return list;
        }

        public List<Season> GetSeasonsAllFields(int tvShowId, string sortMethod = null, string sortOrder = null, int? start = null, int? end = null)
        {
            string[] fields = new string[] { "genre", "year", "runtime", "rating" };
            return GetSeasons(tvShowId, fields, sortMethod, sortOrder, start, end);
        }

        public List<Season> GetSeasons(int tvShowId, string[] fields = null, string sortMethod = null, string sortOrder = null, int? start = null, int? end = null)
        {
            var args = new JsonObject();

            args["tvshowid"] = tvShowId;
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

            List<Season> list = new List<Season>();
            JsonObject query = (JsonObject)Client.Invoke("VideoLibrary.GetSeasons", args);

            if (query["seasons"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["seasons"])
                {
                    list.Add(Season.SeasonFromJsonObject(item));
                }
            }

            return list;
        }

        public List<Episode> GetEpisodesAllFields(int tvShowId, int season, string sortMethod = null, string sortOrder = null, int? start = null, int? end = null)
        {
            string[] fields = new string[] { "season", "episode", "runtime", "year", "plot" };
            return GetEpisodes(tvShowId, season, fields, sortMethod, sortOrder, start, end);
        }

        public List<Episode> GetEpisodes(int tvShowId, int season, string[] fields = null, string sortMethod = null, string sortOrder = null, int? start = null, int? end = null)
        {
            var args = new JsonObject();

            args["tvshowid"] = tvShowId;
            args["season"] = season;
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

            List<Episode> list = new List<Episode>();
            JsonObject query = (JsonObject)Client.Invoke("VideoLibrary.GetEpisodes", args);

            if (query["episodes"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["episodes"])
                {
                    list.Add(Episode.EpisodeFromJsonObject(item));
                }
            }

            return list;
        }

        public List<Movie> GetRecentlyAddedMoviesAllFields(string sortMethod = null, string sortOrder = null, int? start = null, int? end = null)
        {
            string[] fields = new string[] { "plot", "director", "writer", "studio", "genre", "year", "runtime", "rating", "tagline", "plotoutline" };
            return GetMovies(fields, sortMethod, sortOrder, start, end);
        }

        public List<Movie> GetRecentlyAddedMovies(string[] fields = null, string sortMethod = null, string sortOrder = null, int? start = null, int? end = null)
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

            List<Movie> list = new List<Movie>();
            JsonObject query = (JsonObject)Client.Invoke("VideoLibrary.GetRecentlyAddedMovies", args);

            if (query["movies"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["movies"])
                {
                    list.Add(Movie.MovieFromJsonObject(item));
                }
            }

            return list;
        }

        public List<Episode> GetRecentlyAddedEpisodesAllFields(string sortMethod = null, string sortOrder = null, int? start = null, int? end = null)
        {
            string[] fields = new string[] { "season", "episode", "runtime", "year", "plot" };
            return GetRecentlyAddedEpisodes(fields, sortMethod, sortOrder, start, end);
        }

        public List<Episode> GetRecentlyAddedEpisodes(string[] fields = null, string sortMethod = null, string sortOrder = null, int? start = null, int? end = null)
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

            List<Episode> list = new List<Episode>();
            JsonObject query = (JsonObject)Client.Invoke("VideoLibrary.GetRecentlyAddedEpisodes", args);

            if (query["episodes"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["episodes"])
                {
                    list.Add(Episode.EpisodeFromJsonObject(item));
                }
            }

            return list;
        }

        /* I need to get some music videos before I can code and test this >.<
        public JsonObject GetMusicVideos(int artistId, int albumId, string[] fields = null, string sortMethod = null, string sortOrder = null, int? start = null, int? end = null)
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

        public JsonObject GetRecentlyAddedMusicVideos(string[] fields = null, string sortMethod = null, string sortOrder = null, int? start = null, int? end = null)
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
        } 
        */

        public void ScanForContent()
        {
            Client.Invoke("VideoLibrary.ScanForContent");
        }
    }
}
