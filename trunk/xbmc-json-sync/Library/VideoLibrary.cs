using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace XbmcJson
{
    public class XbmcVideoLibrary
    {
        #region Declarations
        private JsonRpcClient Client;
        private string[] AllMovieFields = new string[] { "plot", "director", "writer", "studio", "genre", "year", "runtime", "rating", "tagline", "plotoutline" };
        private string[] AllTvShowFields = new string[] { "plot", "genre", "year", "rating" };
        private string[] AllSeasonFields = new string[] {"season", "genre", "year", "runtime", "rating" };
        private string[] AllEpisodeFields = new string[] { "season", "episode", "runtime", "year", "plot" };
        private string[] AllMusicVideoFields = new string[] { "title", "artist", "genre", "year", "rating", "album" };
        #endregion

        #region Constructor
        public XbmcVideoLibrary(JsonRpcClient client)
        {
            Client = client;
        }
        #endregion

        #region GetMovies
        public List<Movie> GetMoviesAllFields()
        {
            return GetMovies(AllMovieFields, null);
        }

        public List<Movie> GetMoviesAllFields(SortParams sort)
        {
            return GetMovies(AllMovieFields, sort);
        }

        public List<Movie> GetMovies()
        {
            return GetMovies(null, null);
        }

        public List<Movie> GetMovies(string[] fields)
        {
            return GetMovies(fields, null);
        }

        public List<Movie> GetMovies(string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

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
        #endregion

        #region GetTvShows
        public List<TvShow> GetTvShowsAllFields()
        {
            return GetTvShows(AllTvShowFields, null);
        }

        public List<TvShow> GetTvShowsAllFields(SortParams sort)
        {
            return GetTvShows(AllTvShowFields, sort);
        }

        public List<TvShow> GetTvShows()
        {
            return GetTvShows(null, null);
        }

        public List<TvShow> GetTvShows(string[] fields)
        {
            return GetTvShows(fields, null);
        }

        public List<TvShow> GetTvShows(string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());


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
        #endregion

        #region GetSeasons
        public List<Season> GetSeasonsAllFields(int tvShowId)
        {
            return GetSeasons(tvShowId, AllSeasonFields, null);
        }

        public List<Season> GetSeasonsAllFields(int tvShowId, SortParams sort)
        {
            return GetSeasons(tvShowId, AllSeasonFields, sort);
        }

        public List<Season> GetSeasons(int tvShowId)
        {
            return GetSeasons(tvShowId, null, null);
        }

        public List<Season> GetSeasons(int tvShowId, string[] fields)
        {
            return GetSeasons(tvShowId, fields, null);
        }

        public List<Season> GetSeasons(int? tvShowId, string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (tvShowId != null)
                args.Add(new JProperty("tvshowid", tvShowId));
            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

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
        #endregion

        #region GetEpisodes
        public List<Episode> GetEpisodesAllFields(int tvShowId, int season)
        {
            return GetEpisodes(tvShowId, season, AllEpisodeFields, null);
        }

        public List<Episode> GetEpisodesAllFields(int tvShowId, int season, SortParams sort)
        {
            return GetEpisodes(tvShowId, season, AllEpisodeFields, sort);
        }

        public List<Episode> GetEpisodes(int tvShowId, int season)
        {
            return GetEpisodes(tvShowId, season, null, null);
        }

        public List<Episode> GetEpisodes(int tvShowId, int season, string[] fields)
        {
            return GetEpisodes(tvShowId, season, fields, null);
        }

        public List<Episode> GetEpisodes(int? tvShowId, int? season, string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (tvShowId != null)
                args.Add(new JProperty("tvshowid", tvShowId));
            if (season != null)
                args.Add(new JProperty("season", season));

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

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
        #endregion

        #region GetMusicVideos
        public List<MusicVideo> GetMusicVideosAllFields()
        {
            return GetMusicVideos(AllMusicVideoFields);
        }

        public List<MusicVideo> GetMusicVideosAllFields(SortParams sort)
        {
            return GetMusicVideos(AllMusicVideoFields, sort);
        }

        public List<MusicVideo> GetMusicVideos()
        {
            return GetMusicVideos(null, null);
        }

        public List<MusicVideo> GetMusicVideos(string[] fields)
        {
            return GetMusicVideos(fields, null);
        }

        public List<MusicVideo> GetMusicVideos(string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

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
#endregion

        #region GetRecentlyAddedMovies
        public List<Movie> GetRecentlyAddedMoviesAllFields()
        {
            return GetRecentlyAddedMovies(AllMovieFields, null);
        }

        public List<Movie> GetRecentlyAddedMoviesAllFields(SortParams sort)
        {
            return GetRecentlyAddedMovies(AllMovieFields, sort);
        }

        public List<Movie> GetRecentlyAddedMovies(string[] fields)
        {
            return GetRecentlyAddedMovies(fields, null);
        }

        public List<Movie> GetRecentlyAddedMovies(string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

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
        #endregion

        #region GetRecentlyAddedEpisodes
        public List<Episode> GetRecentlyAddedEpisodesAllFields()
        {
            return GetRecentlyAddedEpisodes(AllEpisodeFields, null);
        }

        public List<Episode> GetRecentlyAddedEpisodesAllFields(SortParams sort)
        {
            return GetRecentlyAddedEpisodes(AllEpisodeFields, sort);
        }

        public List<Episode> GetRecentlyAddedEpisodes(string[] fields)
        {
            return GetRecentlyAddedEpisodes(fields, null);
        }

        public List<Episode> GetRecentlyAddedEpisodes(string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

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
        #endregion

        #region GetRecentlyAddedMusic
        public List<MusicVideo> GetRecentlyAddedMusicVideosAllFields()
        {
            return GetRecentlyAddedMusicVideos(AllMusicVideoFields, null);
        }

        public List<MusicVideo> GetRecentlyAddedMusicVideosAllFields(SortParams sort)
        {
            return GetRecentlyAddedMusicVideos(AllMusicVideoFields, sort);
        }

        public List<MusicVideo> GetRecentlyAddedMusicVideos()
        {
            return GetRecentlyAddedMusicVideos(null, null);
        }

        public List<MusicVideo> GetRecentlyAddedMusicVideos(string[] fields)
        {
            return GetRecentlyAddedMusicVideos(fields, null);
        }

        public List<MusicVideo> GetRecentlyAddedMusicVideos(string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

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
        #endregion

        #region ScanForContent
        public void ScanForContent()
        {
            Client.Invoke("VideoLibrary.ScanForContent");
        }
        #endregion
    }
}
