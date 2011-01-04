using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json.Linq;

namespace xbmc_json_async.System
{
    public class XEventListener : IDisposable
    {
        private readonly string _IpAddress;
        private readonly int _Port;
        private readonly Socket _ClientSocket;
        
        public event EventHandler PlaybackStarted;
        public event EventHandler PlaybackSpeedChanged;
        public event EventHandler PlaybackSeek;
        public event EventHandler ConnectionFailed;
        public event EventHandler ConnectionSuccessful;

        public XEventListener(string ipAddress, int port)
        {
            _IpAddress = ipAddress;
            _Port = port;
            _ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
        }
        
        public void Connect()
        {
            var endPoint = new IPEndPoint(IPAddress.Parse(_IpAddress), _Port);

            try
            {
                _ClientSocket.BeginConnect(endPoint, Connected, new XEventListenerSocketState());
            }
            catch (SocketException)
            {
                if (ConnectionFailed != null)
                    ConnectionFailed(this, null);
            } 
        }

        private void Connected(IAsyncResult asyncResult)
        {
            var socketState = asyncResult.AsyncState as XEventListenerSocketState;

            if (socketState != null)
            {
                _ClientSocket.EndConnect(asyncResult);

                if (ConnectionSuccessful != null)
                    ConnectionSuccessful(this, null);

                _ClientSocket.BeginReceive(socketState.Buffer, 0, XEventListenerSocketState.BufferSize, SocketFlags.None,
                                           ReceivedData, socketState);
            }
        }

        void ReceivedData(IAsyncResult asyncResult)
        {
            var socketState = asyncResult.AsyncState as XEventListenerSocketState;

            if (socketState != null)
            {
                var receivedDataLength = _ClientSocket.EndReceive(asyncResult);
                var receivedDataJson = Encoding.UTF8.GetString(socketState.Buffer, 0, receivedDataLength);

                socketState.Builder.Append(receivedDataJson);

                // Did we receive a full announcement in this buffer?
                if(FullAnnouncementReceived(socketState.Builder.ToString()))
                {
                    // Yes - Parse the announcement and begin listening for new announcements with a fresh state object
                    ParseAnnouncement(socketState.Builder.ToString());

                    var freshSocketState = new XEventListenerSocketState();

                    _ClientSocket.BeginReceive(freshSocketState.Buffer, 0, XEventListenerSocketState.BufferSize, SocketFlags.None,
                           ReceivedData, freshSocketState);
                }
                else
                {
                    // No - Begin listening for remainder of announcement using same socket state
                    _ClientSocket.BeginReceive(socketState.Buffer, 0, XEventListenerSocketState.BufferSize, SocketFlags.None,
                           ReceivedData, socketState);
                }
            }

            // TODO: What do we do if we receive a full announcement as well as the beginning of a second announcement
        }

        static bool FullAnnouncementReceived(string announcementJson)
        {
            // If we cannot parse the json to a valid jObject then it is incomplete
            try
            {
                var jObject = JObject.Parse(announcementJson);
            }
            catch (Exception exception)
            {
                return false;
            }

            return true;
        }

        void ParseAnnouncement(string jsonannouncement)
        {
            var jObject = JObject.Parse(jsonannouncement);

            if(jObject["method"] != null)
            {
                if((string)jObject["method"] == "Announcement")
                {
                    var message = (string) jObject["params"]["message"];

                    switch (message)
                    {
                        case "PlaybackSeek":
                            if (PlaybackSeek != null)
                                PlaybackSeek(this, null);
                            break;

                        case "PlaybackStarted":
                            if (PlaybackStarted != null)
                                PlaybackStarted(this, null);
                            break;

                        case "PlaybackSpeedChanged":
                            if (PlaybackSpeedChanged != null)
                                PlaybackSpeedChanged(this, null);
                            break;
                    }
                }
            }
        }

        public void Dispose()
        {
            _ClientSocket.Disconnect(false);
            _ClientSocket.Dispose();
        }
    }
}
