using Jayrock.Json;
using System.Collections.Generic;

namespace XbmcJson
{
    public class XbmcAudioLibrary
    {
        private JsonRpcClient Client;

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

        public List<Album> GetAlbums()
        {
            JsonObject query = (JsonObject)Client.Invoke("AudioLibrary.GetAlbums");
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

        public List<Album> GetAlbumsByArtist(int artistId)
        {
            var args = new JsonObject();
            args["artistid"] = artistId;

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

       public List<Album> GetAlbumsByGenre(string genre)
       {
           var args = new JsonObject();
           args["genre"] = genre;

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

       public List<Song> GetSongs()
       {
           JsonObject query = (JsonObject)Client.Invoke("AudioLibrary.GetSongs");
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

       public List<Song> GetSongsByAlbum(int albumId)
        {
            var args = new JsonObject();
            args["albumid"] = albumId;

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

       public List<Song> GetSongsByArtist(int artistId)
        {
            var args = new JsonObject();
            args["artistid"] = artistId;

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

       public List<Song> GetSongsByGenre(string genre)
        {
            var args = new JsonObject();
            args["genre"] = genre;

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