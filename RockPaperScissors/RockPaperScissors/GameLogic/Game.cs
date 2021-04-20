using RockPaperScissors.Constants;
using RockPaperScissors.Players;
using System;
using System.Collections.Generic;

namespace RockPaperScissors.GameLogic
{
    public class Game : IGameLogic
    {
        private IPlayer humanPlayer;
        private IPlayer computerPlayer;

        public Game(IPlayer humanPlayer, IPlayer computerPlayer) // inject human player
        {
            this.humanPlayer = humanPlayer;
            this.computerPlayer = computerPlayer;
        }

       public void StartGame(int choice)
        {
            IPlayer firstPlayer;
            IPlayer secondPlayer;

            if (choice == 1)
            {
                firstPlayer = this.computerPlayer;
                secondPlayer = this.humanPlayer;
            }
            else
            {
                secondPlayer = this.computerPlayer;
                firstPlayer = this.humanPlayer;
            }

            Console.Write($"{firstPlayer.Name} gets 1st Go");

            for (int i = 0; i < Global.NumberOfGames; i++)
            {
                this.PlayRound(i, firstPlayer, secondPlayer);
            }

            this.CheckOverallWinner();
        }

       public void PlayRound(int roundNumber, IPlayer firstPlayer, IPlayer secondPlayer)
        {
            Console.Write($"\r\n\r\nRound {roundNumber + 1}"); 
            Guesture? computerChoice = null;
            Guesture? humanChoice = null;

            // this logic is depending on which player gets first go
            if (firstPlayer.Name == this.computerPlayer.Name)
            {
                computerChoice = this.computerPlayer.GetPlayerGuesture();
            }
            else
            {
                humanChoice = this.humanPlayer.GetPlayerGuesture();
            }

            if (secondPlayer.Name == this.humanPlayer.Name)
            {
                humanChoice = this.humanPlayer.GetPlayerGuesture();
            }
            else
            {
                computerChoice = this.computerPlayer.GetPlayerGuesture();
            }

            DecideRoundWinner(humanChoice, computerChoice);

            if (roundNumber == 2)
            {
                return;
            }

            Console.WriteLine("\r\nReady For Next Round!!!!!.");
        }

       public void DecideRoundWinner(Guesture? humanChoice, Guesture? computerChoice)
       {
            //tie game
            Console.WriteLine($"Computer Selected {Enum.GetName(typeof(Guesture), computerChoice.Value)}");
            Console.WriteLine($"{this.humanPlayer.Name} Selected {Enum.GetName(typeof(Guesture), humanChoice.Value)}");

            if (humanChoice == computerChoice)
            {
                Console.WriteLine($"\r\nThe game is a tie.");
                return;
            }

            // get the corresponding guesture if key is passed through
            var checkWinners = new Dictionary<Guesture?, Guesture>
            {
                { Guesture.Rock, Guesture.Scissors },
                { Guesture.Scissors, Guesture.Paper },
                { Guesture.Paper, Guesture.Rock }
            };

            var selectedChoice = checkWinners[humanChoice];
            if (selectedChoice == computerChoice)
            {
                Console.WriteLine($"\r\n{this.humanPlayer.Name} BEATS {this.computerPlayer.Name}.");
                this.humanPlayer.Wins++;
            }
            else
            {
                Console.WriteLine($"\r\n{this.computerPlayer.Name} BEATS {this.humanPlayer.Name}.");
                this.computerPlayer.Wins++;
            }
        }

       public string CheckOverallWinner()
       {
            Console.WriteLine($"-------------------------------------------------------------------------------");
            if (this.computerPlayer.Wins > this.humanPlayer.Wins)
            {
                Console.WriteLine($"{this.computerPlayer.Name} WON!!!!");
                return this.computerPlayer.Name;
            }

            if (this.humanPlayer.Wins > this.computerPlayer.Wins)
            {
                Console.WriteLine($"{this.humanPlayer.Name} WON!!!!");
                return this.humanPlayer.Name;
            }

            if (this.humanPlayer.Wins == this.computerPlayer.Wins)
            {
                Console.WriteLine($"TIE GAME!!!!");
                return "TIE GAME";
            }

            return null;
        }
    }
}
