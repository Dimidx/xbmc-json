using System;
using System.Net;

namespace xbmc_json_async.System
{
    public class XVirtualRemote
    {
        private readonly XSettings _Settings;

        public XVirtualRemote(XSettings settings)
        {
            _Settings = settings;
        }

        public enum KeyCode
        {
            Up = 3,
            Down = 4,
            Left = 1,
            Right = 2,
            Back = 10,
            Ok = 7
        }

        public static string Home = "ActivateWindow(Home)";

        public void SendKey(KeyCode key)
        {
            var temp = _Settings.BaseAddress.ToString();
            temp = temp + "xbmcCmds/xbmcHttp?command=SendKey(" + (int)key + ")";
            var keyUri = new Uri(temp);   
            var request = new WebClient
                              {
                                  Credentials = new NetworkCredential(_Settings.UserName, _Settings.Password)
                              };
            request.DownloadStringAsync(keyUri);
        }

        public void SendAction(KeyCode key)
        {
            var temp = _Settings.BaseAddress.ToString();
            temp = temp + "xbmcCmds/xbmcHttp?command=Action(" + (int)key + ")";
            var keyUri = new Uri(temp);
            var request = new WebClient
                              {
                                  Credentials = new NetworkCredential(_Settings.UserName, _Settings.Password)
                              };
            request.DownloadStringAsync(keyUri);
        }

        public void SendExec(string command)
        {
            var temp = _Settings.BaseAddress.ToString();
            temp = temp + "xbmcCmds/xbmcHttp?command=ExecBuiltIn(" + command + ")";
            var keyUri = new Uri(temp);
            var request = new WebClient
                              {
                                  Credentials = new NetworkCredential(_Settings.UserName, _Settings.Password)
                              };
            request.DownloadStringAsync(keyUri);
        }
    }
}