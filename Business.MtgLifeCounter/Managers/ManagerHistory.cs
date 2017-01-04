using Business.MtgLifeCounter.Game;
using Business.MtgLifeCounter.History;
using System;
using System.Linq;

namespace Business.MtgLifeCounter.Managers
{
    public class ManagerHistory
    {

        public static void AddScore(HistoryAllGames history, Score score)
        {
            if (!history.Games.Any())
            {
                CreateGame(history);
            }
            history.Games.Last().Scores.Add(new HistoryScore(score));
        }

        private static void CreateGame(HistoryAllGames history)
        {
            history.Games.Add(new HistoryGame());
        }

        public static string GetString(HistoryAllGames history)
        {
            var text = "";
            if (history != null && history.Games.Any())
            {
                text = string.Join(Environment.NewLine, history.Games.First().Scores.Select(s => s.Date.ToString("HH:mm:ss") + " - " + s.Player + " - " + s.Opponent).ToList());
        }
            return text;
        }

    }
}