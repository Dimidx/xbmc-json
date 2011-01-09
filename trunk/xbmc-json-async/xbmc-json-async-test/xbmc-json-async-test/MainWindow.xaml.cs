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
        private XConnection _Connection;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            _Connection = new XConnection("192.168.1.105", 8080, "xbmc", "test");
            _Connection.AudioLibrary.GetArtists(null, GetArtistsCallback);
            _Connection.VideoLibrary.GetMovies(null, GetMoviesCallback);
            _Connection.VideoLibrary.GetTvShows(null, GetTvShowsCallback);

            var eventListener = new XEventListener("192.168.1.105", 9090);
            eventListener.OnXEventReceived += new XEventReceivedEventHandler(eventListener_OnXEventReceived);
            eventListener.Connect();
        }

        void eventListener_OnXEventReceived(object sender, XEventType type, Dictionary<string, string> parameters)
        {
           MessageBox.Show("EventListener captured event : " + type.ToString());
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

        private void ButtonHomeClick(object sender, RoutedEventArgs e)
        {
            _Connection.VirtualRemote.SendExec(XVirtualRemote.Home);
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            _Connection.VirtualRemote.SendAction(XVirtualRemote.KeyCode.Back);
        }
    }
}
