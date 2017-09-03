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

        public enum TypeGesture
        {
            SWIPE_LEFT,
            SWIPE_RIGHT,
            SWIPE_UP,
            SWIPE_DOWN,
            TAP_TOP,
            TAP_BOTTOM,
            TAP_LEFT,
            TAP_RIGHT,
            NONE
        }

        public enum TypeScoreCounter
        {
            LIFE_POINTS,
            POISON_COUNTERS,
            NONE
        }

        public enum TypeScoreAction
        {
            UP_ONE,
            DOWN_ONE,
            UP_MULTIPLE,
            DOWN_MULTIPLE,
            DOUBLE,
            HALF,
            POISON_UP,
            POISON_DOWN,
            NONE
        }

    }
}