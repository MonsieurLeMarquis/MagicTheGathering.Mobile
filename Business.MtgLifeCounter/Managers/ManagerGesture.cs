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
        
        public static GestureReport GameGesture(Widgets.Screen screen, Move move, Score score, HistoryAllGames history)
        {
            var gestureReport = GetGestureReport(screen, move);
            var action = ConvertGestureToActionScore(gestureReport);
            if (gestureReport.TypeZone != TypeZone.NONE && action != TypeScoreAction.NONE)
            {
                ManagerScore.ScoreUpdate(score, gestureReport.TypePlayer, history, action);
            }
            return gestureReport;
        }

        private static GestureReport GetGestureReport(Widgets.Screen screen, Move move)
        {
            var typeGesture = TypeGesture.NONE;

            if (move.IsLine)
            {
                if (move.MoveUp)
                {
                    typeGesture = TypeGesture.SWIPE_UP;
                }
                else if (move.MoveDown)
                {
                    typeGesture = TypeGesture.SWIPE_DOWN;
                }
                else if (move.MoveLeft)
                {
                    typeGesture = TypeGesture.SWIPE_LEFT;
                }
                else if (move.MoveRight)
                {
                    typeGesture = TypeGesture.SWIPE_RIGHT;
                }
            }
            else if (move.IsPoint)
            {
                if (ManagerScreenScore.GestureInScoreTop(screen, move))
                {
                    typeGesture = TypeGesture.TAP_TOP;
                }
                else if (ManagerScreenScore.GestureInScoreBottom(screen, move))
                {
                    typeGesture = TypeGesture.TAP_BOTTOM;
                }
                /*
                else if (ManagerScreenScore.GestureInScoreLeft(screen, move))
                {
                    typeGesture = TypeGesture.TAP_LEFT;
                }
                else if (ManagerScreenScore.GestureInScoreRight(screen, move))
                {
                    typeGesture = TypeGesture.TAP_RIGHT;
                }
                */
            }

            return new GestureReport()
            {
                TypeScore = ManagerScreenScore.GetTypeScore(screen, move),
                TypeZone = ManagerScreenScore.GetTypeZone(screen, move),
                TypePlayer = ManagerScreenScore.GetTypePlayer(screen, move),
                TypeGesture = typeGesture
            };
        }

        private static TypeScoreAction ConvertGestureToActionScore(GestureReport gestureReport)
        {
            var action = TypeScoreAction.NONE;
            if (gestureReport.TypeGesture != TypeGesture.NONE)
            {
                if (gestureReport.TypeZone == TypeZone.PLAYER)
                {
                    action = Config.GesturesActions[gestureReport.TypeGesture];
                }
                if (gestureReport.TypeZone == TypeZone.OPPONENT)
                {
                    action = GetOppositeAction(Config.GesturesActions[gestureReport.TypeGesture]);
                }
            }
            return action;
        }

        private static TypeScoreAction GetOppositeAction(TypeScoreAction action)
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