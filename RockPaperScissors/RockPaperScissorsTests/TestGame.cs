using Moq;
using NUnit.Framework;
using RockPaperScissors.Constants;
using RockPaperScissors.GameLogic;
using RockPaperScissors.Players;

namespace RockPaperScissorsTests
{
    public class TestGame
    {
        Game game;
        IPlayer iHumanPlayer;
        IPlayer iComputerPlayer;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestHumanWins()
        {
            // Arr
            iHumanPlayer = new Human()
            {
                Name = "Test Human",
                Number = 3,
                Wins = 3
            };


            iComputerPlayer = new Computer()
            {
                Name = "Test Computer",
                Wins = 0
            };

            game = new Game(iHumanPlayer, iComputerPlayer);

            // assert
            Assert.That(game, Is.Not.Null);
            Assert.AreEqual(game.CheckOverallWinner(), "Test Human");
        }


        [Test]
        public void TestComputerWins()
        {
            // Arr
            iHumanPlayer = new Human()
            {
                Name = "Test Human",
                Number = 1,
                Wins = 0
            };


            iComputerPlayer = new Computer()
            {
                Name = "Test Computer",
                Wins = 3
            };


            game = new Game(iHumanPlayer, iComputerPlayer);

            // assert
            Assert.That(game, Is.Not.Null);
            Assert.AreEqual(game.CheckOverallWinner(), "Test Computer");
        }

        [Test]
        public void TestTieGame()
        {
            // Arr
            iHumanPlayer = new Human()
            {
                Name = "Test Human",
                Number = 0,
                Wins = 0
            };


            iComputerPlayer = new Computer()
            {
                Name = "Test Computer",
                Wins = 0
            };

            game = new Game(iHumanPlayer, iComputerPlayer);
            game.DecideRoundWinner(Guesture.Paper, Guesture.Paper);

            // assert
            Assert.That(game, Is.Not.Null);
            Assert.AreEqual(iComputerPlayer.Wins, iHumanPlayer.Wins);
        }


        [Test]
        public void TestGameDoesntTie()
        {
            // Arr
            var iHumanPlayerMock = new Mock<IPlayer>();
            iHumanPlayerMock.Setup(x => x.Name).Returns("Test Human");
            iHumanPlayerMock.Setup(x => x.Wins).Returns(0);

            var iComputerPlayerMock = new Mock<IPlayer>();
            iComputerPlayerMock.Setup(x => x.Name).Returns("Test Computer");
            iComputerPlayerMock.Setup(x => x.Wins).Returns(2);

            var game = new Game(iHumanPlayerMock.Object, iComputerPlayerMock.Object);
            game.DecideRoundWinner(Guesture.Paper, Guesture.Rock);

            //// assert
            Assert.That(game, Is.Not.Null);
            Assert.Greater(iComputerPlayerMock.Object.Wins, iHumanPlayerMock.Object.Wins);
        }



    }
}
