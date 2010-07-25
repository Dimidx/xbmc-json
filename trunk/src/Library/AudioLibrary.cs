using Jayrock.Json;
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
            JsonObject query = (JsonObject)Client.Invoke("AudioLibrary.GetArtists");
            List<Artist> list = new List<Artist>();

            if (query["artists"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["artists"])
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

        public List<Album> GetAlbums(string[] fields = null)
        {
            var args = new JsonObject();

            if (fields != null)
                args["fields"] = fields;

            JsonObject query = (JsonObject)Client.Invoke("AudioLibrary.GetAlbums", args);
            List<Album> list = new List<Album>();

            if (query["albums"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["albums"])
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

        public List<Album> GetAlbumsByArtist(int artistId, string[] fields = null)
        {
            var args = new JsonObject();

            args["artistid"] = artistId;
            if (fields != null)
                args["fields"] = fields;

            JsonObject query = (JsonObject)Client.Invoke("AudioLibrary.GetAlbums", args);
            List<Album> list = new List<Album>();

            if (query["albums"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["albums"])
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

        public List<Album> GetAlbumsByGenre(string genre, string[] fields = null)
       {
           var args = new JsonObject();

           args["genre"] = genre;
           if (fields != null)
               args["fields"] = fields;

           JsonObject query = (JsonObject)Client.Invoke("AudioLibrary.GetAlbums", args);
           List<Album> list = new List<Album>();

           if (query["albums"] != null)
           {
               foreach (JsonObject item in (JsonArray)query["albums"])
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

       public List<Song> GetSongs(string[] fields = null)
       {
           JsonObject args = new JsonObject();

           if (fields != null)
               args["fields"] = fields;

           JsonObject query = (JsonObject)Client.Invoke("AudioLibrary.GetSongs", args);
           List<Song> list = new List<Song>();

           if (query["songs"] != null)
           {
               foreach (JsonObject item in (JsonArray)query["songs"])
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

       public List<Song> GetSongsByAlbum(int albumId, string[] fields = null)
       {
            var args = new JsonObject();

            args["albumid"] = albumId;
            if (fields != null)
                args["fields"] = fields;

            JsonObject query = (JsonObject)Client.Invoke("AudioLibrary.GetSongs", args);
            List<Song> list = new List<Song>();

            if (query["songs"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["songs"])
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

       public List<Song> GetSongsByArtist(int artistId, string[] fields = null)
        {
            var args = new JsonObject();

            args["artistid"] = artistId;
            if (fields != null)
                args["fields"] = fields;

            JsonObject query = (JsonObject)Client.Invoke("AudioLibrary.GetSongs", args);
            List<Song> list = new List<Song>();

            if (query["songs"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["songs"])
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

       public List<Song> GetSongsByGenre(string genre, string[] fields = null)
        {
            var args = new JsonObject();

            args["genre"] = genre;
            if (fields != null)
                args["fields"] = fields;

            JsonObject query = (JsonObject)Client.Invoke("AudioLibrary.GetSongs", args);
            List<Song> list = new List<Song>();

            if (query["songs"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["songs"])
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