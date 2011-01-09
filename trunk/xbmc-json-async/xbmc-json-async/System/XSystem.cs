using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using xbmc_json_async.Player;

namespace xbmc_json_async.System
{
   public class XSystem
   {

      private XClient Client;

      public XSystem(XClient client)
      {
         Client = client;
      }

      /// <summary>
      /// Gets the status (active/inactive) of the Video, Audio and Picture players.
      /// 
      /// Only one player can be active at one time, so this method will return a XPlayerType.
      /// </summary>
      public XPlayerType GetActivePlayers()
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// Shuts down the system.
      /// </summary>
      public void Shutdown()
      {
         Client.GetData("XBMC.Shutdown", null, null, null);
      }

      /// <summary>
      /// Suspends the system.
      /// </summary>
      public void Suspend()
      {
         Client.GetData("XBMC.Suspend", null, null, null);
      }

      /// <summary>
      /// Hibernates the system.
      /// </summary>
      public void Hibernate()
      {
         Client.GetData("XBMC.Hibernate", null, null, null);
      }

      /// <summary>
      /// Reboots the system.
      /// </summary>
      public void Reboot()
      {
         Client.GetData("XBMC.Reboot", null, null, null);
      }

      /// <summary>
      /// Get info labels about the system.
      /// </summary>
      public void GetInfoLabels()
      {
         //TODO : implement
         throw new NotImplementedException();
      }

      /// <summary>
      /// Get info booleans about the system.
      /// 
      /// Available field names: 
      ///    system.canshutdown 
      ///    system.canpowerdown 
      ///    system.cansuspend 
      ///    system.canhibernate 
      ///    system.canreboot
      /// </summary>
      public void GetInfoBooleans()
      {
         //TODO : implement
         throw new NotImplementedException();
      }

      /// <summary>
      /// Gets the current volume.
      /// </summary>
      /// <param name="userCallback"></param>
      public virtual void GetVolume(XDataReceived userCallback)
      {
         Client.GetData("XBMC.GetVolume", null, GetVolumeCallback, userCallback);
      }

      /// <summary>
      /// Callback for GetVolume.
      /// </summary>
      /// <param name="requestState"></param>
      private void GetVolumeCallback(XRequestState requestState)
      {
         var query = JObject.Parse(requestState.ResponseData);

         if (query["error"] == null)
         {
            var result = (JObject)query["result"];

            var currentVolume = Convert.ToDouble(result["result"].Value<JValue>().Value);

            if (requestState.UserCallback != null)
               requestState.UserCallback(currentVolume);
         }
      }

      /// <summary>
      /// Sets the current volume.
      /// </summary>
      /// <param name="volume"></param>
      public void SetVolume(double volume)
      {
         var args = new JObject { new JProperty("volume", volume) };

         Client.GetData("XBMC.SetVolume", args, null, null);
      }

      /// <summary>
      /// Toggle volume mute on/off.
      /// 
      /// (is it necessary to receive the return value here?)
      /// </summary>
      public void ToggleMute()
      {
         Client.GetData("XBMC.ToggleMute", null, null, null);
      }

      /// <summary>
      /// Starts playback.
      /// 
      /// (dunno what makes this different from playlist.play)
      /// </summary>
      public void Play()
      {
         Client.GetData("XBMC.Play", null, null, null);
      }

      /// <summary>
      /// Starts a slideshow.
      /// </summary>
      public void StartSlideshow()
      {
         throw new NotImplementedException();
      }

      /// <summary>
      /// Logs a line in xbmc.log
      /// </summary>
      /// <param name="message"></param>
      public void Log(string message, XLogLevel level)
      {
         var args = new JObject { new JProperty("volume", message), new JProperty("level", level.ToString()) };

         Client.GetData("XBMC.Log", args, null, null);
      }

      /// <summary>
      /// Exits XBMC.
      /// </summary>
      public void Quit()
      {
         Client.GetData("XBMC.Quit", null, null, null);
      }
   }
}
