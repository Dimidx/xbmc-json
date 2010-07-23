#region License, Terms and Conditions
//
// Jayrock - A JSON-RPC implementation for the Microsoft .NET Framework
// Written by Atif Aziz (www.raboof.com)
// Copyright (c) Atif Aziz. All rights reserved.
//
// This library is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free
// Software Foundation; either version 2.1 of the License, or (at your option)
// any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
// details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this library; if not, write to the Free Software Foundation, Inc.,
// 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 
//
#endregion

using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Web.Services.Protocols;
using Jayrock.Json;
using Jayrock.Json.Conversion;

namespace XbmcJson
{
    public class JsonRpcClient : HttpWebClientProtocol
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
            return Invoke(AnyType.Value, method);
        }

        public object Invoke(Type returnType, string method)
        {
            return Invoke(returnType, method, (object)null);
        }

        public object Invoke(string method, object[] args)
        {
            return Invoke(AnyType.Value, method, args);
        }

        public object Invoke(string method, object args)
        {
            return Invoke(AnyType.Value, method, args);
        }

        public object Invoke(Type returnType, string method, object[] args)
        {
            return Invoke(returnType, method, (object)args);
        }

        public object InvokeVargs(string method, params object[] args)
        {
            return Invoke(method, args);
        }

        public object InvokeVargs(Type returnType, string method, params object[] args)
        {
            return Invoke(returnType, method, args);
        }

        public object Invoke(string method, IDictionary args)
        {
            return Invoke(AnyType.Value, method, args);
        }

        public object Invoke(Type returnType, string method, IDictionary args)
        {
            return Invoke(returnType, method, (object)args);
        }

        public virtual object Invoke(Type returnType, string method, object args)
        {
            if (method == null)
                throw new ArgumentNullException("method");
            if (method.Length == 0)
                throw new ArgumentException(null, "method");
            if (returnType == null)
                throw new ArgumentNullException("returnType");

            var request = GetWebRequest(ClientUri);
            request.Credentials = new System.Net.NetworkCredential(XbmcUser, XbmcPass);
            request.Method = "POST";
            using (var stream = request.GetRequestStream())
            using (var writer = new StreamWriter(stream, Encoding.ASCII))
            {
                if (_id > 100000)
                    _id = 0;

                var call = new JsonObject();
                call["jsonrpc"] = "2.0";
                call["method"] = method;
                if (args != null)
                    call["params"] = args;
                call["id"] = ++_id;

                if(DebugEnabled)
                    DebugLogger.WriteLog("Invoke: " + call.ToString());

                JsonConvert.Export(call, writer);
            }
            using (var response = GetWebResponse(request))
            using (var stream2 = response.GetResponseStream())
            using (var reader = new StreamReader(stream2, Encoding.UTF8))
                return OnResponse(JsonText.CreateReader(reader), returnType);
        }

        private object OnResponse(JsonReader reader, Type returnType)
        {
            var members = JsonBuffer.From(reader).GetMembersArray();
            foreach (var member in members)
            {
                if (string.CompareOrdinal(member.Name, "error") == 0)
                {
                    var errorObject = JsonConvert.Import(member.Buffer.CreateReader());
                    if (errorObject != null)
                        OnError(errorObject);
                }
                else if (string.CompareOrdinal(member.Name, "result") == 0)
                {
                    return returnType != typeof(JsonBuffer)
                               ? JsonConvert.Import(returnType, member.Buffer.CreateReader())
                               : member.Buffer;
                }
            }
            throw new Exception("Invalid JSON-RPC response. It contains neither a result nor error.");
        }

        protected virtual void OnError(object errorValue)
        {
            var error = errorValue as IDictionary;
            if (error != null)
                throw new Exception(error["message"] as string);
            throw new Exception(errorValue as string);
        }
    }
}