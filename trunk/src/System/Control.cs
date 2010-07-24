using System;
using Jayrock.Json;

namespace XbmcJson
{
    public class XbmcControl
    {
        private JsonRpcClient Client;

        public XbmcControl(JsonRpcClient client)
        {
            Client = client;
        }

        public int GetVolume()
        {
            JsonObject query = (JsonObject)Client.Invoke("XBMC.GetVolume");

            if (query != null)
                return Convert.ToInt32(query);
            else
                return -1;
        }

        public void SetVolume(int volume)
        {
            if (volume < 0)
                volume = 0;

            if (volume > 100)
                volume = 100;

            Client.Invoke("XBMC.SetVolume", volume);
        }

        public void ToggleMute()
        {
            Client.Invoke("XBMC.ToggleMute");
        }

        public void Play()
        {
            Client.Invoke("XBMC.Play");
        }

        public void Quit()
        {
            Client.Invoke("XBMC.Quit");
        }

        public void StartSlideShow(string directory, bool random = true, bool recursive = true)
        {
            var args = new JsonObject();

            args["directory"] = directory;
            args["random"] = random;
            args["recursive"] = recursive;

            Client.Invoke("XBMC.StartSlideShow", args);
        }

        public void Log(string message, string level = "info")
        {
            var args = new JsonObject();

            args["message"] = message;
            args["level"] = level;

            Client.Invoke("XBMC.Log", args);
        }
    }
}
