using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerSharp
{
    public class Player
    {
        public string Name { get; set; }
        public int CorrectGuesses { get; set; } = 0;
        public List<Song> Songs { get; set; }
        public bool HasUnpickedSongs => this.Songs.Any(i => !i.HasBeenPicked);

        public Player(string name)
        {
            this.Name = name;
        }
    }
}
