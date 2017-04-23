using Business.MtgLifeCounter.Game;
using System;
using static Business.MtgLifeCounter.Enumerations.Enum;

namespace Business.MtgLifeCounter.History
{
    public class HistoryScore
    {

        public int Player { get; set; }
        public int Opponent { get; set; }
        public DateTime Date { get; set; }
        public TypePlayer LastChange { get; set; }

    }
}