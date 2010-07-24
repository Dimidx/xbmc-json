using System;
using System.Drawing;
using System.Net;
using System.IO;
using Jayrock.Json;
using System.Collections.Generic;

namespace XbmcJson
{
    public class XbmcFiles
    {
        private JsonRpcClient Client;
        public string XbmcIp;
        public Int32 XbmcPort;
        public string XbmcUser;
        public string XbmcPass;

        public XbmcFiles(JsonRpcClient client, string xbmcIp, int xbmcPort, string xbmcUser, string xbmcPass)
        {
            Client = client;
            XbmcIp = xbmcIp;
            XbmcPort = xbmcPort;
            XbmcUser = xbmcUser;
            XbmcPass = xbmcPass;
        }

        public List<Share> GetSources(string media)
        {
            var args = new JsonObject();
            args["media"] = media;

            JsonObject query = (JsonObject)Client.Invoke("Files.GetSources", args);
            List<Share> list = new List<Share>();

            if (query["shares"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["shares"])
                {
                    list.Add(Share.ShareFromJsonObject(item));
                }
            }

            return list;
        }

        public string Download(string file)
        {
            JsonObject query = (JsonObject)Client.Invoke("Files.Download", file);

            if (query["path"] != null)
                return query["path"].ToString();
            else
                return "";
        }

        public List<string> GetDirectory(string directory, string media)
        {
            var args = new JsonObject();

            args["directory"] = directory;
            args["media"] = media;

            JsonObject query = (JsonObject)Client.Invoke("Files.GetDirectory", args);
            List<string> list = new List<string>();

            if (query["directories"] != null)
            {
                foreach (JsonObject item in (JsonArray)query["directories"])
                {
                    list.Add(item["file"].ToString());
                }
            }

            return list;
        }

        public Image GetImageFromThumbnail(String Thumbnail)
        {
            String ImageLocation = "http://" + XbmcIp + ":" + XbmcPort + "/vfs/" + Thumbnail;
            WebClient ImageGetter = new WebClient();
            ImageGetter.Credentials = new System.Net.NetworkCredential(XbmcUser, XbmcPass);
            Stream stream = ImageGetter.OpenRead(ImageLocation);
            Image RetreievedImage = Image.FromStream(stream);
            stream.Close();
            return RetreievedImage;
        }
    }
}
