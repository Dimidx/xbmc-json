using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using xbmc_json_async.Media;
using xbmc_json_async.System;

namespace xbmc_json_async.Library
{
    public class XAudioLibrary
    {
        private readonly string[] _AllAlbumFields = new[] {"artist", "genre", "year", "rating"};
        private readonly string[] _AllSongFields = new[] {"songid", "title", "artist", "genre", "year", "rating", "album"};
        private readonly XClient _Client;

        public XAudioLibrary(XClient client)
        {
            _Client = client;
        }

        public void GetArtists(SortParams sort, XDataReceived userCallback)
        {
            var args = new JObject();

            if (sort != null)
                args.Add(sort.ToJObject().Children());

            _Client.GetData("AudioLibrary.GetArtists", args, GetArtistsCallback, userCallback);
        }

        private void GetArtistsCallback(XRequestState requestState)
        {
            var artists = new List<Artist>();

            var query = JObject.Parse(requestState.ResponseData);
            var result = (JObject) query["result"];

            if (result["artists"] != null)
            {
                foreach (JObject item in (JArray) result["artists"])
                {
                    artists.Add(Artist.FromJsonObject(item));
                }
            }

            if (requestState.UserCallback != null)
                requestState.UserCallback(artists);
        }

        public void GetAlbums(SortParams sort, XDataReceived userCallback)
        {
            var args = new JObject();

            args.Add(new JProperty("fields", _AllAlbumFields));

            if (sort != null)
                args.Add(sort.ToJObject().Children());

            _Client.GetData("AudioLibrary.GetAlbums", args, GetAlbumsCallback, userCallback);
        }

        public void GetAlbumsByArtist(int artistId, SortParams sort, XDataReceived userCallback)
        {
            var args = new JObject {new JProperty("artistid", artistId), new JProperty("fields", _AllAlbumFields)};

            if (sort != null)
                args.Add(sort.ToJObject().Children());

            _Client.GetData("AudioLibrary.GetAlbums", args, GetAlbumsCallback, userCallback);
        }

        private void GetAlbumsCallback(XRequestState requestState)
        {
            var albums = new List<Album>();

            JObject query = JObject.Parse(requestState.ResponseData);
            var result = (JObject) query["result"];

            if (result["albums"] != null)
            {
                foreach (JObject item in (JArray) result["albums"])
                {
                    albums.Add(Album.FromJsonObject(item));
                }
            }

            if (requestState.UserCallback != null)
                requestState.UserCallback(albums);
        }

        public void GetSongs(SortParams sort, XDataReceived userCallback)
        {
            var args = new JObject {new JProperty("fields", _AllSongFields)};

            if (sort != null)
                args.Add(sort.ToJObject().Children());

            _Client.GetData("AudioLibrary.GetSongs", args, GetSongsCallback, userCallback);
        }

        public void GetSongsByArtist(int artistId, SortParams sort, XDataReceived userCallback)
        {
            var args = new JObject {new JProperty("artistid", artistId), new JProperty("fields", _AllSongFields)};

            if (sort != null)
                args.Add(sort.ToJObject().Children());

            _Client.GetData("AudioLibrary.GetSongs", args, GetSongsCallback, userCallback);
        }

        public void GetSongsByAlbum(int albumId, SortParams sort, XDataReceived userCallback, Action<List<Song>> actionCallback)
        {
            var args = new JObject {new JProperty("albumid", albumId), new JProperty("fields", _AllSongFields)};

            if (sort != null)
                args.Add(sort.ToJObject().Children());

            _Client.GetData("AudioLibrary.GetSongs", args, GetSongsCallback, userCallback);
        }

        private void GetSongsCallback(XRequestState requestState)
        {
            var songs = new List<Song>();

            var query = JObject.Parse(requestState.ResponseData);
            var result = (JObject) query["result"];

            if (result["songs"] != null)
            {
                foreach (JObject item in (JArray) result["songs"])
                {
                    songs.Add(Song.FromJsonObject(item));
                }
            }

            if (requestState.UserCallback != null)
                requestState.UserCallback(songs);
        }
    }
}