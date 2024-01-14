using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerSharp
{
    public class Game
    {
        public List<Player>? Players { get; set; }

        public void Run()
        {
            this.loadPlayers();
            this.loadSongs();
        }

        public void loadPlayers()
        {
            string[] names = IO.GetPlayerNames();
            Players = names.Select(i => new Player(i)).ToList();
        }

        public void loadSongs()
        {
            if (Players == null || Players.Count < 2)
            {
                throw new Exception("Players list not initialized");
            }

            foreach (Player player in Players)
            {
                string[] songUrls = IO.GetNameList($"Enter song URLs for {player.Name}", 1);
                player.Songs = songUrls.Select(i => new Song(i)).ToList();
            }
        }
    }
}
