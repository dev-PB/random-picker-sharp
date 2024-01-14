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
        public int CorrectGuessesOverall { get; set; } = 0;
        public bool ShouldOpenUrls { get; set; } = false;

        public Game()
        {
            this.ShouldOpenUrls = IO.GetYesOrNo("Open URLs automatically?");
            this.Players = this.loadPlayers();
        }

        public void Play()
        {
            this.loadSongs();
            this.pickSongs();
            this.displayResults();
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
                Player? player = this.Players.Find(i => i.PlayerId == pickedSong?.PickedByPlayerId);

                if (pickedSong == null || player == null)
                {
                    throw new Exception("Failed to pick song");
                }

                pickedSong.PickSong(ShouldOpenUrls);

                IO.OutputSongInfo(pickedSong.Url.ToString(), player.Name);
                if (IO.GetYesOrNo("Did they guess correctly?"))
                {
                    CorrectGuessesOverall++;
                    player.CorrectGuesses++;
                }
            }
        }

        public void displayResults()
        {
            List<string> scores = this.Players
                .OrderByDescending(i => i.CorrectGuesses)
                .Select(i => $"{i.Name,10} {getScoreString(i.PlayerId),-7}")
                .ToList();

            IO.PrintScoreBoard(CorrectGuessesOverall, Songs.Count, scores);
        }

        public string getScoreString(Guid playerId)
        {
            Player? player = this.Players.Find(i => i.PlayerId == playerId);

            if (player == null)
            {
                throw new Exception("Couldn't find player");
            }

            double amountOfSongs = this.Songs.Where(i => i.PickedByPlayerId == player.PlayerId).Count();
            double percent = ((double)player.CorrectGuesses / amountOfSongs) * 100;
            return $"{player.CorrectGuesses} ({percent.ToString("0.##")}%)";
        }
    }
}
