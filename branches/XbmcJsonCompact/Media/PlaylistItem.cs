using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
﻿using System; 
  
 namespace XbmcJson 
 { 
     public class PlaylistItem 
     { 
         public string File, Label, Thumbnail; 
  
         public PlaylistItem(string file, string label, string thumbnail) 
         { 
             File = file; 
             Label = label; 
             Thumbnail = thumbnail; 
         } 
  
         public static PlaylistItem PlaylistItemFromJsonObject(JObject item) 
         {
             PlaylistItem e = new PlaylistItem(
                 item["file"].Value<JValue>().Value.ToString(), 
                 item["label"].Value<JValue>().Value.ToString(), 
                 (item["thumbnail"] != null) ? item["thumbnail"].Value<JValue>().Value.ToString() : ""); 
             return e; 
         } 
     } 
 } 