namespace Business.MtgLifeCounter.Constants
{
    public class Const
    {

        public const double SCORE_SIZE_SCREEN_PERCENTAGE = 0.45;

        public const int CALIBRAGE_TEXT_ZONE_SIZE = 1000;
        public const int CALIBRAGE_TEXT_LENGTH_MIN = 1;
        public const int CALIBRAGE_TEXT_LENGTH_MAX = 10;
        public const char CALIBRAGE_TEXT_CHAR = 'X';

        public const int CONFIG_SCORE_START = 20;
        public const int CONFIG_SCORE_START_TWO_HEAD_TROLL = 30;
        public const int CONFIG_SCORE_INCREMENT_STEP_MULTIPLE = 5;

        public const int HISTORY_SCORE_MILLISECONDS_TOLERANCE = 1000;

        public static string CALIBRAGE_TEXT(int length)
        {
            var text = "";
            for (var index = 0; index < length; index++)
            {
                text += CALIBRAGE_TEXT_CHAR;
            }
            return text;
        }

        // Taille des widgets

        // Temps entre 2 scores

    }
}