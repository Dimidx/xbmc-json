using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.IO;

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
