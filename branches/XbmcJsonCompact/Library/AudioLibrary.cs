using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace XbmcJson
{
	public class XbmcAudioLibrary
	{
		private JsonRpcClient Client;

		public XbmcAudioLibrary(JsonRpcClient client)
		{
			Client = client;
		}

		public List<Artist> GetArtists()
		{
			JObject query = (JObject)Client.Invoke("AudioLibrary.GetArtists");
			List<Artist> list = new List<Artist>();

			if (query["artists"] != null)
			{
				foreach (JObject item in (JArray)query["artists"])
				{
					list.Add(Artist.ArtistFromJsonObject(item));
				}
			}

			return list;
		}

		public List<Album> GetAlbums()
		{
			JObject query = (JObject)Client.Invoke("AudioLibrary.GetAlbums");
			List<Album> list = new List<Album>();

			if (query["albums"] != null)
			{
				foreach (JObject item in (JArray)query["albums"])
				{
					list.Add(Album.AlbumFromJsonObject(item));
				}
			}
			return list;
		}

		public List<Album> GetAlbumsByArtist(int artistId)
		{
			var args = new JObject();
			args.Add(new JProperty("artistid", artistId));

			JObject query = (JObject)Client.Invoke("AudioLibrary.GetAlbums", args);
			List<Album> list = new List<Album>();

			if (query["albums"] != null)
			{
				foreach (JObject item in (JArray)query["albums"])
				{
					list.Add(Album.AlbumFromJsonObject(item));
				}
			}

			return list;
		}

		public List<Album> GetAlbumsByGenre(string genre)
		{
			var args = new JObject();
			args.Add(new JProperty("genre", genre));

			JObject query = (JObject)Client.Invoke("AudioLibrary.GetAlbums", args);
			List<Album> list = new List<Album>();

			if (query["albums"] != null)
			{
				foreach (JObject item in (JArray)query["albums"])
				{
					list.Add(Album.AlbumFromJsonObject(item));
				}
			}

			return list;
		}

	   public List<Song> GetSongs()
	   {
			JObject query = (JObject)Client.Invoke("AudioLibrary.GetSongs");
			List<Song> list = new List<Song>();

			if (query["songs"] != null)
			{
			   foreach (JObject item in (JArray)query["songs"])
			   {
				   list.Add(Song.SongFromJsonObject(item));
			   }
			}

			return list;
	   }

	   public List<Song> GetSongsByAlbum(int albumId)
		{
			var args = new JObject();
			args.Add(new JProperty("albumid", albumId));

			JObject query = (JObject)Client.Invoke("AudioLibrary.GetSongs", args);
			List<Song> list = new List<Song>();

            if (query["songs"] != null)
            {
                foreach (JObject item in (JArray)query["songs"])
                {
                    list.Add(Song.SongFromJsonObject(item));
                }
            }

			return list;
		}

	   public List<Song> GetSongsByArtist(int artistId)
		{
			var args = new JObject();
			args.Add(new JProperty("artistid", artistId));

			JObject query = (JObject)Client.Invoke("AudioLibrary.GetSongs", args);
			List<Song> list = new List<Song>();

            if (query["songs"] != null)
            {
                foreach (JObject item in (JArray)query["songs"])
                {
                    list.Add(Song.SongFromJsonObject(item));
                }
            }

			return list;
		}

	   public List<Song> GetSongsByGenre(string genre)
		{
			var args = new JObject();
			args.Add(new JProperty("genre", genre));

			JObject query = (JObject)Client.Invoke("AudioLibrary.GetSongs", args);
			List<Song> list = new List<Song>();

            if (query["songs"] != null)
            {
                foreach (JObject item in (JArray)query["songs"])
                {
                    list.Add(Song.SongFromJsonObject(item));
                }
            }

			return list;
		}

		public void ScanForContent()
		{
			Client.Invoke("AudioLibrary.ScanForContent");
		}
	}
}