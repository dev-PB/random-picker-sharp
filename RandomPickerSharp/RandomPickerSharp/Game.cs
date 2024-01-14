using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerSharp
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();

        public Game()
        {
            this.Players = this.loadPlayers();
        }

        public void Play()
        {
            this.loadSongs();
            this.pickSongs();
        }

        public List<Player> loadPlayers()
        {
            string[] names = IO.GetPlayerNames();
            return names.Select(i => new Player(i)).ToList();
        }

        public void loadSongs()
        {
            foreach (Player player in Players)
            {
                string[] songUrls = IO.GetNameList($"Enter song URLs for {player.Name}", 1);
                Songs.AddRange(songUrls.Select(i => new Song(i, player.PlayerId)));
            }
        }

        public void pickSongs()
        {
            Random rng = new Random();

            while (this.Songs.Any(i => !i.HasBeenPicked))
            {
                Guid[] unpickedSongIds = Songs.Where(i => !i.HasBeenPicked).Select(i => i.SongId).ToArray();
                Guid pickedSongId = unpickedSongIds[rng.Next(unpickedSongIds.Count())];
                Song? pickedSong = this.Songs.Find(i => i.SongId == pickedSongId);

                if (pickedSong == null)
                {
                    throw new Exception("Failed to pick song");
                }

                pickedSong.HasBeenPicked = true;
                Console.WriteLine(pickedSong.Url);
                Console.ReadLine();

            }
        }
    }
}
