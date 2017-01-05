using Business.MtgLifeCounter.Game;
using System;

namespace Business.MtgLifeCounter.History
{
    public class HistoryScore
    {

        public int Player { get; set; }
        public int Opponent { get; set; }
        public DateTime Date { get; set; }

        public HistoryScore(Score score)
        {
            Player = score != null ? score.LifePoints_Player : 0;
            Opponent = score != null ? score.LifePoints_Opponent : 0;
            Date = DateTime.Now;
        }

    }
}