using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace xbmc_json_async.System
{
    public class XClient
    {
        // TODO: Add connection timeout
        // TODO: Exception handling 

        readonly XSettings _Settings;

        public XClient(XSettings settings)
        {
            _Settings = settings;
        }

        public void GetData(string method, object args, XClientResponseReceived internalCallback, XDataReceived userCallback)
        {
            var requestState = new XRequestState
                                   {
                                       InternalCallback = internalCallback,
                                       UserCallback = userCallback,
                                       JsonRequest = BuildJsonPost(method, args),
                                       Request = (HttpWebRequest) WebRequest.Create(_Settings.XJsonInterfaceAddress)
                                   };

            requestState.Request.Credentials = new NetworkCredential(_Settings.UserName, _Settings.Password);
            requestState.Request.ContentType = "application/json";
            requestState.Request.Method = "POST";
            requestState.Request.BeginGetRequestStream(ResponseStreamReceived, requestState);
        }

        static void ResponseStreamReceived(IAsyncResult asyncResult)
        {
            var requestState = (XRequestState)asyncResult.AsyncState;
            var postStream = requestState.Request.EndGetRequestStream(asyncResult);
            byte[] postData = Encoding.UTF8.GetBytes(requestState.JsonRequest);
            postStream.Write(postData, 0, postData.Length);
            postStream.Dispose();
            requestState.Request.BeginGetResponse(ResponseReceived, requestState);
        }

        static void ResponseReceived(IAsyncResult asyncResult)
        {
            var requestState = (XRequestState)asyncResult.AsyncState;
            requestState.Response = requestState.Request.EndGetResponse(asyncResult);
            var responseStream = requestState.Response.GetResponseStream();

            if (responseStream != null)
            {
                var streamReader = new StreamReader(responseStream);
                requestState.ResponseData = streamReader.ReadToEnd();
                responseStream.Dispose();
                streamReader.Dispose();
            }

            requestState.Response.Close();
            requestState.JsonRequest = null;

            if (requestState.InternalCallback != null)
                requestState.InternalCallback(requestState);
        }

        static string BuildJsonPost(string method, object args)
        {
            var jsonPost = new JObject {new JProperty("jsonrpc", "2.0"), new JProperty("method", method)};
            if (args != null)
                jsonPost.Add(new JProperty("params", args));

            // TODO: Is there any value in tracking unique id's? 
            jsonPost.Add(new JProperty("id", 1));

            return jsonPost.ToString();
        }
    }
}