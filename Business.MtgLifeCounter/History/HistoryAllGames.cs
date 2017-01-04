using System.Collections.Generic;

namespace Business.MtgLifeCounter.History
{
    public class HistoryAllGames
    {

        public List<HistoryGame> Games { get; set; }

        public HistoryAllGames()
        {
            Games = new List<HistoryGame>();
        }

    }
}