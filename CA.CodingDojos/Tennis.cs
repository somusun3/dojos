using System;

namespace CA.CodingDojos
{
    public class Tennis
    {
        private readonly string firstPlayer;
        private readonly string secondPlayer;
        private const int WinningPoints = 4;
        private int firstPlayerScore;
        private int secondPlayerScore;
        private readonly string[] scoreTexts = { "Love", "Fifteen", "Thirty", "Forty", "Advantage" };

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
            //if (!HasAnyoneWonTheGame())
            {
                if (playerName == firstPlayer)
                    firstPlayerScore += 1;
                if (playerName == secondPlayer)
                    secondPlayerScore += 1;
            }
        }

        private bool HasAnyoneWonTheGame()
        {
            return 
                (HasPlayerAWon() || HasPlayerBWon()) ||
                HasAnyPlayerWonAfterAdvantage();
        }

        private bool HasPlayerBWon()
        {
            return (secondPlayerScore == WinningPoints && firstPlayerScore < 3);
        }

        private bool HasPlayerAWon()
        {
            return (firstPlayerScore == WinningPoints && secondPlayerScore < 3);
        }

        private bool HasAnyPlayerWonAfterAdvantage()
        {
            return (Math.Abs(firstPlayerScore - secondPlayerScore) == 2 &&
                    (firstPlayerScore >= 3 && secondPlayerScore >= 3));
        }

        private string CalculateScore()
        {
            if (HasAnyoneWonTheGame())
            {
                return "Game " + GetWinningPlayerName();
            }
            if (IfBothPlayersScoresAreEqual())
            {
                if (firstPlayerScore >= 3)
                    return "Deuce";
                return GetScore(firstPlayerScore) + " All";
            }



            if (firstPlayerScore <= 3 && secondPlayerScore <= 3)
                return GetScore(firstPlayerScore) + " " + GetScore(secondPlayerScore);

            return GetWhoHasAdvantage();

        }

        private string GetWhoHasAdvantage()
        {
            if (firstPlayerScore > 3)
                return GetScore(firstPlayerScore) + " " + firstPlayer;

            return GetScore(secondPlayerScore) + " " + secondPlayer;
        }

        private string GetWinningPlayerName()
        {
            if (firstPlayerScore > secondPlayerScore) 
                return firstPlayer;
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