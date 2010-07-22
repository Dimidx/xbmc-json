using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using Jayrock.Json;

namespace XbmcJson
{
    public class XbmcVideoLibrary
    {
        private Settings Settings;
        private JsonRpcClient Client;

        public XbmcVideoLibrary(Settings settings, JsonRpcClient client)
        {
            Settings = settings;
            Client = client;
        }

        public object GetMovies()
        {
           return Client.Invoke("VideoLibrary.GetMovies");
        }

        public object GetMovies(string[] fields)
        {
            var args = new JsonObject();
            args["fields"] = fields;
            return Client.Invoke("VideoLibrary.GetMovies", args);
        }

        public Image GetVideoArt(String Thumbnail)
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
