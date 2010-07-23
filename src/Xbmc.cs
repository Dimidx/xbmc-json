﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;

namespace XbmcJson
{
    public class Xbmc
    {
       
       public Uri XbmcUri;
       public string XbmcIp;
       public Int32 XbmcPort;
       public string XbmcUser;
       public string XbmcPass;
       private JsonRpcClient Client;

       public XbmcAudioLibrary AudioLibrary;
       public XbmcAudioPlayer AudioPlayer;
       public XbmcAudioPlaylist AudioPlaylist;
       public XbmcControl Control;
       public XbmcFiles Files;
       public XbmcJsonRpc JsonRpc;
       public XbmcPicturePlayer PicturePlayer;
       public XbmcPlayer Player;
       public XbmcPlaylist Playlist;
       public XbmcStatus Status;
       public XbmcSystem System_;
       public XbmcVideoLibrary VideoLibrary;
       public XbmcVideoPlayer VideoPlayer;
       public XbmcVideoPlaylist VideoPlaylist;

        public Xbmc(String xbmcIp, Int32 xbmcPort, String xbmcUser, String xbmcPass)
        {
            XbmcIp = xbmcIp;
            XbmcPort = xbmcPort;
            XbmcUser = xbmcUser;
            XbmcPass = xbmcPass;
            XbmcUri = new Uri("http://" + XbmcIp + ":" + XbmcPort + "/jsonrpc");
            Client = new JsonRpcClient(XbmcUri, XbmcUser, XbmcPass,true);

            AudioLibrary = new XbmcAudioLibrary(Client);
            AudioPlayer = new XbmcAudioPlayer(Client);
            AudioPlaylist = new XbmcAudioPlaylist(Client);
            Control = new XbmcControl(Client);
            Files = new XbmcFiles(Client, XbmcIp, XbmcPort, XbmcUser, XbmcPass);
            JsonRpc = new XbmcJsonRpc(Client);
            PicturePlayer = new XbmcPicturePlayer(Client);
            Player = new XbmcPlayer(Client);
            Playlist = new XbmcPlaylist(Client);
            Status = new XbmcStatus(Client);
            System_ = new XbmcSystem(Client);
            VideoLibrary = new XbmcVideoLibrary(Client);
            VideoPlayer = new XbmcVideoPlayer(Client);
            VideoPlaylist = new XbmcVideoPlaylist(Client);
        }
    }
}
