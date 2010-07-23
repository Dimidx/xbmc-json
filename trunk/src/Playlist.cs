using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;

namespace XbmcJson
{
    public class XbmcPlaylist
    {
        /*
Playlist.Create	true	ReadData	Creates a virtual playlist from a given one from a file
Playlist.Destroy	true	ReadData	Destroys a virtual playlist
Playlist.GetItems	true	ReadData	Retrieve items in the playlist. Parameter example {"playlist": "music" }. playlist optional.
Playlist.Add	true	ControlPlayback	Add items to the playlist. Parameter example {"playlist": "music", "file": "/foo/bar.mp3" }. playlist optional.
Playlist.Remove	true	ControlPlayback	Remove items in the playlist. Parameter example {"playlist": "music", "item": 0 }. playlist optional.
Playlist.Swap	true	ControlPlayback	Swap items in the playlist. Parameter example {"playlist": "music", "item1": 0, "item2": 1 }. playlist optional.
Playlist.Shuffle	true	ControlPlayback	Shuffle playlist       
      */
        private JsonRpcClient Client;

        public XbmcPlaylist(JsonRpcClient client)
        {
            Client = client;
        }

        public void Create()
        {
            Client.Invoke("Playlist.Create");
        }

        public void Destroy()
        {
            Client.Invoke("Playlist.Destroy");
        }

        public JsonObject GetItems(string playlistName)
        {
            var args = new JsonObject();

            args["playlist"] = playlistName;
            return (JsonObject)Client.Invoke("Playlist.GetItems", args);
        }

        public void AddByFile(string playlistName, string playlistFile)
        {
            var args = new JsonObject();

            args["playlist"] = playlistName;
            args["file"] = playlistFile;

            Client.Invoke("Playlist.Add", args);
        }

        public void AddBySong(string playlistName, int songId)
        {
            var args = new JsonObject();

            args["playlist"] = playlistName;
            args["songid"] = songId;

            Client.Invoke("Playlist.Add", args);
        }

        public void AddByArtist(string playlistName, int artistId)
        {
            var args = new JsonObject();

            args["playlist"] = playlistName;
            args["artistid"] = artistId;

            Client.Invoke("Playlist.Add", args);
        }

        public void AddByAlbum(string playlistName, int albumId)
        {
            var args = new JsonObject();

            args["playlist"] = playlistName;
            args["albumid"] = albumId;

            Client.Invoke("Playlist.Add", args);
        }

        public void Remove(string playlistName, int itemIndex)
        {
            var args = new JsonObject();

            args["playlist"] = playlistName;
            args["item"] = itemIndex;

            Client.Invoke("Playlist.Remove", args);
        }
    }
}
