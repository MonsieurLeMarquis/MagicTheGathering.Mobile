using Business.MtgLifeCounter.Configuration;
using Business.MtgLifeCounter.Game;
using Business.MtgLifeCounter.History;
using static Business.MtgLifeCounter.Enumerations.Enum;

namespace Business.MtgLifeCounter.Managers
{
    public class ManagerScore
    {

        public static string GetScoreText(int score)
        {
            if (score == int.MinValue)
            {
                return "-∞";
            }
            else if (score == int.MaxValue)
            {
                return "∞";
            }
            else
            {
                return score.ToString();
            }
        }

        public static void ScoreUpdate(Score score, TypePlayer typePlayer, HistoryAllGames history, TypeScoreAction action)
        {
            switch(action)
            {
                case TypeScoreAction.UP_ONE:
                    ScoreUp(score, typePlayer, history);
                    break;
                case TypeScoreAction.DOWN_ONE:
                    ScoreDown(score, typePlayer, history);
                    break;
                case TypeScoreAction.UP_MULTIPLE:
                    ScoreUp(score, typePlayer, history, false, Config.ScoreStepMultiplePoints);
                    break;
                case TypeScoreAction.DOWN_MULTIPLE:
                    ScoreDown(score, typePlayer, history, false, Config.ScoreStepMultiplePoints);
                    break;
                case TypeScoreAction.DOUBLE:
                    ScoreDouble(score, typePlayer, history);
                    break;
                case TypeScoreAction.HALF:
                    ScoreHalf(score, typePlayer, history);
                    break;
                case TypeScoreAction.POISON_UP:
                    break;
                case TypeScoreAction.POISON_DOWN:
                    break;
            }
        }

        private static void ScoreUp(Score score, TypePlayer typePlayer, HistoryAllGames history, bool poison = false, int value = 1)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    if (poison)
                    {
                        score.PoisonCounters_Player = ScoreUp(score.PoisonCounters_Player, value);
                    }
                    else
                    {
                        score.LifePoints_Player = ScoreUp(score.LifePoints_Player, value);
                    }                    
                    break;
                case TypePlayer.OPPONENT:
                    if (poison)
                    {
                        score.PoisonCounters_Opponent = ScoreUp(score.PoisonCounters_Opponent, value);
                    }
                    else
                    {
                        score.LifePoints_Opponent = ScoreUp(score.LifePoints_Opponent, value);
                    }
                    break;
            }
            ManagerHistory.AddScore(history, score);
        }

        private static int ScoreUp(int score, int value)
        {
            if (score <= (int.MaxValue - value))
            {
                score += value;
            }
            else
            {
                score = int.MaxValue;
            }
            return score;
        }

        private static void ScoreDown(Score score, TypePlayer typePlayer, HistoryAllGames history, bool poison = false, int value = 1)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    if (poison)
                    {
                        score.PoisonCounters_Player = ScoreDown(score.PoisonCounters_Player, value);
                    }
                    else
                    {
                        score.LifePoints_Player = ScoreDown(score.LifePoints_Player, value);

                    }
                    break;
                case TypePlayer.OPPONENT:
                    if (poison)
                    {
                        score.PoisonCounters_Opponent = ScoreDown(score.PoisonCounters_Opponent, value);
                    }
                    else
                    {
                        score.LifePoints_Opponent = ScoreDown(score.LifePoints_Opponent, value);
                    }
                    break;
            }
            ManagerHistory.AddScore(history, score);
        }

        private static int ScoreDown(int score, int value)
        {
            if (score >= (int.MinValue + value))
            {
                score -= value;
            }
            else
            {
                score = int.MinValue;
            }
            return score;
        }

        private static void ScoreDouble(Score score, TypePlayer typePlayer, HistoryAllGames history)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    score.LifePoints_Player = ScoreDouble(score.LifePoints_Player);
                    break;
                case TypePlayer.OPPONENT:
                    score.LifePoints_Opponent = ScoreDouble(score.LifePoints_Opponent);
                    break;
            }
            ManagerHistory.AddScore(history, score);
        }

        private static int ScoreDouble(int score)
        {
            if (score > 0)
            {
                if (score > (int.MaxValue / 2))
                {
                    score = int.MaxValue;
                }
                else
                {
                    score *= 2;
                }
            }
            else if (score < 0)
            {
                if (score < (int.MinValue / 2))
                {
                    score = int.MinValue;
                }
                else
                {
                    score /= 2;
                }

            }
            return score;
        }

        private static void ScoreHalf(Score score, TypePlayer typePlayer, HistoryAllGames history)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    score.LifePoints_Player = ScoreHalf(score.LifePoints_Player);
                    break;
                case TypePlayer.OPPONENT:
                    score.LifePoints_Opponent = ScoreHalf(score.LifePoints_Opponent);
                    break;
            }
            ManagerHistory.AddScore(history, score);
        }

        private static int ScoreHalf(int score)
        {
            if (score > 0)
            {
                score /= 2;
               
            }
            else if (score < 0)
            {
                if (score < (int.MinValue / 2))
                {
                    score = int.MinValue;
                }
                else
                {
                    score *= 2;
                }
            }
            return score;
        }

    }
}