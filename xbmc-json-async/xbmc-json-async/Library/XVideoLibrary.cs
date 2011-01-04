using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using xbmc_json_async.Media;
using xbmc_json_async.System;

namespace xbmc_json_async.Library
{
    public class XVideoLibrary
    {
        private readonly string[] _AllEpisodeFields = new[] {"SeasonId", "episode", "runtime", "year", "plot"};
        private readonly string[] _AllMovieFields = new[] {"plot", "director", "writer", "studio", "genre", "year", "runtime", "rating", "tagline", "plotoutline"};
        private readonly string[] _AllSeasonFields = new[] {"SeasonId", "genre", "year", "runtime", "rating"};
        private readonly string[] _AllTvShowFields = new[] {"plot", "genre", "year", "rating"};
        private readonly string[] _MainMenuMovieFields = new[] {"plotoutline"};
        private readonly XClient _Client;

        public XVideoLibrary(XClient client)
        {
            _Client = client;
        }

        public void GetMovie(SortParams sort, XDataReceived userCallback)
        {
            var args = new JObject {new JProperty("fields", _AllMovieFields)};

            if (sort != null)
                args.Add(sort.ToJObject().Children());

            _Client.GetData("VideoLibrary.GetMovies", args, GetMovieCallback, userCallback);
        }

        private void GetMovieCallback(XRequestState requestState)
        {
            var movies = new List<Movie>();

            var query = JObject.Parse(requestState.ResponseData);
            var result = (JObject) query["result"];

            if (result["movies"] != null)
            {
                foreach (JObject item in (JArray) result["movies"])
                {
                    movies.Add(Movie.FromJsonObject(item));
                }
            }

            if (requestState.UserCallback != null)
                requestState.UserCallback(movies);
        }

        public void GetMovies(SortParams sort, XDataReceived userCallback)
        {
            var args = new JObject { new JProperty("fields", _MainMenuMovieFields) };

            if (sort != null)
                args.Add(sort.ToJObject().Children());

            _Client.GetData("VideoLibrary.GetMovies", args, GetMoviesCallback, userCallback);
        }

        private void GetMoviesCallback(XRequestState requestState)
        {
            var movies = new List<Movie>();

            var query = JObject.Parse(requestState.ResponseData);
            var result = (JObject) query["result"];

            if (result["movies"] != null)
            {
                foreach (JObject item in (JArray) result["movies"])
                {
                    movies.Add(Movie.FromJsonObject(item));
                }
            }

            if (requestState.UserCallback != null)
                requestState.UserCallback(movies);
        }

        public void GetTvShows(SortParams sort, XDataReceived userCallback)
        {
            var args = new JObject {new JProperty("fields", _AllTvShowFields)};

            if (sort != null)
                args.Add(sort.ToJObject().Children());

            _Client.GetData("VideoLibrary.GetTvShows", args, GetTvShowsCallback, userCallback);
        }

        private void GetTvShowsCallback(XRequestState requestState)
        {
            var tvShows = new List<TvShow>();

            var query = JObject.Parse(requestState.ResponseData);
            var result = (JObject) query["result"];

            if (result["tvshows"] != null)
            {
                foreach (JObject item in (JArray) result["tvshows"])
                {
                    tvShows.Add(TvShow.FromJsonObject(item));
                }
            }

            if (requestState.UserCallback != null)
                requestState.UserCallback(tvShows);
        }

        public void GetSeasons(int tvShowId, SortParams sort, XDataReceived userCallback)
        {
            var args = new JObject {new JProperty("tvshowid", tvShowId), new JProperty("fields", _AllSeasonFields)};

            if (sort != null)
                args.Add(sort.ToJObject().Children());

            _Client.GetData("VideoLibrary.GetSeasons", args, GetSeasonsCallback, userCallback);
        }

        private void GetSeasonsCallback(XRequestState requestState)
        {
            var seasons = new List<Season>();

            var query = JObject.Parse(requestState.ResponseData);
            var result = (JObject) query["result"];

            if (result["seasons"] != null)
            {
                foreach (JObject item in (JArray) result["seasons"])
                {
                    seasons.Add(Season.FromJsonObject(item));
                }
            }

            if (requestState.UserCallback != null)
                requestState.UserCallback(seasons);
        }

        public void GetEpisodes(int tvShowId, int season, SortParams sort, XDataReceived userCallback)
        {
            var args = new JObject
                           {
                               new JProperty("tvshowid", tvShowId),
                               new JProperty("SeasonId", season),
                               new JProperty("fields", _AllEpisodeFields)
                           };

            if (sort != null)
                args.Add(sort.ToJObject().Children());

            _Client.GetData("VideoLibrary.GetEpisodes", args, GetEpisodesCallback, userCallback);
        }

        private void GetEpisodesCallback(XRequestState requestState)
        {
            var episodes = new List<Episode>();

            var query = JObject.Parse(requestState.ResponseData);
            var result = (JObject) query["result"];

            if (result["episodes"] != null)
            {
                foreach (JObject item in (JArray) result["episodes"])
                {
                    episodes.Add(Episode.FromJsonObject(item));
                }
            }

            if (requestState.UserCallback != null)
                requestState.UserCallback(episodes);
        }
    }
}