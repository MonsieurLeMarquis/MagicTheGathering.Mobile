using Business.MtgLifeCounter.Game;
using Business.MtgLifeCounter.History;

namespace Business.MtgLifeCounter.Managers
{
    public class ManagerScore
    {

        public enum TypePlayer { PLAYER, OPPONENT }

        public static void ScoreUp(Score score, TypePlayer typePlayer, HistoryAllGames history, int value = 1)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    score.Player += value;
                    break;
                case TypePlayer.OPPONENT:
                    score.Opponent += value;
                    break;
            }
            ManagerHistory.AddScore(history, score);
        }

        public static void ScoreDown(Score score, TypePlayer typePlayer, HistoryAllGames history, int value = 1)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    score.Player -= value;
                    break;
                case TypePlayer.OPPONENT:
                    score.Opponent -= value;
                    break;
            }
            ManagerHistory.AddScore(history, score);
        }

        public static void ScoreDouble(Score score, TypePlayer typePlayer, HistoryAllGames history)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    score.Player *= 2;
                    break;
                case TypePlayer.OPPONENT:
                    score.Opponent *= 2;
                    break;
            }
            ManagerHistory.AddScore(history, score);
        }

        public static void ScoreHalf(Score score, TypePlayer typePlayer, HistoryAllGames history)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    score.Player /= 2;
                    break;
                case TypePlayer.OPPONENT:
                    score.Opponent /= 2;
                    break;
            }
            ManagerHistory.AddScore(history, score);
        }

    }
}