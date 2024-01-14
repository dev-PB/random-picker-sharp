using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerSharp
{
    public class Song
    {
        public Uri Url { get; set; }
        public bool HasBeenPicked { get; set; } = false;

        public Song(string url)
        {
            this.Url = new Uri(url);
        }
    }
}
