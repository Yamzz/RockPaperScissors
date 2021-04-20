using NUnit.Framework;
using RockPaperScissors.Constants;
using RockPaperScissors.Players;

namespace RockPaperScissorsTests
{
    public class TestsPlayers
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestHumanCreation()
        {
            // Arr
            var humanPlayer = new Human();

            // assert
            Assert.That(humanPlayer, Is.Not.Null);
            Assert.AreEqual(humanPlayer.Name, string.Empty);
            Assert.AreEqual(humanPlayer.Wins, 0);
        }


        [Test]
        public void TestComputerCreation()
        {
            // Arr
            var computerPlayer = new Computer();

            // assert
            Assert.That(computerPlayer, Is.Not.Null);
            Assert.AreEqual(computerPlayer.Name, "Computer"); // test default name
            Assert.AreEqual(computerPlayer.Wins, 0);
        }


        [Test]
        public void TestHumanPlayerGeneratesRandomSelection()
        {
            // Arr
            var humanPlayer = new Human();
            humanPlayer.Number = 2;

            // act
            var result = humanPlayer.GetPlayerGuesture();

            // assert
            Assert.That(humanPlayer, Is.Not.Null);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<Guesture>());
            Assert.IsAssignableFrom<Guesture>(result);
        }



        [Test]
        public void TestComputerPlayerGeneratesRandomSelection()
        {
            // Arr
            var computerPlayer = new Computer();

            // act
            var result = computerPlayer.GetPlayerGuesture();

            // assert
            Assert.That(computerPlayer, Is.Not.Null);
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<Guesture>());
            Assert.IsAssignableFrom<Guesture>(result);
        }
    }
}