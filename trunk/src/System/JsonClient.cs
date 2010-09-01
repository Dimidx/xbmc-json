using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XbmcJson
{
    public class JsonRpcClient : WebRequest
    {
        private int _id;
        private Uri ClientUri;
        private bool DebugEnabled = false;
        public string XbmcUser;
        public string XbmcPass;

        public JsonRpcClient(Uri uri, string xbmcUser, string xbmcPass)
        {
            ClientUri = uri;
            XbmcUser = xbmcUser;
            XbmcPass = xbmcPass;
        }

        public JsonRpcClient(Uri uri, string xbmcUser, string xbmcPass, bool debugEnabled)
        {
            ClientUri = uri;
            XbmcUser = xbmcUser;
            XbmcPass = xbmcPass;
            DebugEnabled = debugEnabled;
        }

        public object Invoke(string method)
        {
            return Invoke(method, null, null);
        }

        public object Invoke(string method, object[] args)
        {
            return Invoke(method, args, null);
        }

        public object Invoke(string method, object args)
        {
            return Invoke(method, args, null);
        }

        public object Invoke(string method, IDictionary args)
        {
            return Invoke(method, args, null);
        }

        public virtual object Invoke(string method, object args, int? timeout)
        {
            if (method == null)
                throw new ArgumentNullException("method");
            if (method.Length == 0)
                throw new ArgumentException(null, "method");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ClientUri);
            request.AllowWriteStreamBuffering = true;
            request.Credentials = new System.Net.NetworkCredential(XbmcUser, XbmcPass);
            request.ContentType = "application/json";
            request.Method = "POST";
            request.KeepAlive = false;

            request.Timeout = 5000;
            using (var stream = request.GetRequestStream())
            {
                using (var writer = new StreamWriter(stream, Encoding.ASCII))
                {
                    if (_id > 100000)
                        _id = 0;

                    var call = new JObject();
                    call.Add(new JProperty("jsonrpc", "2.0"));
                    call.Add(new JProperty("method", method));
                    if (args != null)
                        call.Add(new JProperty("params", args));
                    call.Add(new JProperty("id", ++_id));

                    if (DebugEnabled)
                        DebugLog.WriteLog("Invoke: " + call.ToString());

                    writer.Write(call.ToString());
                }
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (var stream2 = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(stream2, Encoding.UTF8))
                            {
                                object res = OnResponse(reader);
                                if (DebugEnabled)
                                    DebugLog.WriteLog("Response: " + res.ToString());
                                return res;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugLog.WriteLog("Exception: " + ex.Message);
                    DebugLog.WriteLog(ex.StackTrace);
                    return (object)null;
                }
            }
        }

        private object OnResponse(StreamReader reader)
        {
            var JObjectResponse = JObject.Parse(reader.ReadToEnd());
            var members = JObjectResponse.Properties();

            foreach (var member in members)
            {
                if (string.CompareOrdinal(member.Name, "error") == 0)
                {
                    var errorObject = (JObject)member.Value;
                    if (errorObject != null)
                        OnError(errorObject);
                }
                else if (string.CompareOrdinal(member.Name, "result") == 0)
                {
                    if (member.Value.HasValues == true)
                    {
                        return (JObject)member.Value;
                    }
                    else
                    {
                        if(member.Value.Type == JTokenType.Integer)
                            return (int)member.Value.Value<JValue>();
                        else if(member.Value.Type == JTokenType.Float)
                            return (float)member.Value.Value<JValue>();
                        else
                            return (string)member.Value.Value<JValue>();  
                    }
                }
            }
            throw new Exception("Invalid JSON-RPC response. It contains neither a result nor error.");
        }

        protected virtual void OnError(JObject errorValue)
        {
            if (errorValue != null)
                throw new Exception(errorValue["code"].Value<JValue>().Value.ToString() + ": " + errorValue["message"].Value<JValue>().Value.ToString());
            else
                throw new Exception("Unknown error occured");
        }
    }
}