using Business.MtgLifeCounter.Constants;
using Business.MtgLifeCounter.Game;
using Business.MtgLifeCounter.History;
using System;
using System.Linq;
using static Business.MtgLifeCounter.Enumerations.Enum;

namespace Business.MtgLifeCounter.Managers
{
    public class ManagerHistory
    {

        #region METHODS GAME

        private static void AddGame(HistoryAllGames history)
        {
            history.Games.Add(new HistoryGame());
        }

        #endregion

        #region METHODS SCORE

        public static void AddScore(HistoryAllGames history, Score score)
        {
            if (!history.Games.Any())
            {
                AddGame(history);
            }
            if (!IsNewScore(history, score))
            {
                UpdateScore(history.Games.Last().Scores.Last(), score);
            }
            else
            {
                var lastChange = TypePlayer.NONE;
                if (history.Games.Last().Scores.Count > 1)
                {
                    lastChange = GetScoreChange(history, score) == TypePlayer.PLAYER ? TypePlayer.PLAYER : TypePlayer.OPPONENT;   
                }
                history.Games.Last().Scores.Add(CreateScore(score, lastChange));
            }
        }

        private static HistoryScore CreateScore(Score score, TypePlayer lastChange)
        {
            return new HistoryScore()
            {
                Player = score != null ? score.LifePoints_Player : 0,
                Opponent = score != null ? score.LifePoints_Opponent : 0,
                Date = DateTime.Now,
                LastChange = lastChange
            };
        }

        private static void UpdateScore(HistoryScore history, Score score)
        {
            if (history.LastChange == TypePlayer.NONE)
            {
                history.LastChange = history.Player != score.LifePoints_Player ? TypePlayer.PLAYER : history.LastChange;
                history.LastChange = history.Opponent != score.LifePoints_Opponent ? TypePlayer.OPPONENT : history.LastChange;
            }
            history.Player = score != null ? score.LifePoints_Player : 0;
            history.Opponent = score != null ? score.LifePoints_Opponent : 0;
            history.Date = DateTime.Now;
        }

        #endregion

        #region TOOLS

        public static string GetString(HistoryAllGames history)
        {
            return history != null && history.Games.Any() ?
                string.Join(
                    Environment.NewLine, 
                    history.Games.First().Scores
                        .Select(s => s.Date.ToString("HH:mm:ss") + " - " + s.Player + " - " + s.Opponent)
                        .ToList()
                )
                : "";
        }

        private static bool IsNewScore(HistoryAllGames history, Score score)
        {
            var result = true;
            var gameRef = history.Games.Last();
            if (gameRef.Scores.Any())
            {
                var scoreRef = gameRef.Scores.Last();
                result = gameRef.Scores.Count == 1 || (gameRef.Scores.Count > 1 && GetScoreChange(history, score) != scoreRef.LastChange);
            }
            return result;
        }

        private static TypePlayer GetScoreChange(HistoryAllGames history, Score score)
        {
            var result = TypePlayer.NONE;
            var scoreRef = history.Games.Last().Scores.Last();
            result = scoreRef.Player != score.LifePoints_Player ? TypePlayer.PLAYER : result;
            result = scoreRef.Opponent != score.LifePoints_Opponent ? TypePlayer.OPPONENT : result;
            return result;
        }

        #endregion

    }
}