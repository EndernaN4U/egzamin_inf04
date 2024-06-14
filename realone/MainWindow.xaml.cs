using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace realone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Album> Albums { get; set; }
        int album_index = 0;

        public MainWindow()
        {
            InitializeComponent();

            Albums = LoadAlbums();
            DataRefresh();
        }

        List<Album> LoadAlbums()
        {
            List<Album> albums = new List<Album>();

            
            var file_lines = File.ReadAllLines("./data/Data.txt");

            for(int i = 0; i < file_lines.Length - 4; i += 6)
            {
                Album album = new Album(
                    file_lines[i],
                    file_lines[i + 1],
                    Convert.ToInt16(file_lines[i + 2]),
                    Convert.ToInt16(file_lines[i + 3]),
                    Convert.ToInt32(file_lines[i + 4]));

                albums.Add(album);
            }

            return albums;
        }

        void DataRefresh()
        {
            artist_label.Content = Albums[album_index].artist;
            album_label.Content = Albums[album_index].title;
            songs_amount_label.Content = Albums[album_index].songsNumber + " utworów";
            year_label.Content = Albums[album_index].year;
            downloads_label.Content = Albums[album_index].downloadNumber;
        }

        private void go_back_btn_Click(object sender, RoutedEventArgs e)
        {
            album_index--;
            if(album_index < 0)
            {
                album_index = Albums.Count;
            }
            DataRefresh();
        }

        private void go_forward_btn_Click(object sender, RoutedEventArgs e)
        {
            album_index++;
            if(album_index >= Albums.Count)
            {
                album_index = 0;
            }
            DataRefresh();
        }

        private void dowload_button_Click(object sender, RoutedEventArgs e)
        {
            Albums[album_index].downloadNumber++;
            downloads_label.Content = Albums[album_index].downloadNumber;
        }
    }
}