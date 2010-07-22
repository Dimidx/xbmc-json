using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;

namespace XbmcJson
{
    public class XbmcControl
    {
        private Settings Settings;
        private JsonRpcClient Client;

        public XbmcControl(Settings Settings, JsonRpcClient client)
        {
            this.Settings = Settings;
            Client = client;
        }

        public int GetVolume()
        {
           return Convert.ToInt32(Client.Invoke("XBMC.GetVolume"));
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

        public void Log(string message)
        {
            Client.Invoke("XBMC.Log", message);
        }
    }
}
