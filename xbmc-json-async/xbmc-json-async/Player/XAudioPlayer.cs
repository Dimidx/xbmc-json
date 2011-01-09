using System;
using xbmc_json_async.System;

namespace xbmc_json_async.Player
{
   public class XAudioPlayer : XPlayer
   {
      public override XPlayerType PlayerType()
      {
         return XPlayerType.VideoPlayer;
      }

      public XAudioPlayer(XClient client)
         : base(client)
      { }


   }
}
