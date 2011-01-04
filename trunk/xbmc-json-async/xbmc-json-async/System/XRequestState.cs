using System;
using System.Collections.Generic;
using System.Net;

namespace xbmc_json_async.System
{
    public class XRequestState
    {
        internal HttpWebRequest Request;
        internal WebResponse Response;
        internal string JsonRequest;
        internal XClientResponseReceived InternalCallback;
        internal XDataReceived UserCallback;
        internal string ResponseData;
    }
}
