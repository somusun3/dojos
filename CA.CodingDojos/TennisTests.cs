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

        [TestCase("ABB", "Fifteen Thirty", "Player A won once and player B won twice and expected score is Fifteen Thirty")]
        [TestCase("AAB", "Thirty Fifteen", "Player A won twice and player B won once and expected score is Thirty Fifteen")]
        [TestCase("ABABA", "Forty Thirty", "Player A won thrice and player B won twice and expected score is Forty Thirty")]
        [TestCase("ABABAB", "Deuce", "Player A won thrice and player B won thrice and expected score is Deuce")]
        [TestCase("ABABABA", "Advantage A", "Player A won four times and player B won thrice and expected score is Advantage A")]
        [TestCase("ABABABB", "Advantage B", "Player B won four times and player A won thrice and expected score is Advantage B")]
        [TestCase("ABABABAA","Game A", "Player A won point after advantage and has won the game and expected score is Game A" )]
        [TestCase("ABABABBB", "Game B", "Player B won point after advantage and has won the game and expected score is Game B")]
        [TestCase("ABABABBA", "Deuce", "Duece after advantage and expected score is Deuce")]
        public void Test_PalyerA_And_PlayerB_Different_Scores(string scoreSequence, string expectedScore, string message)
        {
            foreach (char player in scoreSequence)
                game.WonPoint(player.ToString());

            Assert.AreEqual(expectedScore, game.GameScore, message);
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
