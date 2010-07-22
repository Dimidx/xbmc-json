using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;

namespace XbmcJson
{
    public class Xbmc
    {
       private Settings Settings;
       private JsonRpcClient Client;
       public XbmcAudioPlayer AudioPlayer;
       public XbmcVideoLibrary VideoLibrary;
       public XbmcAudioLibrary AudioLibrary;
       public XbmcStatus Status;
       public XbmcControl Control;
       public XbmcSystem XSystem;
       public XbmcJsonRpc JsonRpc;
       public XbmcPlayer Player;

        public Xbmc(Settings settings)
        {
            Settings = settings;
            Client = new JsonRpcClient(Settings.XbmcUri);
            AudioPlayer = new XbmcAudioPlayer(Settings, Client);
            AudioLibrary = new XbmcAudioLibrary(Settings, Client);
            VideoLibrary = new XbmcVideoLibrary(Settings, Client);
            Status = new XbmcStatus(Settings, Client);
            Control = new XbmcControl(Settings, Client);
            XSystem = new XbmcSystem(Settings, Client);
            JsonRpc = new XbmcJsonRpc(Settings, Client);
            Player = new XbmcPlayer(Settings, Client);
        }
    }
}
