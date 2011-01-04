using System;
using Newtonsoft.Json.Linq;
using xbmc_json_async.System;

namespace xbmc_json_async.Player
{
    public class XAudioPlayer
    {
        private readonly XClient _Client;

        public XAudioPlayer(XClient client)
        {
            _Client = client;
        }

        private void GetTime(XDataReceived userCallback)
        {
            _Client.GetData("AudioPlayer.GetTime", null, GetTimeCallback, userCallback);
        }

        private void GetTimeCallback(XRequestState requestState)
        {
            string timeFormatted = "";

            var query = JObject.Parse(requestState.ResponseData);
            var result = (JObject)query["result"];

            if (query["error"] == null)
            {
                var timePlayed = Convert.ToInt32(result["time"].Value<JValue>().Value);
                var timeTotal = Convert.ToInt32(result["total"].Value<JValue>().Value);

                timeFormatted = String.Format("{0:00}", (timePlayed / 60)) + ":" + String.Format("{0:00}", (timePlayed % 60)) + " / " + String.Format("{0:00}", (timeTotal / 60)) + ":" + String.Format("{0:00}", (timeTotal % 60));
            }

            if (requestState.UserCallback != null)
                requestState.UserCallback(timeFormatted);
        }

        public void SkipPrevious()
        {
            _Client.GetData("AudioPlayer.SkipPrevious", null, null, null);
        }

        public void SkipNext()
        {
            _Client.GetData("AudioPlayer.SkipNext", null, null, null);
        }

        public void BigSkipBackward()
        {
            _Client.GetData("AudioPlayer.BigSkipBackward", null, null, null);
        }

        public void BigSkipForward()
        {
            _Client.GetData("AudioPlayer.BigSkipForward", null, null, null);
        }

        public void SmallSkipBackward()
        {
            _Client.GetData("AudioPlayer.SmallSkipBackward", null, null, null);
        }

        public void SmallSkipForward()
        {
            _Client.GetData("AudioPlayer.SmallSkipForward", null, null, null);
        }

        public void Rewind()
        {
            _Client.GetData("AudioPlayer.Rewind", null, null, null);
        }

        public void Forward()
        {
            _Client.GetData("AudioPlayer.Forward", null, null, null);
        }
    }
}