using System;
using xbmc_json_async.System;

namespace xbmc_json_async.Player
{
   public class XVideoPlayer : XPlayer
   {
      public override XPlayerType PlayerType()
      {
         return XPlayerType.VideoPlayer;
      }

      public XVideoPlayer(XClient client)
         : base(client)
      {  }

      
   }
}
