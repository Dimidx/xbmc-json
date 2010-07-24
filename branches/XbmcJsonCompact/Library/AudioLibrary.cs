using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            JObject query = (JObject)Client.Invoke("AudioLibrary.GetArtists");
            List<Artist> list = new List<Artist>();

            foreach (JObject item in (JArray)query.Value<JProperty>("artists").Value)
            {
                list.Add(Artist.ArtistFromJsonObject(item));
            }

            return list;
        }

        public List<Album> GetAlbums()
        {
            JObject query = (JObject)Client.Invoke("AudioLibrary.GetAlbums");
            List<Album> list = new List<Album>();

            foreach (JObject item in (JArray)query.Value<JProperty>("albums").Value)
            {
                list.Add(Album.AlbumFromJsonObject(item));
            }

            return list;
        }

        public List<Album> GetAlbumsByArtist(int artistId)
        {
            var args = new JObject();
            args.Add(new JProperty("artistid", artistId));

            JObject query = (JObject)Client.Invoke("AudioLibrary.GetAlbums", args);
            List<Album> list = new List<Album>();

            foreach (JObject item in (JArray)query.Value<JProperty>("albums").Value)
            {
                list.Add(Album.AlbumFromJsonObject(item));
            }

            return list;
        }

        public List<Album> GetAlbumsByGenre(string genre)
       {
           var args = new JObject();
           args.Add(new JProperty("genre", genre));

           JObject query = (JObject)Client.Invoke("AudioLibrary.GetAlbums", args);
           List<Album> list = new List<Album>();

           foreach (JObject item in (JArray)query.Value<JProperty>("albums").Value)
           {
               list.Add(Album.AlbumFromJsonObject(item));
           }

           return list;
       }

       public List<Song> GetSongs()
       {
           JObject query = (JObject)Client.Invoke("AudioLibrary.GetSongs");
           List<Song> list = new List<Song>();

           DebugLogger.WriteLog(query.ToString());

           foreach (JObject item in (JArray)query.Value<JProperty>("albums").Value)
           {
               list.Add(Song.SongFromJsonObject(item));
           }

           return list;
       }

       public List<Song> GetSongsByAlbum(int albumId)
        {
            var args = new JObject();
            args.Add(new JProperty("albumid", albumId));

            JObject query = (JObject)Client.Invoke("AudioLibrary.GetSongs", args);
            List<Song> list = new List<Song>();

            foreach (JObject item in (JArray)query.Value<JProperty>("songs").Value)
            {
                list.Add(Song.SongFromJsonObject(item));
            }

            return list;
        }

       public List<Song> GetSongsByArtist(int artistId)
        {
            var args = new JObject();
            args.Add(new JProperty("artistid", artistId));

            JObject query = (JObject)Client.Invoke("AudioLibrary.GetSongs", args);
            List<Song> list = new List<Song>();

            foreach (JObject item in (JArray)query.Value<JProperty>("songs").Value)
            {
                list.Add(Song.SongFromJsonObject(item));
            }

            return list;
        }

       public List<Song> GetSongsByGenre(string genre)
        {
            var args = new JObject();
            args.Add(new JProperty("genre", genre));

            JObject query = (JObject)Client.Invoke("AudioLibrary.GetSongs", args);
            List<Song> list = new List<Song>();

            foreach (JObject item in (JArray)query.Value<JProperty>("songs").Value)
            {
                list.Add(Song.SongFromJsonObject(item));
            }

            return list;
        }

        public void ScanForContent()
        {
            Client.Invoke("AudioLibrary.ScanForContent");
        }
    }
}