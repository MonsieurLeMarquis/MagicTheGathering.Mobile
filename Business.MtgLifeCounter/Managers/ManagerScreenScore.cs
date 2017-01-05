using Business.MtgLifeCounter.Widgets;
using Common.Android.Gesture;
using static Business.MtgLifeCounter.Enumerations.Enum;

namespace Business.MtgLifeCounter.Managers
{
    public class ManagerScreenScore
    {

        public static TypeScore GetTypeScore(Screen screen, Move move)
        {
            if (GestureInScore(screen.ZoneOpponent.ScoreOpponent, ManagerScreen.GetPosition_ZoneOpponent_ScoreOpponent(screen), move))
            {
                return TypeScore.ZONE_OPPONENT_SCORE_OPPONENT;
            }
            if (GestureInScore(screen.ZoneOpponent.ScorePlayer, ManagerScreen.GetPosition_ZoneOpponent_ScorePlayer(screen), move))
            {
                return TypeScore.ZONE_OPPONENT_SCORE_PLAYER;
            }
            if (GestureInScore(screen.ZonePlayer.ScorePlayer, ManagerScreen.GetPosition_ZonePlayer_ScorePlayer(screen), move))
            {
                return TypeScore.ZONE_PLAYER_SCORE_PLAYER;
            }
            if (GestureInScore(screen.ZonePlayer.ScoreOpponent, ManagerScreen.GetPosition_ZonePlayer_ScoreOpponent(screen), move))
            {
                return TypeScore.ZONE_PLAYER_SCORE_OPPONENT;
            }
            return TypeScore.NONE;
        }

        public static TypePlayer GetTypePlayer(Screen screen, Move move)
        {
            var typePlayer = TypePlayer.NONE;
            var typeScore = GetTypeScore(screen, move);
            if (typeScore == TypeScore.ZONE_OPPONENT_SCORE_PLAYER | typeScore == TypeScore.ZONE_PLAYER_SCORE_PLAYER)
            {
                typePlayer = TypePlayer.PLAYER;
            }
            if (typeScore == TypeScore.ZONE_OPPONENT_SCORE_OPPONENT | typeScore == TypeScore.ZONE_PLAYER_SCORE_OPPONENT)
            {
                typePlayer = TypePlayer.OPPONENT;
            }
            return typePlayer;
        }

        public static TypeZone GetTypeZone(Screen screen, Move move)
        {
            var typeZone = TypeZone.NONE;
            var typeScore = GetTypeScore(screen, move);
            if (typeScore == TypeScore.ZONE_PLAYER_SCORE_PLAYER | typeScore == TypeScore.ZONE_PLAYER_SCORE_OPPONENT)
            {
                typeZone = TypeZone.PLAYER;
            }
            if (typeScore == TypeScore.ZONE_OPPONENT_SCORE_OPPONENT | typeScore == TypeScore.ZONE_OPPONENT_SCORE_PLAYER)
            {
                typeZone = TypeZone.OPPONENT;
            }
            return typeZone;
        }

        public static bool GestureInScore(Score score, Position position, Move move)
        {
            return  (move.CenterX > position.X) && (move.CenterX < position.X + score.Width) &&
                    (move.CenterY > position.Y) && (move.CenterY < position.Y + score.Height);
        }

        public static bool GestureInScoreTop(Score score, Position position, Move move)
        {
            return (move.CenterX > position.X) && (move.CenterX < position.X + score.Width) &&
                    (move.CenterY > position.Y) && (move.CenterY < position.Y + (score.Height / 2));
        }

        public static bool GestureInScoreBottom(Score score, Position position, Move move)
        {
            return (move.CenterX > position.X) && (move.CenterX < position.X + score.Width) &&
                    (move.CenterY > (position.Y + (score.Height / 2))) && (move.CenterY < position.Y + score.Height);
        }

        public static bool GestureInScoreLeft(Score score, Position position, Move move)
        {
            return (move.CenterX > position.X) && (move.CenterX < position.X + (score.Width / 2)) &&
                    (move.CenterY > position.Y) && (move.CenterY < position.Y + score.Height);
        }

        public static bool GestureInScoreRight(Score score, Position position, Move move)
        {
            return (move.CenterX > (position.X + (score.Width / 2))) && (move.CenterX < position.X + score.Width) &&
                    (move.CenterY > position.Y + score.Height) && (move.CenterY < position.Y + score.Height);
        }

