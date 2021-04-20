using RockPaperScissors.Constants;
using System;

namespace RockPaperScissors.Players
{
    public class Computer : IPlayer
    {
        public string Name { get; set; } = "Computer";
        public int Wins { get; set; } = 0;

        public Guesture GetPlayerGuesture()
        {
            Random randomSelection = new Random();

            int rng = randomSelection.Next(1, 3);

            Console.WriteLine($"\r\n\r\nComputer Selected [???]:");
            return (Guesture)rng;
        }
    }
}
