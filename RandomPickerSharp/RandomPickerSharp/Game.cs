using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPickerSharp
{
    public class Game
    {
        public List<Player> Players { get; set; } = new List<Player>();

        public void Run()
        {
            this.loadPlayers();
        }

        public void loadPlayers()
        {
            string[] names = IO.GetPlayerNames();
            foreach (string name in names)
            {
                Players.Add(new Player(name));
            }
        }
    }
}
