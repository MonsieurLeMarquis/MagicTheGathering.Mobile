using Business.MtgLifeCounter.History;
using Business.MtgLifeCounter.Game;
using Common.Android.Gesture;
using static Business.MtgLifeCounter.Enumerations.Enum;
using Business.MtgLifeCounter.Configuration;
using Business.MtgLifeCounter.Gesture;

namespace Business.MtgLifeCounter.Managers
{
    public class ManagerGesture
    {

        public static bool GameGestureSwipe(Widgets.Screen screen, Move move, Score score, HistoryAllGames history, TypeGesture gesture)
        {
            var refresh = false;
            var gestureReport = GetGestureReport(screen, move);
            var action = ConvertGestureToActionScore(gesture, gestureReport.TypeZone);
            if (gestureReport.TypeZone != TypeZone.NONE)
            {
                ManagerScore.ScoreUpdate(score, gestureReport.TypePlayer, history, action);
                refresh = true;
            }
            return refresh;
        }

        public static bool GameGestureSingleTap(Widgets.Screen screen, Move move, Score score, HistoryAllGames history)
        {
            var refresh = false;
            var gestureReport = GetGestureReport(screen, move);
            var action = TypeScoreAction.NONE;
            if (gestureReport.Top)
            {
                action = ConvertGestureToActionScore(TypeGesture.TOP, gestureReport.TypeZone);
            }
            else if (gestureReport.Bottom)
            {
                action = ConvertGestureToActionScore(TypeGesture.BOTTOM, gestureReport.TypeZone);
            }
            if (gestureReport.TypeZone != TypeZone.NONE && action != TypeScoreAction.NONE)
            {
                ManagerScore.ScoreUpdate(score, gestureReport.TypePlayer, history, action);
                refresh = true;
            }
            return refresh;
        }

        private static GestureReport GetGestureReport(Widgets.Screen screen, Move move)
        {
            return new GestureReport()
            {
                TypeScore = ManagerScreenScore.GetTypeScore(screen, move),
                TypeZone = ManagerScreenScore.GetTypeZone(screen, move),
                TypePlayer = ManagerScreenScore.GetTypePlayer(screen, move),
                Top = ManagerScreenScore.GestureInScoreTop(screen, move),
                Bottom = ManagerScreenScore.GestureInScoreBottom(screen, move),
                Left = ManagerScreenScore.GestureInScoreLeft(screen, move),
                Right = ManagerScreenScore.GestureInScoreRight(screen, move)
            };
        }

        public static TypeScoreAction ConvertGestureToActionScore(TypeGesture gesture, TypeZone zone)
        {
            var action = TypeScoreAction.NONE;
            if (zone == TypeZone.PLAYER)
            {
                action = Config.GesturesActions[gesture];
            }
            if (zone == TypeZone.OPPONENT)
            {
                action = GetOppositeAction(Config.GesturesActions[gesture]);
            }
            return action;
        }

        public static TypeScoreAction GetOppositeAction(TypeScoreAction action)
        {
            var oppositeAction = TypeScoreAction.NONE;
            switch(action)
            {
                case TypeScoreAction.UP_ONE:
                    oppositeAction = TypeScoreAction.DOWN_ONE;
                    break;
                case TypeScoreAction.DOWN_ONE:
                    oppositeAction = TypeScoreAction.UP_ONE;
                    break;
                case TypeScoreAction.UP_MULTIPLE:
                    oppositeAction = TypeScoreAction.DOWN_MULTIPLE;
                    break;
                case TypeScoreAction.DOWN_MULTIPLE:
                    oppositeAction = TypeScoreAction.UP_MULTIPLE;
                    break;
                case TypeScoreAction.DOUBLE:
                    oppositeAction = TypeScoreAction.HALF;
                    break;
                case TypeScoreAction.HALF:
                    oppositeAction = TypeScoreAction.DOUBLE;
                    break;
            }
            return oppositeAction;
        }

    }
}