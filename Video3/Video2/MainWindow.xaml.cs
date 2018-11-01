using System;
using System.Windows;
using VideoLibrary;
using System.IO;
using System.Threading;

namespace Video2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetVideo(object sender, RoutedEventArgs e)
        {
            DonloadVideo newVideo = new DonloadVideo();
            Thread newGetThread = new Thread(() => newVideo.GetVideo(txtVideo.Text));
            newGetThread.Start();
        }
    }

    public class DonloadVideo
    {
        public void GetVideo(string url)
        {
            using (var service = Client.For(YouTube.Default))
            {
                while (true)
                {
                    String videoID = "https://youtube.com/watch?v=" + url;
                    var video = service.GetVideo(videoID);
                    string folder = GetDefaultFolder();
                    string path = Path.Combine(folder, video.FullName);
                    File.WriteAllBytes(path, video.GetBytes());
                }
            }
        }

        static string GetDefaultFolder()
        {
            var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            return Path.Combine(home, "Downloads");
        }

    }
}
