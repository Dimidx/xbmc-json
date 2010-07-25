using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace XbmcJson
{
    public class XbmcAudioLibrary
    {
        private JsonRpcClient Client;
        private string[] AllSongFields = new string[] { "songid", "title", "artist", "genre", "year", "rating", "album" };
        private string[] AllAlbumFields = new string[] { "artist", "genre", "year", "rating"};

        public XbmcAudioLibrary(JsonRpcClient client)
        {
            Client = client;
        }

        public List<Artist> GetArtists()
        {
            JObject query = (JObject)Client.Invoke("AudioLibrary.GetArtists");
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

        public List<Album> GetAlbumsAllFields()
        {
            return GetAlbums(AllAlbumFields);
        }

        public List<Album> GetAlbums()
        {
            return GetAlbums(null);
        }

        public List<Album> GetAlbums(string[] fields)
        {
            var args = new JObject();

            if (fields != null)
                args.Add(new JProperty("fields", fields));

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

        public List<Album> GetAlbumsByArtistAllFields(int artistId)
        {
            return GetAlbumsByArtist(artistId, AllAlbumFields);
        }

        public List<Album> GetAlbumsByArtist(int artistId)
        {
            return GetAlbumsByArtist(artistId, null);
        }

        public List<Album> GetAlbumsByArtist(int artistId, string[] fields)
        {
            var args = new JObject();

            args.Add(new JProperty("artistid", artistId));
            if (fields != null)
                args.Add(new JProperty("fields", fields));

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

        public List<Album> GetAlbumsByGenreAllFields(string genre)
        {
            return GetAlbumsByGenre(genre, AllAlbumFields);
        }

        public List<Album> GetAlbumsByGenre(string genre)
        {
            return GetAlbumsByGenre(genre, null);
        }

       public List<Album> GetAlbumsByGenre(string genre, string[] fields)
       {
           var args = new JObject();

           args.Add(new JProperty("genre", genre));

           if (fields != null)
               args.Add(new JProperty("fields", fields));

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

       public List<Song> GetSongsAllFields()
       {
           return GetSongs(AllSongFields);
       }

       public List<Song> GetSongs()
       {
           return GetSongs(null);
       }
       public List<Song> GetSongs(string[] fields)
       {
           var args = new JObject();

           if (fields != null)
               args.Add(new JProperty("fields", fields));

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

       public List<Song> GetSongsByAlbumAllFields(int albumId)
       {
            return GetSongsByAlbum(albumId, AllSongFields);
       }

       public List<Song> GetSongsByAlbum(int albumId)
       {
           return GetSongsByAlbum(albumId, null);
       }

       public List<Song> GetSongsByAlbum(int albumId, string[] fields)
       {
           var args = new JObject();

           args.Add(new JProperty("albumid", albumId));
           if (fields != null)
               args.Add(new JProperty("fields", fields));

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

       public List<Song> GetSongsByArtistAllFields(int artistId)
       {
           return GetSongsByArtist(artistId, AllSongFields);
       }

       public List<Song> GetSongsByArtist(int artistId)
       {
           return GetSongsByArtist(artistId, null);
       }

       public List<Song> GetSongsByArtist(int artistId, string[] fields)
        {
            var args = new JObject();

            args.Add(new JProperty("artistid", artistId));
            if (fields != null)
                args.Add(new JProperty("fields", fields));

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

       public List<Song> GetSongsByGenreAllFields(string genre)
       {
           return GetSongsByGenre(genre, AllSongFields);
       }

       public List<Song> GetSongsByGenre(string genre)
       {
           return GetSongsByGenre(genre, null);
       }

       public List<Song> GetSongsByGenre(string genre, string[] fields)
       {
           var args = new JObject();

           args.Add(new JProperty("genre", genre));
           if (fields != null)
               args.Add(new JProperty("fields", fields));

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

        public void ScanForContent()
        {
            Client.Invoke("AudioLibrary.ScanForContent");
        }
    }
}