        public static bool GestureInScoreTop(Screen screen, Move move)
        {
            switch (GetTypeScore(screen, move))
            {
                case TypeScore.ZONE_OPPONENT_SCORE_OPPONENT:
                    return GestureInScoreTop(screen.ZoneOpponent.ScoreOpponent, ManagerScreen.GetPosition_ZoneOpponent_ScoreOpponent(screen), move);
                case TypeScore.ZONE_OPPONENT_SCORE_PLAYER:
                    return GestureInScoreTop(screen.ZoneOpponent.ScorePlayer, ManagerScreen.GetPosition_ZoneOpponent_ScorePlayer(screen), move);
                case TypeScore.ZONE_PLAYER_SCORE_PLAYER:
                    return GestureInScoreTop(screen.ZonePlayer.ScorePlayer, ManagerScreen.GetPosition_ZonePlayer_ScorePlayer(screen), move);
                case TypeScore.ZONE_PLAYER_SCORE_OPPONENT:
                    return GestureInScoreTop(screen.ZonePlayer.ScoreOpponent, ManagerScreen.GetPosition_ZonePlayer_ScoreOpponent(screen), move);
            }
            return false;
        }

        public static bool GestureInScoreBottom(Screen screen, Move move)
        {
            switch (GetTypeScore(screen, move))
            {
                case TypeScore.ZONE_OPPONENT_SCORE_OPPONENT:
                    return GestureInScoreBottom(screen.ZoneOpponent.ScoreOpponent, ManagerScreen.GetPosition_ZoneOpponent_ScoreOpponent(screen), move);
                case TypeScore.ZONE_OPPONENT_SCORE_PLAYER:
                    return GestureInScoreBottom(screen.ZoneOpponent.ScorePlayer, ManagerScreen.GetPosition_ZoneOpponent_ScorePlayer(screen), move);
                case TypeScore.ZONE_PLAYER_SCORE_PLAYER:
                    return GestureInScoreBottom(screen.ZonePlayer.ScorePlayer, ManagerScreen.GetPosition_ZonePlayer_ScorePlayer(screen), move);
                case TypeScore.ZONE_PLAYER_SCORE_OPPONENT:
                    return GestureInScoreBottom(screen.ZonePlayer.ScoreOpponent, ManagerScreen.GetPosition_ZonePlayer_ScoreOpponent(screen), move);
            }
            return false;
        }

        public static bool GestureInScoreLeft(Screen screen, Move move)
        {
            switch (GetTypeScore(screen, move))
            {
                case TypeScore.ZONE_OPPONENT_SCORE_OPPONENT:
                    return GestureInScoreLeft(screen.ZoneOpponent.ScoreOpponent, ManagerScreen.GetPosition_ZoneOpponent_ScoreOpponent(screen), move);
                case TypeScore.ZONE_OPPONENT_SCORE_PLAYER:
                    return GestureInScoreLeft(screen.ZoneOpponent.ScorePlayer, ManagerScreen.GetPosition_ZoneOpponent_ScorePlayer(screen), move);
                case TypeScore.ZONE_PLAYER_SCORE_PLAYER:
                    return GestureInScoreLeft(screen.ZonePlayer.ScorePlayer, ManagerScreen.GetPosition_ZonePlayer_ScorePlayer(screen), move);
                case TypeScore.ZONE_PLAYER_SCORE_OPPONENT:
                    return GestureInScoreLeft(screen.ZonePlayer.ScoreOpponent, ManagerScreen.GetPosition_ZonePlayer_ScoreOpponent(screen), move);
            }
            return false;
        }

        public static bool GestureInScoreRight(Screen screen, Move move)
        {
            switch (GetTypeScore(screen, move))
            {
                case TypeScore.ZONE_OPPONENT_SCORE_OPPONENT:
                    return GestureInScoreRight(screen.ZoneOpponent.ScoreOpponent, ManagerScreen.GetPosition_ZoneOpponent_ScoreOpponent(screen), move);
                case TypeScore.ZONE_OPPONENT_SCORE_PLAYER:
                    return GestureInScoreRight(screen.ZoneOpponent.ScorePlayer, ManagerScreen.GetPosition_ZoneOpponent_ScorePlayer(screen), move);
                case TypeScore.ZONE_PLAYER_SCORE_PLAYER:
                    return GestureInScoreRight(screen.ZonePlayer.ScorePlayer, ManagerScreen.GetPosition_ZonePlayer_ScorePlayer(screen), move);
                case TypeScore.ZONE_PLAYER_SCORE_OPPONENT:
                    return GestureInScoreRight(screen.ZonePlayer.ScoreOpponent, ManagerScreen.GetPosition_ZonePlayer_ScoreOpponent(screen), move);
            }
            return false;
        }

    }
}