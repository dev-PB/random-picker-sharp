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
        public Guid SongId { get; set; }
        public Guid PickedByPlayerId { get; set; }
        public bool HasBeenPicked { get; set; } = false;

        public Song(string url, Guid pickedByPlayerId)
        {
            this.Url = new Uri(url);
            PickedByPlayerId = pickedByPlayerId;
            SongId = Guid.NewGuid();
        }
    }
}
