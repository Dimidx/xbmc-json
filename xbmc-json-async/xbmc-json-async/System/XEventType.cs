using System;

namespace xbmc_json_async.System
{
   public enum XEventType
   {
      PlaybackStarted,
      PlaybackSpeedChanged,
      PlaybackSeek,
      PlaybackStopped,
      PlaybackPaused,
      PlaybackResumed,
      ConnectionFailed,
      ConnectionSuccessful
   }
}
