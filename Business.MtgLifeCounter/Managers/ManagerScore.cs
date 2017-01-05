using Business.MtgLifeCounter.Game;
using Business.MtgLifeCounter.History;
using static Business.MtgLifeCounter.Enumerations.Enum;

namespace Business.MtgLifeCounter.Managers
{
    public class ManagerScore
    {

        public static void ScoreUp(Score score, TypePlayer typePlayer, HistoryAllGames history, bool poison = false, int value = 1)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    if (poison)
                    {
                        score.PoisonCounters_Player += value;
                    }
                    else
                    {
                        score.LifePoints_Player += value;
                    }                    
                    break;
                case TypePlayer.OPPONENT:
                    if (poison)
                    {
                        score.PoisonCounters_Opponent += value;
                    }
                    else
                    {
                        score.LifePoints_Opponent += value;
                    }
                    break;
            }
            ManagerHistory.AddScore(history, score);
        }

        public static void ScoreDown(Score score, TypePlayer typePlayer, HistoryAllGames history, bool poison = false, int value = 1)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    if (poison)
                    {
                        score.PoisonCounters_Player -= value;
                    }
                    else
                    {
                        score.LifePoints_Player -= value;
                    }
                    break;
                case TypePlayer.OPPONENT:
                    if (poison)
                    {
                        score.PoisonCounters_Opponent -= value;
                    }
                    else
                    {
                        score.LifePoints_Opponent -= value;
                    }
                    break;
            }
            ManagerHistory.AddScore(history, score);
        }

        public static void ScoreDouble(Score score, TypePlayer typePlayer, HistoryAllGames history)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    score.LifePoints_Player *= 2;
                    break;
                case TypePlayer.OPPONENT:
                    score.LifePoints_Opponent *= 2;
                    break;
            }
            ManagerHistory.AddScore(history, score);
        }

        public static void ScoreHalf(Score score, TypePlayer typePlayer, HistoryAllGames history)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    score.LifePoints_Player /= 2;
                    break;
                case TypePlayer.OPPONENT:
                    score.LifePoints_Opponent /= 2;
                    break;
            }
            ManagerHistory.AddScore(history, score);
        }

    }
}