using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace XbmcJson
{
    public class XbmcAudioLibrary
    {
        #region Declarations
        private JsonRpcClient Client;
        private string[] AllSongFields = new string[] { "songid", "title", "artist", "genre", "year", "rating", "album" };
        private string[] AllAlbumFields = new string[] { "artist", "genre", "year", "rating" };
        #endregion

        #region Constructor
        public XbmcAudioLibrary(JsonRpcClient client)
        {
            Client = client;
        }
        #endregion

        #region GetArtist
        public List<Artist> GetArtists()
        {
            return GetArtists(null);
        }

        public List<Artist> GetArtists(SortParams sort)
        {
            var args = new JObject();

            if (sort != null)
                args.Add(sort.ToJObject().Children());

            JObject query = (JObject)Client.Invoke("AudioLibrary.GetArtists", args);
            List<Artist> list = new List<Artist>();

            if (query["artists"] != null)
            {
                foreach (JObject item in (JArray)query["artists"])
                {
                    list.Add(Artist.ArtistFromJsonObject(item));
                }
            }

            return list;
        }
        #endregion

        #region GetAlbums
        public List<Album> GetAlbumsAllFields()
        {
            return GetAlbums(AllAlbumFields, null);
        }

        public List<Album> GetAlbumsAllFields(SortParams sort)
        {
            return GetAlbums(AllAlbumFields, sort);
        }

        public List<Album> GetAlbums()
        {
            return GetAlbums(null, null);
        }

        public List<Album> GetAlbums(string[] fields)
        {
            return GetAlbums(fields, null);
        }

        public List<Album> GetAlbums(string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

            JObject query = (JObject)Client.Invoke("AudioLibrary.GetAlbums", args);
            List<Album> list = new List<Album>();

            if (query["albums"] != null)
            {
                foreach (JObject item in (JArray)query["albums"])
                {
                    list.Add(Album.AlbumFromJsonObject(item));
                }
            }

            return list;
        }
        #endregion

        #region GetAlbumsByGenre
        public List<Album> GetAlbumsByGenreAllFields(string genre)
        {
            return GetAlbumsByGenre(genre, AllAlbumFields);
        }

        public List<Album> GetAlbumsByGenreAllFields(string genre, SortParams sort)
        {
            return GetAlbumsByGenre(genre, AllAlbumFields, sort);
        }

        public List<Album> GetAlbumsByGenre(string genre)
        {
            return GetAlbumsByGenre(genre, null, null);
        }

        public List<Album> GetAlbumsByGenre(string genre, string[] fields)
        {
            return GetAlbumsByGenre(genre, fields);
        }

        public List<Album> GetAlbumsByGenre(string genre, string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (genre != null)
                args.Add(new JProperty("genre", genre));
            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

            JObject query = (JObject)Client.Invoke("AudioLibrary.GetAlbums", args);
            List<Album> list = new List<Album>();

            if (query["albums"] != null)
            {
                foreach (JObject item in (JArray)query["albums"])
                {
                    list.Add(Album.AlbumFromJsonObject(item));
                }
            }

            return list;
        }
        #endregion

        #region GetAlbumsByArtist
        public List<Album> GetAlbumsByArtistAllFields(int artistId)
        {
            return GetAlbumsByArtist(artistId, AllAlbumFields, null);
        }

        public List<Album> GetAlbumsByArtistAllFields(int artistId, SortParams sort)
        {
            return GetAlbumsByArtist(artistId, AllAlbumFields, sort);
        }

        public List<Album> GetAlbumsByArtist(int artistId)
        {
            return GetAlbumsByArtist(artistId, null, null);
        }

        public List<Album> GetAlbumsByArtist(int artistId, string[] fields)
        {
            return GetAlbumsByArtist(artistId, fields, null);
        }

        public List<Album> GetAlbumsByArtist(int? artistId, string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (artistId != null)
                args.Add(new JProperty("artistid", artistId));
            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

            JObject query = (JObject)Client.Invoke("AudioLibrary.GetAlbums", args);
            List<Album> list = new List<Album>();

            if (query["albums"] != null)
            {
                foreach (JObject item in (JArray)query["albums"])
                {
                    list.Add(Album.AlbumFromJsonObject(item));
                }
            }

            return list;
        }
        #endregion

        #region GetAlbumsByGenreAndArtist
        public List<Album> GetAlbumsByGenreAndArtistAllFields(string genre, int artistId)
        {
            return GetAlbumsByGenreAndArtist(genre, artistId, AllAlbumFields, null);
        }

        public List<Album> GetAlbumsByGenreAndArtistAllFields(string genre, int artistId, SortParams sort)
        {
            return GetAlbumsByGenreAndArtist(genre, artistId, AllAlbumFields, sort);
        }

        public List<Album> GetAlbumsByGenreAndArtist(string genre, int artistId)
        {
            return GetAlbumsByGenreAndArtist(genre, artistId, null, null);
        }

        public List<Album> GetAlbumsByGenreAndArtist(string genre, int artistId, string[] fields)
        {
            return GetAlbumsByGenreAndArtist(genre, artistId, fields, null);
        }

        public List<Album> GetAlbumsByGenreAndArtist(string genre, int? artistId, string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (genre != null)
                args.Add(new JProperty("genre", genre));
            if (artistId != null)
                args.Add(new JProperty("artistid", artistId));
            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

            JObject query = (JObject)Client.Invoke("AudioLibrary.GetAlbums", args);
            List<Album> list = new List<Album>();

            if (query["albums"] != null)
            {
                foreach (JObject item in (JArray)query["albums"])
                {
                    list.Add(Album.AlbumFromJsonObject(item));
                }
            }

            return list;
        }
        #endregion

        #region GetSongs
        public List<Song> GetSongsAllFields()
        {
            return GetSongs(AllSongFields, null);
        }

        public List<Song> GetSongsAllFields(SortParams sort)
        {
            return GetSongs(AllSongFields, sort);
        }

        public List<Song> GetSongs()
        {
            return GetSongs(null,null);
        }

        public List<Song> GetSongs(string[] fields)
        {
            return GetSongs(fields, null);
        }

        public List<Song> GetSongs(string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

           JObject query = (JObject)Client.Invoke("AudioLibrary.GetSongs", args);
           List<Song> list = new List<Song>();

           if (query["songs"] != null)
           {
               foreach (JObject item in (JArray)query["songs"])
               {
                   list.Add(Song.SongFromJsonObject(item));
               }
           }

           return list;
        }
        #endregion

        #region GetSongsByGenre
        public List<Song> GetSongsByGenreAllFields(string genre)
        {
            return GetSongsByGenre(genre, AllSongFields);
        }

        public List<Song> GetSongsByGenreAllFields(string genre, SortParams sort)
        {
            return GetSongsByGenre(genre, AllSongFields, sort);
        }

        public List<Song> GetSongsByGenre(string genre)
        {
            return GetSongsByGenre(genre, null, null);
        }

        public List<Song> GetSongsByGenre(string genre, string[] fields)
        {
            return GetSongsByGenre(genre, fields, null);
        }

        public List<Song> GetSongsByGenre(string genre, string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (genre != null)
                args.Add(new JProperty("genre", genre));
            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

            JObject query = (JObject)Client.Invoke("AudioLibrary.GetSongs", args);
            List<Song> list = new List<Song>();

            if (query["songs"] != null)
            {
                foreach (JObject item in (JArray)query["songs"])
                {
                    list.Add(Song.SongFromJsonObject(item));
                }
            }

            return list;
        }
        #endregion

        #region GetSongsByArtist
        public List<Song> GetSongsByArtistAllFields(int artistId)
        {
            return GetSongsByArtist(artistId, AllSongFields, null);
        }

        public List<Song> GetSongsByArtistAllFields(int artistId, SortParams sort)
        {
            return GetSongsByArtist(artistId, AllSongFields, sort);
        }

        public List<Song> GetSongsByArtist(int artistId)
        {
            return GetSongsByArtist(artistId, null, null);
        }

        public List<Song> GetSongsByArtist(int artistId, string[] fields)
        {
            return GetSongsByArtist(artistId, fields, null);
        }

        public List<Song> GetSongsByArtist(int? artistId, string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (artistId != null)
                args.Add(new JProperty("artistid", artistId));
            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

            JObject query = (JObject)Client.Invoke("AudioLibrary.GetSongs", args);
            List<Song> list = new List<Song>();

            if (query["songs"] != null)
            {
                foreach (JObject item in (JArray)query["songs"])
                {
                    list.Add(Song.SongFromJsonObject(item));
                }
            }

            return list;
        }
        #endregion

        #region GetSongsByGenreAndArtist
        public List<Song> GetSongsByGenreAndArtistAllFields(string genre, int artistId)
        {
            return GetSongsByGenreAndArtist(genre, artistId, AllSongFields);
        }

        public List<Song> GetSongsByGenreAndArtistAllFields(string genre, int artistId, SortParams sort)
        {
            return GetSongsByGenreAndArtist(genre, artistId, AllSongFields, sort);
        }

        public List<Song> GetSongsByGenreAndArtist(string genre, int artistId)
        {
            return GetSongsByGenreAndArtist(genre, artistId, null, null);
        }

        public List<Song> GetSongsByGenreAndArtist(string genre, int artistId, string[] fields)
        {
            return GetSongsByGenreAndArtist(genre, artistId, fields, null);
        }

        public List<Song> GetSongsByGenreAndArtist(string genre, int? artistId, string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (genre != null)
                args.Add(new JProperty("genre", genre));
            if (artistId != null)
                args.Add(new JProperty("artistid", artistId));
            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

            JObject query = (JObject)Client.Invoke("AudioLibrary.GetSongs", args);
            List<Song> list = new List<Song>();

            if (query["songs"] != null)
            {
                foreach (JObject item in (JArray)query["songs"])
                {
                    list.Add(Song.SongFromJsonObject(item));
                }
            }

            return list;
        }
        #endregion

        #region GetSongsByAlbum
        public List<Song> GetSongsByAlbumAllFields(int albumId)
        {
            return GetSongsByAlbum(albumId, AllSongFields);
        }

        public List<Song> GetSongsByAlbumAllFields(int albumId, SortParams sort)
        {
            return GetSongsByAlbum(albumId, AllSongFields, sort);
        }

        public List<Song> GetSongsByAlbum(int albumId)
        {
            return GetSongsByAlbum(albumId, null, null);
        }

        public List<Song> GetSongsByAlbum(int albumId, string[] fields)
        {
            return GetSongsByAlbum(albumId, fields, null);
        }

        public List<Song> GetSongsByAlbum(int? albumId, string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (albumId != null)
                args.Add(new JProperty("albumid", albumId));
            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

            JObject query = (JObject)Client.Invoke("AudioLibrary.GetSongs", args);
            List<Song> list = new List<Song>();

            if (query["songs"] != null)
            {
                foreach (JObject item in (JArray)query["songs"])
                {
                    list.Add(Song.SongFromJsonObject(item));
                }
            }

            return list;
        }
        #endregion

        #region GetSongsByArtistAndAlbum
        public List<Song> GetSongsByArtistAndAlbumAllFields(int artistId, int albumId)
        {
            return GetSongsByArtistAndAlbum(artistId, albumId, AllSongFields, null);
        }

        public List<Song> GetSongsByArtistAndAlbumAllFields(int artistId, int albumId, SortParams sort)
        {
            return GetSongsByArtistAndAlbum(artistId, albumId, AllSongFields, sort);
        }

        public List<Song> GetSongsByArtistAndAlbum(int artistId, int albumId)
        {
            return GetSongsByArtistAndAlbum(artistId, albumId, null, null);
        }

        public List<Song> GetSongsByArtistAndAlbum(int artistId, int albumId, string[] fields)
        {
            return GetSongsByArtistAndAlbum(artistId, albumId, fields, null);
        }

        public List<Song> GetSongsByArtistAndAlbum(int? artistId, int? albumId, string[] fields, SortParams sort)
        {
            var args = new JObject();

            if (artistId != null)
                args.Add(new JProperty("artistid", artistId));
            if (albumId != null)
                args.Add(new JProperty("albumid", albumId));
            if (fields != null)
                args.Add(new JProperty("fields", fields));
            if (sort != null)
                args.Add(sort.ToJObject().Children());

            JObject query = (JObject)Client.Invoke("AudioLibrary.GetSongs", args);
            List<Song> list = new List<Song>();

            if (query["songs"] != null)
            {
                foreach (JObject item in (JArray)query["songs"])
                {
                    list.Add(Song.SongFromJsonObject(item));
                }
            }

            return list;
        }
        #endregion

        #region ScanForContent
        public void ScanForContent()
        {
            Client.Invoke("AudioLibrary.ScanForContent");
        }
        #endregion
    }
}