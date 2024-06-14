using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realone
{
    internal class Album
    {
        public string artist { get; set; }
        public string title { get; set; }
        public int songsNumber { get; set; }
        public int year { get; set; }
        public long downloadNumber { get; set; }

        public Album(string artist, string title, int songsNumber, int year, long downloadNumber)
        {
            this.artist = artist;
            this.title = title;
            this.songsNumber = songsNumber;
            this.year = year;
            this.downloadNumber = downloadNumber;
        }

        public override string ToString()
        {
            return $"{artist}\n{title}\n{songsNumber}\n{year}\n{downloadNumber}\n";
        }
    }
}
