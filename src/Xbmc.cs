using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;

namespace XbmcJson
{
    public class Xbmc
    {
       private JsonRpcClient Client;
       public Uri XbmcUri;
       public string XbmcIp;
       public Int32 XbmcPort;
       public string XbmcUser;
       public string XbmcPass;
       public XbmcAudioPlayer AudioPlayer;
       public XbmcVideoLibrary VideoLibrary;
       public XbmcAudioLibrary AudioLibrary;
       public XbmcStatus Status;
       public XbmcControl Control;
       public XbmcSystem XSystem;
       public XbmcJsonRpc JsonRpc;
       public XbmcPlayer Player;
       public XbmcVideoPlaylist VideoPlaylist;
       public XbmcAudioPlaylist AudioPlaylist;
       public XbmcPlaylist Playlist;
       public XbmcFiles Files;

        public Xbmc(String xbmcIp, Int32 xbmcPort, String xbmcUser, String xbmcPass)
        {
            XbmcIp = xbmcIp;
            XbmcPort = xbmcPort;
            XbmcUser = xbmcUser;
            XbmcPass = xbmcPass;
            XbmcUri = new Uri("http://" + XbmcIp + ":" + XbmcPort + "/jsonrpc");
            Client = new JsonRpcClient(XbmcUri, XbmcUser, XbmcPass,true);
            AudioPlayer = new XbmcAudioPlayer(Client);
            AudioLibrary = new XbmcAudioLibrary(Client);
            VideoLibrary = new XbmcVideoLibrary(Client);
            Status = new XbmcStatus(Client);
            Control = new XbmcControl(Client);
            XSystem = new XbmcSystem(Client);
            JsonRpc = new XbmcJsonRpc(Client);
            Player = new XbmcPlayer(Client);
            VideoPlaylist = new XbmcVideoPlaylist(Client);
            AudioPlaylist = new XbmcAudioPlaylist(Client);
            Playlist = new XbmcPlaylist(Client);
            Files = new XbmcFiles(Client, XbmcIp, XbmcPort, XbmcUser, XbmcPass);
        }
    }
}
