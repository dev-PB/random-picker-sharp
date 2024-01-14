using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void PickSong(bool openUrl)
        {
            this.HasBeenPicked = true;

            if (openUrl)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = Url.ToString(),
                    UseShellExecute = true
                });
            }
        }
    }
}
