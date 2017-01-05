using Business.MtgLifeCounter.History;
using Business.MtgLifeCounter.Game;
using Common.Android.Gesture;
using static Business.MtgLifeCounter.Enumerations.Enum;

namespace Business.MtgLifeCounter.Managers
{
    public class ManagerGesture
    {

        public static bool GameGestureLeft(Widgets.Screen screen, Move move, Score score, HistoryAllGames history)
        {
            var refresh = false;
            var typeZone = ManagerScreenScore.GetTypeZone(screen, move);
            var typePlayer = ManagerScreenScore.GetTypePlayer(screen, move);
            if (typeZone == TypeZone.PLAYER)
            {
                ManagerScore.ScoreHalf(score, typePlayer, history);
                refresh = true;
            }
            if (typeZone == TypeZone.OPPONENT)
            {
                ManagerScore.ScoreDouble(score, typePlayer, history);
                refresh = true;
            }
            return refresh;
        }

        public static bool GameGestureRight(Widgets.Screen screen, Move move, Score score, HistoryAllGames history)
        {
            var refresh = false;
            var typeZone = ManagerScreenScore.GetTypeZone(screen, move);
            var typePlayer = ManagerScreenScore.GetTypePlayer(screen, move);
            if (typeZone == TypeZone.PLAYER)
            {
                ManagerScore.ScoreDouble(score, typePlayer, history);
                refresh = true;
            }
            if (typeZone == TypeZone.OPPONENT)
            {
                ManagerScore.ScoreHalf(score, typePlayer, history);
                refresh = true;
            }
            return refresh;
        }

        public static bool GameGestureUp(Widgets.Screen screen, Move move, Score score, HistoryAllGames history)
        {
            var refresh = false;
            var typeZone = ManagerScreenScore.GetTypeZone(screen, move);
            var typePlayer = ManagerScreenScore.GetTypePlayer(screen, move);
            if (typeZone == TypeZone.PLAYER)
            {
                ManagerScore.ScoreUp(score, typePlayer, history, false, 5);
                refresh = true;
            }
            if (typeZone == TypeZone.OPPONENT)
            {
                ManagerScore.ScoreDown(score, typePlayer, history, false, 5);
                refresh = true;
            }
            return refresh;
        }

        public static bool GameGestureDown(Widgets.Screen screen, Move move, Score score, HistoryAllGames history)
        {
            var refresh = false;
            var typeZone = ManagerScreenScore.GetTypeZone(screen, move);
            var typePlayer = ManagerScreenScore.GetTypePlayer(screen, move);
            if (typeZone == TypeZone.PLAYER)
            {
                ManagerScore.ScoreDown(score, typePlayer, history, false, 5);
                refresh = true;
            }
            if (typeZone == TypeZone.OPPONENT)
            {
                ManagerScore.ScoreUp(score, typePlayer, history, false, 5);
                refresh = true;
            }
            return refresh;
        }

        public static bool GameSingleTap(Widgets.Screen screen, Move move, Score score, HistoryAllGames history)
        {
            var refresh = false;
            var typeScore = ManagerScreenScore.GetTypeScore(screen, move);
            var typeZone = ManagerScreenScore.GetTypeZone(screen, move);
            var typePlayer = ManagerScreenScore.GetTypePlayer(screen, move);
            var top = ManagerScreenScore.GestureInScoreTop(screen, move);
            var bottom = ManagerScreenScore.GestureInScoreBottom(screen, move);
            if((typeZone == TypeZone.OPPONENT && bottom) || (typeZone == TypeZone.PLAYER && top))
            {
                ManagerScore.ScoreUp(score, typePlayer, history);
                refresh = true;
            }
            if ((typeZone == TypeZone.OPPONENT && top) || (typeZone == TypeZone.PLAYER && bottom))
            {
                ManagerScore.ScoreDown(score, typePlayer, history);
                refresh = true;
            }
            return refresh;
        }

    }
}