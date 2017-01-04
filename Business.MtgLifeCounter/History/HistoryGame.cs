using System.Collections.Generic;

namespace Business.MtgLifeCounter.History
{
    public class HistoryGame
    {

        public List<HistoryScore> Scores { get; set; }

        public HistoryGame()
        {
            Scores = new List<HistoryScore>();
        }

    }
}