namespace Business.MtgLifeCounter.Enumerations
{
    public class Enum
    {

        public enum TypePlayer
        {
            PLAYER,
            OPPONENT,
            NONE
        }

        public enum TypeZone
        {
            PLAYER,
            OPPONENT,
            NONE
        }

        public enum TypeScore
        {
            ZONE_OPPONENT_SCORE_OPPONENT,
            ZONE_OPPONENT_SCORE_PLAYER,
            ZONE_PLAYER_SCORE_PLAYER,
            ZONE_PLAYER_SCORE_OPPONENT,
            NONE
        }

    }
}