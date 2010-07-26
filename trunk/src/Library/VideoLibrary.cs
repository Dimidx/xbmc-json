using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace XbmcJson
{
    public class XbmcVideoLibrary
    {
        private JsonRpcClient Client;
        private string[] AllMovieFields = new string[] { "plot", "director", "writer", "studio", "genre", "year", "runtime", "rating", "tagline", "plotoutline" };
        private string[] AllTvShowFields = new string[] { "plot", "genre", "year", "rating" };
        private string[] AllSeasonFields = new string[] { "genre", "year", "runtime", "rating" };
        private string[] AllEpisodeFields = new string[] { "season", "episode", "runtime", "year", "plot" };
        private string[] AllMusicVideoFields = new string[] { "title", "artist", "genre", "year", "rating", "album" };

        public XbmcVideoLibrary(JsonRpcClient client)
        {
            Client = client;
        }

        public List<Movie> GetMoviesAllFields(string sortMethod, string sortOrder, int? start, int? end)
        {
            return GetMovies(AllMovieFields, sortMethod, sortOrder, start, end);
        }

        public List<Movie> GetMovies()
        {
            return GetMovies(null, null, null, null, null);
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
                args.Add(new JProperty("end", end));

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
            return GetTvShows(AllTvShowFields, sortMethod, sortOrder, start, end);
        }

        public List<TvShow> GetTvShows()
        {
            return GetTvShows(null, null, null, null, null);
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
                args.Add(new JProperty("end", end));


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
            return GetSeasons(tvShowId, AllSeasonFields, sortMethod, sortOrder, start, end);
        }

        public List<Season> GetSeasons(int tvShowId)
        {
            return GetSeasons(tvShowId, null, null, null, null, null);
        }

        public List<Season> GetSeasons(int tvShowId, string[] fields, string sortMethod, string sortOrder, int? start, int? end)
        {
            var args = new JObject();

            args.Add(new JProperty("tvshowid", tvShowId));

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
            return GetEpisodes(tvShowId, season, AllEpisodeFields, sortMethod, sortOrder, start, end);
        }

        public List<Episode> GetEpisodes(int tvShowId, int season)
        {
            return GetEpisodes(tvShowId, season, null, null, null, null, null);
        }

        public List<Episode> GetEpisodes(int tvShowId, int season, string[] fields, string sortMethod, string sortOrder, int? start, int? end)
        {
            var args = new JObject();

            args.Add(new JProperty("tvshowid", tvShowId));
            args.Add(new JProperty("season", season));

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

        public List<MusicVideo> GetMusicVideosAllFields()
        {
            return GetMusicVideos(AllMusicVideoFields);
        }

        public List<MusicVideo> GetMusicVideos()
        {
            return GetMusicVideos(null);
        }
        public List<MusicVideo> GetMusicVideos(string[] fields)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));

            JObject query = (JObject)Client.Invoke("VideoLibrary.GetMusicVideos", args);
            List<MusicVideo> list = new List<MusicVideo>();

            if (query["songs"] != null)
            {
                foreach (JObject item in (JArray)query["musicvideos"])
                {
                    list.Add(MusicVideo.MusicVideoFromJsonObject(item));
                }
            }

            return list;
        }

        public List<Movie> GetRecentlyAddedMoviesAllFields(string sortMethod, string sortOrder, int? start, int? end)
        {
            return GetMovies(AllMovieFields, sortMethod, sortOrder, start, end);
        }

        public List<Movie> GetRecentlyAddedMovies()
        {
            return GetRecentlyAddedMovies(null, null, null, null, null);
        }

        public List<Movie> GetRecentlyAddedMovies(string[] fields, string sortMethod, string sortOrder, int? start, int? end)
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
            return GetRecentlyAddedEpisodes(AllEpisodeFields, sortMethod, sortOrder, start, end);
        }

        public List<Episode> GetRecentlyAddedEpisodes()
        {
            return GetRecentlyAddedEpisodes(null, null, null, null, null);
        }

        public List<Episode> GetRecentlyAddedEpisodes(string[] fields, string sortMethod, string sortOrder, int? start, int? end)
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

        public List<MusicVideo> GetRecentlyAddedMusicVideosAllFields(string sortMethod, string sortOrder, int? start, int? end)
        {
            return GetRecentlyAddedMusicVideos(AllMusicVideoFields, sortMethod, sortOrder, start, end);
        }

        public List<MusicVideo> GetRecentlyAddedMusicVideos()
        {
            return GetRecentlyAddedMusicVideos(null, null, null, null, null);
        }

        public List<MusicVideo> GetRecentlyAddedMusicVideos(string[] fields, string sortMethod, string sortOrder, int? start, int? end)
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

            List<MusicVideo> list = new List<MusicVideo>();
            JObject query = (JObject)Client.Invoke("VideoLibrary.GetRecentlyAddedMusicVideos", args);

            if (query["musicvideos"] != null)
            {
                foreach (JObject item in (JArray)query["musicvideos"])
                {
                    list.Add(MusicVideo.MusicVideoFromJsonObject(item));
                }
            }

            return list;
        }

        public void ScanForContent()
        {
            Client.Invoke("VideoLibrary.ScanForContent");
        }
    }
}
