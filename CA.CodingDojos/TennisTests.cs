using NUnit.Framework;

namespace CA.CodingDojos
{
    [TestFixture]
    public class TennisTests
    {
        private Tennis game;
        [SetUp]
        public void Setup()
        {
           game = new Tennis("A", "B");
        }

        [Test]
        public void TestInitialScoreShouldBeLoveAll()
        {
            string gameScore = game.GameScore;
            Assert.AreEqual("Love All", gameScore);
        }

        [Test]
        public void Test_Both_Players_won_point_Return_15_All()
        {
            game.WonPoint("A");
            game.WonPoint("B");
            string gameScore = game.GameScore;
            Assert.AreEqual("Fifteen All", gameScore);
        }

        [TestCase("A", 1, "Fifteen Love", "When player A wins once score should be Fifteen Love")]
        [TestCase("A", 2, "Thirty Love", "When player A wins twice score should be thirty Love")]
        [TestCase("A", 3, "Forty Love", "When player A wins thrice score should be forty Love")]
        [TestCase("A", 4,"Game A","When player A wins four times score should be Game A")]
        [TestCase("B", 1, "Love Fifteen", "When player B wins once score should be Love Fifteen")]
        [TestCase("B", 2, "Love Thirty", "When player B wins twice score should be Love Thirty")]
        [TestCase("B", 3, "Love Forty", "When player B wins thrice score should be Love forty")]
        [TestCase("B", 4, "Game B", "When player B wins four times score should be Game B")]
        public void TestWhenPlayerWinsPointGameScoreShouldReturnExpected(string playerName, int numberOfPointWon,string expectedScroce,string message)
        {
            for (int i = 0; i < numberOfPointWon; i++)
            {
                game.WonPoint(playerName);    
            }
            
            string gameScore = game.GameScore;
            Assert.AreEqual(expectedScroce, gameScore, message);
        }
    }
}
