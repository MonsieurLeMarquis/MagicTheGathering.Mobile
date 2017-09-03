using Business.MtgLifeCounter.History;
using Business.MtgLifeCounter.Widgets;

namespace Business.MtgLifeCounter.Context
{
    public class MtgLifeCounterContext
    {

        public static Screen Screen { get; set; }
        public static Game.Score Score { get; set; }
        public static HistoryAllGames History { get; set; }

    }
}