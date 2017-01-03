using Business.MtgLifeCounter.Game;

namespace Business.MtgLifeCounter.Managers
{
    public class ManagerScore
    {

        public enum TypePlayer { PLAYER, OPPONENT }

        public void ScoreUp(Score score, TypePlayer typePlayer)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    score.Player += 1;
                    break;
                case TypePlayer.OPPONENT:
                    score.Player += 1;
                    break;
            }
        }

        public void ScoreDown(Score score, TypePlayer typePlayer)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    score.Player -= 1;
                    break;
                case TypePlayer.OPPONENT:
                    score.Player -= 1;
                    break;
            }
        }

        public void ScoreDouble(Score score, TypePlayer typePlayer)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    score.Player *= 2;
                    break;
                case TypePlayer.OPPONENT:
                    score.Player *= 2;
                    break;
            }
        }

        public void ScoreHalf(Score score, TypePlayer typePlayer)
        {
            switch (typePlayer)
            {
                case TypePlayer.PLAYER:
                    score.Player /= 2;
                    break;
                case TypePlayer.OPPONENT:
                    score.Player /= 2;
                    break;
            }
        }

    }
}