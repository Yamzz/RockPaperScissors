using RockPaperScissors.Players;
using RockPaperScissors.GameLogic;
using System;
using System.Linq;

namespace RockPaperScissors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var human = new Human();
            while (string.IsNullOrEmpty(human.Name) || human.Name == "Computer")
            {
                Console.Clear();
                Console.Write("Welcome to Rock, Paper, Scissors.\r\n\r\nPlease enter your name: ");
                human.Name = Console.ReadLine();
            }

            Console.Write($"Welcome {human.Name}...\r\n\r\nYou will now play 3 games, with the overall winner being the first player to win 2 games.... ");

            int number = 0;
            int[] choices = { 1, 2};
            while (!choices.Contains(number))
            {
                Console.Write($"\r\n\r\nWho goes First. 1 For Computer. 2 For {human.Name} : ");
                string choice = Console.ReadLine();
                int.TryParse(choice, out number);
            }

            var newGame = new Game(human, new Computer());
            newGame.StartGame(number);
            Console.ReadLine();
        }
    }
}
