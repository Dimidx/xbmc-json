using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xbmc_json_async.System;
using Newtonsoft.Json.Linq;

namespace xbmc_json_async.Player
{
   public class XPicturePlayer : XPlayer
   {
      public override XPlayerType PlayerType()
      {
         return XPlayerType.PicturePlayer;
      }

      public XPicturePlayer(XClient client)
         : base(client)
      { }

      #region Override functions for methods not available in the PicturePlayer

      public override void BigSkipBackward()
      {
         throw new InvalidOperationException("This method is only available in the Video and Audio players.");
      }

      public override void BigSkipForward()
      {
         throw new InvalidOperationException("This method is only available in the Video and Audio players.");
      }

      public override void SmallSkipBackward()
      {
         throw new InvalidOperationException("This method is only available in the Video and Audio players.");
      }

      public override void SmallSkipForward()
      {
         throw new InvalidOperationException("This method is only available in the Video and Audio players.");
      }

      public override void GetPercentage(XDataReceived userCallback)
      {
         throw new InvalidOperationException("This method is only available in the Video and Audio players.");
      }

      public override void GetTime(XDataReceived userCallback)
      {
         throw new InvalidOperationException("This method is only available in the Video and Audio players.");
      }

      public override void Forward()
      {
         throw new InvalidOperationException("This method is only available in the Video and Audio players.");
      }

      public override void Rewind()
      {
         throw new InvalidOperationException("This method is only available in the Video and Audio players.");
      }

      public override void SeekPercentage(XDataReceived userCallback, double percentage)
      {
         throw new InvalidOperationException("This method is only available in the Video and Audio players.");
      }

      public override void SeekTime(XDataReceived userCallback, int timeInSeconds)
      {
         throw new InvalidOperationException("This method is only available in the Video and Audio players.");
      }

      #endregion

      /// <summary>
      /// In a zoomed view, pans the viewport to the left.
      /// </summary>
      public void MoveLeft()
      {
         Client.GetData(string.Format("{0}.MoveLeft", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// In a zoomed view, pans the viewport to the right.
      /// </summary>
      public void MoveRight()
      {
         Client.GetData(string.Format("{0}.MoveRight", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// In a zoomed view, pans the viewport to up.
      /// </summary>
      public void MoveUp()
      {
         Client.GetData(string.Format("{0}.MoveUp", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// In a zoomed view, pans the viewport to down.
      /// </summary>
      public void MoveDown()
      {
         Client.GetData(string.Format("{0}.MoveDown", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// Zooms the viewport out.
      /// </summary>
      public void ZoomOut()
      {
         Client.GetData(string.Format("{0}.ZoomOut", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// Zooms the viewport in.
      /// </summary>
      public void ZoomIn()
      {
         Client.GetData(string.Format("{0}.ZoomIn", this.PlayerType().ToString()), null, null, null);
      }

      /// <summary>
      /// Zoom to a defined level
      /// </summary>
      /// <param name="zoomLevel">The zoom level as a whole number between 1 and 10.</param>
      public void Zoom(int zoomLevel)
      {
         var args = new JObject { new JProperty("zoomlevel", zoomLevel) };

         Client.GetData(string.Format("{0}.Zoom", this.PlayerType().ToString()), args, null, null);
      }

      /// <summary>
      /// Rotate the picture (clockwise/anticlockwise? documentation unclear)
      /// </summary>
      /// <param name="degrees">Degrees or radians?</param>
      public void Rotate(int degrees)
      {
         var args = new JObject { new JProperty("degrees", degrees) };

         Client.GetData(string.Format("{0}.Zoom", this.PlayerType().ToString()), args, null, null);
      }

   }
}
