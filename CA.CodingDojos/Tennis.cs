namespace CA.CodingDojos
{
    public class Tennis
    {
        private readonly string firstPlayer;
        private readonly string secondPlayer;
        private const int WinningPoints = 4;
        private int firstPlayerScore;
        private int secondPlayerScore;
        private readonly string[] scoreTexts = { "Love", "Fifteen", "Thirty", "Forty" };

        public Tennis(string firstPlayer, string secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
        }

        public string GameScore
        {
            get { return CalculateScore(); }
        }


        internal void WonPoint(string playerName)
        {
            if (!HasAnyoneWonTheGame())
            {
                if (playerName == firstPlayer)
                    firstPlayerScore += 1;
                if (playerName == secondPlayer)
                    secondPlayerScore += 1;
            }
        }

        private bool HasAnyoneWonTheGame()
        {
            return firstPlayerScore == WinningPoints || secondPlayerScore == WinningPoints;
        }

        private string CalculateScore()
        {
            if (HasAnyoneWonTheGame())
            {
                return "Game " + GetWinningPlayerName();
            }
            if (IfBothPlayersScoresAreEqual())
            {
                return GetScore(firstPlayerScore) + " All";
            }
            return GetScore(firstPlayerScore) + " " + GetScore(secondPlayerScore);
        }

        private string GetWinningPlayerName()
        {
            if (firstPlayerScore == WinningPoints) return firstPlayer;
            return secondPlayer;
        }

        private bool IfBothPlayersScoresAreEqual()
        {
            return firstPlayerScore == secondPlayerScore;
        }

        string GetScore(int score)
        {
            return scoreTexts[score];
        }
    }
}