using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VideoLibrary;

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

        private void btnDownload(object sender, RoutedEventArgs e)
        {
            using (var service = Client.For(YouTube.Default))
            {
                string id = txtInput.ToString();
                string path;
                var video = service.GetVideo(id);

                if(id.Substring(0,5).Equals("https"))
                { 
                    video = service.GetVideo(id);
                }
                else
                {
                    video = service.GetVideo("https://youtube.com/watch?v=" + id);
                }

                var result = MessageBox.Show("Video Downloaded, Would you like to save it to your Downloads?","Finished!", MessageBoxButton.YesNoCancel);
                    

                if(result == MessageBoxResult.Yes)
                {
                    path = System.IO.Path.Combine(GetDefaultFolder(), video.FullName);
                    File.WriteAllBytes(path, video.GetBytes());
                }
                else
                {
                    MessageBox.Show("Well too bad, thats where its going");
                }
            }
        }
        

        static string GetDefaultFolder()
        {
            var home = Environment.GetFolderPath(
                Environment.SpecialFolder.UserProfile);

            return System.IO.Path.Combine(home, "Downloads");
        }


    }
}
