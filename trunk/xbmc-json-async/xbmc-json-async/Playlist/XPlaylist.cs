using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xbmc_json_async.System;

namespace xbmc_json_async.Playlist
{
   public abstract class XPlaylist
   {
      public abstract XPlaylistType PlaylistType();

      public XClient Client;

      public XPlaylist(XClient client)
      {
         Client = client;
      }

      public abstract void Play();

      public abstract void SkipPrevious();

      public abstract void SkipNext();

      public abstract void GetItems();

      public abstract void Add();

      public abstract void Clear();

      public void Shuffle()
      {
         Client.GetData(string.Format("{0}.Shuffle", this.PlaylistType().ToString()), null, null, null);
      }

      public void Unshuffle()
      {
         Client.GetData(string.Format("{0}.UnShuffle", this.PlaylistType().ToString()), null, null, null);
      }


   }
}
