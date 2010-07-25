using System;
using System.Drawing;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            var args = new JObject();
            args.Add(new JProperty("media", media));

            JObject query = (JObject)Client.Invoke("Files.GetSources", args);
            List<Share> list = new List<Share>();

            if (query["shares"] != null)
            {
                foreach (JObject item in (JArray)query["shares"])
                {
                    list.Add(Share.ShareFromJsonObject(item));
                }
            }

            return list;
        }

        public string Download(string file)
        {
            JObject query = (JObject)Client.Invoke("Files.Download", file);

            if (query["path"] != null)
                return query["path"].Value<JValue>().Value.ToString();
            else
                return "";
        }

        public List<string> GetDirectory(string directory, string media)
        {
            var args = new JObject();

            args.Add(new JProperty("directory", directory));
            args.Add(new JProperty("media", media));

            JObject query = (JObject)Client.Invoke("Files.GetDirectory", args);

            List<string> list = new List<string>();

            if (query["directories"] != null)
            {
                foreach (JObject item in (JArray)query["directories"])
                {
                    list.Add(item["file"].Value<JValue>().Value.ToString());
                }
            }

            return list;
        }

        public Image GetImageFromThumbnail(String Thumbnail)
        {
            String ImageLocation = "http://" + XbmcIp + ":" + XbmcPort + "/vfs/" + Thumbnail;
            WebRequest ImageGetter = WebRequest.Create(ImageLocation);
            ImageGetter.Credentials = new System.Net.NetworkCredential(XbmcUser, XbmcPass);
            Image RetreievedImage;

            try
            {
                Stream stream = ImageGetter.GetResponse().GetResponseStream();
                RetreievedImage = new Bitmap(stream);
                stream.Close();
            }
            catch
            {
                RetreievedImage = new Bitmap(32,32);
            }

            return RetreievedImage;
        }
    }
}
