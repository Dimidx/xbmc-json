using xbmc_json_async.Library;
using xbmc_json_async.Player;

namespace xbmc_json_async.System
{
    public class XConnection
    {
        public XAudioLibrary AudioLibrary;
        public XVideoLibrary VideoLibrary;
        public XAudioPlayer AudioPlayer;
        public XVirtualRemote VirtualRemote;

        public XConnection(string ipAddress, int port, string userName, string password)
        {
            var settings = new XSettings(ipAddress, port, userName, password);
            var client = new XClient(settings);
            XHelpers.Settings = settings;
            AudioLibrary = new XAudioLibrary(client);
            VideoLibrary = new XVideoLibrary(client);
            AudioPlayer = new XAudioPlayer(client);
            VirtualRemote = new XVirtualRemote(settings);
        }
    }
}