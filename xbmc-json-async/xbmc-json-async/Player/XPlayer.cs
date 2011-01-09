using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xbmc_json_async.System;
using Newtonsoft.Json.Linq;

namespace xbmc_json_async.Player
{
   /// <summary>
   /// XPlayer
   /// 
   /// Abstract class that contains all the common methods between the player types specified in XPlayerTypes.
   /// 
   /// </summary>
   public abstract class XPlayer
   {
      public XClient Client;

      public XPlayer(XClient client)
      {
         Client = client;
      }

      /// <summary>
      /// The client type, as specified in XPlayerTypes.
      /// </summary>
      /// <returns></returns>
      public abstract XPlayerType PlayerType();

      /// <summary>
      /// Skips to the previous item in the playlist.
      /// </summary>
      public void SkipPrevious()
      {
         Client.GetData(string.Format("{0}.SkipPrevious", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// Skips to the next item in the playlist.
      /// </summary>
      public void SkipNext()
      {
         Client.GetData(string.Format("{0}.SkipNext", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// Stops playback.
      /// </summary>
      public void Stop()
      {
         Client.GetData(string.Format("{0}.Stop", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// Pauses/resumes playback.
      /// </summary>
      public void PlayPause()
      {
         Client.GetData(string.Format("{0}.PlayPause", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// Skips backward in the current track by a big amount.
      /// </summary>
      public virtual void BigSkipBackward()
      {
         Client.GetData(string.Format("{0}.BigSkipBackward", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// Skips forward in the current track by a big amount.
      /// </summary>
      public virtual void BigSkipForward()
      {
         Client.GetData(string.Format("{0}.BigSkipForward", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// Skips backward in the current track by a small amount.
      /// </summary>
      public virtual void SmallSkipBackward()
      {
         Client.GetData(string.Format("{0}.SmallSkipBackward", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// Skips forward in the current track by a small amount.
      /// </summary>
      public virtual void SmallSkipForward()
      {
         Client.GetData(string.Format("{0}.SmallSkipForward", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// Rewind current track.
      /// </summary>
      public virtual void Rewind()
      {
         Client.GetData(string.Format("{0}.Rewind", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// Play current track forwards (Fast Forwards? unknown).
      /// </summary>
      public virtual void Forward()
      {
         Client.GetData(string.Format("{0}.Forward", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// Gets the state of the audio player, including time information, to the millisecond.
      /// </summary>
      /// <param name="userCallback"></param>
      public virtual void GetTime(XDataReceived userCallback)
      {
         Client.GetData(string.Format("{0}.Forward", this.PlayerType().ToString()), null, GetTimeCallback, userCallback);
      }
      
      /// <summary>
      /// Callback for GetTime
      /// </summary>
      /// <param name="requestState"></param>
      private void GetTimeCallback(XRequestState requestState)
      {
         string timeFormatted = "";

         var query = JObject.Parse(requestState.ResponseData);
         

         if (query["error"] == null)
         {
            var result = (JObject)query["result"];

            var timePlayed = Convert.ToInt32(result["time"].Value<JValue>().Value);
            var timeTotal = Convert.ToInt32(result["total"].Value<JValue>().Value);

            timeFormatted = String.Format("{0}:{1} / {2}:{3}", String.Format("{0:00}", (timePlayed / 60)), String.Format("{0:00}", (timePlayed % 60)), String.Format("{0:00}", (timeTotal / 60)), String.Format("{0:00}", (timeTotal % 60)));
         }

         if (requestState.UserCallback != null)
            requestState.UserCallback(timeFormatted);
      }

      /// <summary>
      /// Gets a percentage, of what is not obviously documented, presumably Position/Duration*100.
      /// </summary>
      /// <param name="userCallback"></param>
      public virtual void GetPercentage(XDataReceived userCallback)
      {        
         Client.GetData(string.Format("{0}.GetPercentage", this.PlayerType().ToString()), null, GetPercentageCallback, userCallback);
      }

      /// <summary>
      /// Callback for GetPercentage.
      /// </summary>
      /// <param name="requestState"></param>
      private void GetPercentageCallback(XRequestState requestState)
      {
         double percentagePlayed = 0;
         var query = JObject.Parse(requestState.ResponseData);
         

         if (query["error"] == null)
         {
            var result = (JObject)query["result"];
            percentagePlayed = Convert.ToDouble(result["Percentage"].Value<JValue>().Value);
         }

         if (requestState.UserCallback != null)
            requestState.UserCallback(percentagePlayed);
      }

      /// <summary>
      /// Seek to a position in the track defined by position in seconds.
      /// </summary>
      /// <param name="userCallback"></param>
      /// <param name="timeInSeconds"></param>
      public virtual void SeekTime(XDataReceived userCallback, int timeInSeconds)
      {
         var args = new JObject { new JProperty("time", timeInSeconds) };

         Client.GetData(string.Format("{0}.SeekTime", this.PlayerType().ToString()), args, SeekTimeCallback, userCallback);
      }

      /// <summary>
      /// Callback for SeekTime.
      /// </summary>
      /// <param name="requestState"></param>
      private void SeekTimeCallback(XRequestState requestState)
      {
         var query = JObject.Parse(requestState.ResponseData);

         if (query["error"] == null)
         {
            if (requestState.UserCallback != null)
               requestState.UserCallback(true);
         }
         else
         {
            if (requestState.UserCallback != null)
               requestState.UserCallback(false);
         }
      }

      /// <summary>
      /// Seek to a position in the track defined by a percentage (of total duration?).
      /// </summary>
      /// <param name="userCallback"></param>
      /// <param name="percentage"></param>
      public virtual void SeekPercentage(XDataReceived userCallback, double percentage)
      {
         var args = new JObject { new JProperty("percentage", percentage) };

         Client.GetData(string.Format("{0}.SeekPercentage", this.PlayerType().ToString()), args, SeekPercentageCallback, userCallback);
      }

      /// <summary>
      /// Callback for SeekPercentage.
      /// </summary>
      /// <param name="requestState"></param>
      private void SeekPercentageCallback(XRequestState requestState)
      {
         var query = JObject.Parse(requestState.ResponseData);

         if (query["error"] == null)
         {
            if (requestState.UserCallback != null)
               requestState.UserCallback(true);
         }
         else
         {
            if (requestState.UserCallback != null)
               requestState.UserCallback(false);
         }
      }

   }
}
