using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XbmcJson
{
    public class XbmcControl
    {
        private JsonRpcClient Client;

        public XbmcControl(JsonRpcClient client)
        {
            Client = client;
        }

        public int GetVolume()
        {
            return (int)Client.Invoke("XBMC.GetVolume");
        }

        public void SetVolume(int volume)
        {
            if (volume < 0)
                volume = 0;

            if (volume > 100)
                volume = 100;

            Client.Invoke("XBMC.SetVolume", volume);
        }

        public void ToggleMute()
        {
            Client.Invoke("XBMC.ToggleMute");
        }

        public void PlayArtist(int artistId)
        {
            Play(artistId, null, null, null, null, null, null, null, null);
        }

        public void PlayAlbum(int albumId)
        {
            Play(null, albumId, null, null, null, null, null, null, null);
        }

        public void PlaySong(int songId)
        {
            Play(null, null, songId, null, null, null, null, null, null);
        }

        public void PlayMovie(int movieId)
        {
            Play(null, null, null, movieId, null, null, null, null, null);
        }

        public void PlayEpisode(int tvshowId, int seasonId, int episodeId)
        {
            Play(null, null, null, null, tvshowId, seasonId, episodeId, null, null);
        }

        public void PlayFile(string file)
        {
            Play(null, null, null, null, null, null, null, null, file);
        }

        public void PlayPlaylist(string playlist)
        {
            Play(null, null, null, null, null, null, null, playlist, null);
        }

        private void Play(int? artistId, int? albumId, int? songId, int? movieId,  int? tvshowId, int? seasonId, int? episodeId, string playlist, string file)
        {
            var args = new JObject();
            if (artistId != null)
                args.Add(new JProperty("artistid", artistId));
            if (albumId != null)
                args.Add(new JProperty("albumid", albumId));
            if (songId != null)
                args.Add(new JProperty("songid", songId));
            if (playlist != null)
                args.Add(new JProperty("playlist", playlist));
            if (movieId != null)
                args.Add(new JProperty("movieid", movieId));
            if (tvshowId != null && seasonId != null && episodeId != null)
                args.Add(new JProperty("tvshowid", tvshowId));
                args.Add(new JProperty("season", seasonId));
                args.Add(new JProperty("episodeid", episodeId));
            if (file != null)
                args.Add(new JProperty("file", file));
            
            Client.Invoke("XBMC.Play", args);
        }

        public void Quit()
        {
            Client.Invoke("XBMC.Quit");
        }

        public void StartSlideShow(string directory, bool random, bool recursive)
        {
            var args = new JObject();

            args.Add(new JProperty("directory", directory));
            args.Add(new JProperty("random", random));
            args.Add(new JProperty("recursive", recursive));

            Client.Invoke("XBMC.StartSlideShow", args);
        }

        public void Log(string message, string level)
        {
            var args = new JObject();

            args.Add(new JProperty("message", message));
            args.Add(new JProperty("level", level));

            Client.Invoke("XBMC.Log", args);
        }
    }
}
