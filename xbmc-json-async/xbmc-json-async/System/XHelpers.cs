using System;
using System.Drawing;
using System.Net;
using System.IO;

namespace xbmc_json_async.System
{
    public class XHelpers
    {
        public static XSettings Settings;

        public static Uri ThumbnailUri(string thumbnail)
        {
           return new Uri(String.Format("http://{0}:{1}/vfs/{2}", Settings.IpAddress, Settings.Port, thumbnail)); 
        }

        public static Image GetImageFromThumbnail(String thumbnail)
        {
            WebRequest imageGetter = WebRequest.Create(ThumbnailUri(thumbnail));
            imageGetter.Credentials = new NetworkCredential(Settings.UserName, Settings.Password);
            Image retreievedImage = null;

            try
            {
                var stream = imageGetter.GetResponse().GetResponseStream();
                if (stream != null)
                {
                    retreievedImage = new Bitmap(stream);
                    stream.Close();
                }
            }
            catch
            {
                retreievedImage = new Bitmap(32, 32);
            }

            return retreievedImage;
        }
    }
}
