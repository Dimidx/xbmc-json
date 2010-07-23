using Jayrock.Json;

namespace XbmcJson
{
    public class XbmcAudioLibrary
    {
        private JsonRpcClient Client;

        public XbmcAudioLibrary(JsonRpcClient client)
        {
            Client = client;
        }

        public JsonObject GetArtists()
        {
            return (JsonObject)Client.Invoke("AudioLibrary.GetArtists");
        }

        public JsonObject GetAlbums()
        {
            return (JsonObject)Client.Invoke("AudioLibrary.GetAlbums");
        }

        public JsonObject GetAlbumsByArtist(int artistId)
        {
            var args = new JsonObject();
            args["artistid"] = artistId;
            return (JsonObject)Client.Invoke("AudioLibrary.GetAlbums", args);
        }

       public JsonObject GetAlbumsByGenre(string genre)
       {
           var args = new JsonObject();
           args["genre"] = genre;
           return (JsonObject)Client.Invoke("AudioLibrary.GetAlbums", args);
       }

       public JsonObject GetSongs()
       {
           return (JsonObject)Client.Invoke("AudioLibrary.GetSongs");
       }

       public JsonObject GetSongsByAlbum(int albumId)
        {
            var args = new JsonObject();
            args["albumid"] = albumId;
            return (JsonObject)Client.Invoke("AudioLibrary.GetSongs", args);
        }

       public JsonObject GetSongsByArtist(int artistId)
        {
            var args = new JsonObject();
            args["artistid"] = artistId;
            return (JsonObject)Client.Invoke("AudioLibrary.GetSongs", args);
        }

       public JsonObject GetSongsByGenre(string genre)
        {
            var args = new JsonObject();
            args["genre"] = genre;
            return (JsonObject)Client.Invoke("AudioLibrary.GetSongs", args);
        }

        public void ScanForContent()
        {
            Client.Invoke("AudioLibrary.ScanForContent");
        }
    }
}