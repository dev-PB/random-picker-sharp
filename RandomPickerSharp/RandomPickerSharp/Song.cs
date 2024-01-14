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

        public Song(Uri url, Guid pickedByPlayerId)
        {
            this.Url = url;
            PickedByPlayerId = pickedByPlayerId;
            SongId = Guid.NewGuid();
        }

        public void PickSong(bool openUrl)
        {
            this.HasBeenPicked = true;

            if (openUrl)
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = Url.ToString(),
                        UseShellExecute = true
                    });
                } catch (Exception ex)
                {
                    Console.WriteLine($"An error occured when attempting to open url {Url.ToString()}\n{ex.Message}");
                }
            }
        }
    }
}
