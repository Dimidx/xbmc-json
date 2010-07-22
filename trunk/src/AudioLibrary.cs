using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Jayrock.Json;
using System.Drawing;

namespace XbmcJson
{
    public class XbmcAudioLibrary
    {
        private Settings Settings;
        private JsonRpcClient Client;

        public XbmcAudioLibrary(Settings settings, JsonRpcClient client)
        {
            this.Settings = settings;
            Client = client;
        }

        public object GetArtists()
        {
            return Client.Invoke("AudioLibrary.GetArtists");
        }

        public object GetAlbums()
        {
            return Client.Invoke("AudioLibrary.GetAlbums");
        }

       public object GetAlbumsByArtist(int artistId)
        {
            var args = new JsonObject();
            args["artistid"] = artistId;
            return Client.Invoke("AudioLibrary.GetAlbums", args);
        }

       public object GetAlbumsByGenre(string genre)
       {
           var args = new JsonObject();
           args["genre"] = genre;
           return Client.Invoke("AudioLibrary.GetAlbums", args);
       }

       public object GetSongs()
       {
           return Client.Invoke("AudioLibrary.GetSongs");
       }

        public object GetSongsByAlbum(int albumId)
        {
            var args = new JsonObject();
            args["albumid"] = albumId;
            return Client.Invoke("AudioLibrary.GetSongs", args);
        }

        public object GetSongsByArtist(int artistId)
        {
            var args = new JsonObject();
            args["artistid"] = artistId;
            return Client.Invoke("AudioLibrary.GetSongs", args);
        }

        public object GetSongsByGenre(string genre)
        {
            var args = new JsonObject();
            args["genre"] = genre;
            return Client.Invoke("AudioLibrary.GetSongs", args);
        }

        public void ScanForContent()
        {
            Client.Invoke("AudioLibrary.ScanForContent");
        }

        public Image GetAudioArt(String Thumbnail)
        {
            String ImageLocation = "http://" + Settings.XbmcIp + ":" + Settings.XbmcPort + "/vfs/" + Thumbnail;
            WebClient ImageGetter = new WebClient();
            Stream stream = ImageGetter.OpenRead(ImageLocation);
            Image RetreievedImage = Image.FromStream(stream);
            stream.Close();
            return RetreievedImage;
        }
    }
}