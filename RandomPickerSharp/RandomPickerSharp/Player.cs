﻿namespace RandomPickerSharp
{
    public class Player
    {
        public string Name { get; set; }
        public Guid PlayerId { get; set; }
        public int CorrectGuesses { get; set; } = 0;

        public Player(string name)
        {
            this.Name = name.Trim();
            PlayerId = Guid.NewGuid();
        }
    }
}
