using RockPaperScissors.Constants;
using System;
using System.Linq;

namespace RockPaperScissors.Players
{
    public class Human : IPlayer
    {
        public string Name { get; set; } = string.Empty;
        public int Wins { get; set; } = 0;
        public int Number = 0;

        public Guesture GetPlayerGuesture()
        {
            string choice = string.Empty;
            int[] rockPaperScissors = { 1, 2, 3 };
            while (!rockPaperScissors.Contains(Number))
            {
                Console.WriteLine($"\r\n{this.Name} Please make your selection. Rock[1], Paper[2], Scissors[3]");
                choice = Console.ReadLine();
                int.TryParse(choice, out Number);
            }

            var guesture = (Guesture)Number;

            // "out", not "ref". Inside the method it has to assign it hence we have to resassign it to 0 again
            this.Number = 0;
            return guesture;
        }
    }
}
