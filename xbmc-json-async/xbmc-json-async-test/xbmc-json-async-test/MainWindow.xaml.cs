using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using xbmc_json_async.Media;
using xbmc_json_async.System;

namespace XBMC_Remote
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var connection = new XConnection("192.168.1.30", 8080, "xbmc", "");
            connection.AudioLibrary.GetArtists(null, GetArtistsCallback);
            connection.VideoLibrary.GetMovies(null, GetMoviesCallback);
            connection.VideoLibrary.GetTvShows(null, GetTvShowsCallback);
        }

        private void GetArtistsCallback(object responseData)
        {
            var artists = responseData as List<Artist>;

            Dispatcher.Invoke(DispatcherPriority.Normal,
                       new Action(
                           delegate()
                           {
                               ListBoxMusic.ItemsSource = artists;
                           }
                       )
                 );
        }

        private void GetMoviesCallback(object responseData)
        {
            var movies = responseData as List<Movie>;

            Dispatcher.Invoke(DispatcherPriority.Normal,
                       new Action(
                           delegate()
                           {
                               ListBoxMovies.ItemsSource = movies;
                           }
                       )
                 );
        }

        private void GetTvShowsCallback(object responseData)
        {
            var shows = responseData as List<TvShow>;

            Dispatcher.Invoke(DispatcherPriority.Normal,
                       new Action(
                           delegate()
                           {
                               TreeViewTvShows.ItemsSource = shows;
                           }
                       )
                 );
        }
    }
}
