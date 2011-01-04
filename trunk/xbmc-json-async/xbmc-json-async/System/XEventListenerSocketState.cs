using System.Text;

namespace xbmc_json_async.System
{
    class XEventListenerSocketState
    {
        public const int BufferSize = 1024;
        public byte[] Buffer = new byte[BufferSize];
        public StringBuilder Builder = new StringBuilder();
    }
}
