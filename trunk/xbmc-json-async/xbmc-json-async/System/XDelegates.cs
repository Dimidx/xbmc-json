using System.Collections.Generic;

namespace xbmc_json_async.System
{
    public delegate void XClientResponseReceived(XRequestState requestSate);
    public delegate void XDataReceived(object data);
    public delegate void XEventReceivedEventHandler(object sender, XEventType type, Dictionary<string, string> parameters);
}