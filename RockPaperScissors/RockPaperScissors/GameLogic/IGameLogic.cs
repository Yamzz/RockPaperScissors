using RockPaperScissors.Constants;
using RockPaperScissors.Players;

namespace RockPaperScissors.GameLogic
{
    public interface IGameLogic
    {
        public void PlayRound(int roundNumber, IPlayer firstPlayer, IPlayer secondPlayer);

        public void DecideRoundWinner(Guesture? humanChoice, Guesture? computerChoice);

        public string CheckOverallWinner();
    }
}
