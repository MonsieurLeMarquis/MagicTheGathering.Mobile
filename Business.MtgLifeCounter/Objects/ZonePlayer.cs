namespace Business.MtgLifeCounter.Objects
{
    public class ZonePlayer : BaseWidget
    {
        public Score ScorePlayer { get; set; }
        public Score ScoreOpponent { get; set; }
        public PlayerName NamePlayer { get; set; }
        public PlayerName NameOpponent { get; set; }
    }
}