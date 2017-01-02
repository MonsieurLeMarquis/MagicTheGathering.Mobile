using Business.MtgLifeCounter.Widgets;

namespace Business.MtgLifeCounter.Managers
{
    public class ManagerScreen
    {

        public static bool IsValid(Screen screen)
        {
            return screen != null 
                && screen.ZoneOpponent != null 
                && screen.ZonePlayer != null
                && screen.ZoneOpponent.ScoreOpponent != null
                && screen.ZoneOpponent.ScorePlayer != null
                && screen.ZonePlayer.ScoreOpponent != null
                && screen.ZonePlayer.ScorePlayer != null
                && screen.ZoneOpponent.NameOpponent != null
                && screen.ZoneOpponent.NamePlayer != null
                && screen.ZonePlayer.NameOpponent != null
                && screen.ZonePlayer.NamePlayer != null;
        }

        public static Position GetPosition_ZoneOpponent_ScoreOpponent(Screen screen)
        {
            return new Position()
            {
                X = IsValid(screen) ?
                    screen.X_Relative + screen.ZoneOpponent.X_Relative + screen.ZoneOpponent.ScoreOpponent.X_Relative
                    : 0,
                Y = IsValid(screen) ?
                    screen.Y_Relative + screen.ZoneOpponent.Y_Relative + screen.ZoneOpponent.ScoreOpponent.Y_Relative
                    : 0
            };
        }

        public static Position GetPosition_ZoneOpponent_ScorePlayer(Screen screen)
        {
            return new Position()
            {
                X = IsValid(screen) ?
                    screen.X_Relative + screen.ZoneOpponent.X_Relative + screen.ZoneOpponent.ScorePlayer.X_Relative
                    : 0,
                Y = IsValid(screen) ?
                    screen.Y_Relative + screen.ZoneOpponent.Y_Relative + screen.ZoneOpponent.ScorePlayer.Y_Relative
                    : 0
            };
        }

        public static Position GetPosition_ZonePlayer_ScorePlayer(Screen screen)
        {
            return new Position()
            {
                X = IsValid(screen) ?
                    screen.X_Relative + screen.ZonePlayer.X_Relative + screen.ZonePlayer.ScorePlayer.X_Relative
                    : 0,
                Y = IsValid(screen) ?
                    screen.Y_Relative + screen.ZonePlayer.Y_Relative + screen.ZonePlayer.ScorePlayer.Y_Relative
                    : 0
            };
        }

        public static Position GetPosition_ZonePlayer_ScoreOpponent(Screen screen)
        {
            return new Position()
            {
                X = IsValid(screen) ?
                    screen.X_Relative + screen.ZonePlayer.X_Relative + screen.ZonePlayer.ScoreOpponent.X_Relative
                    : 0,
                Y = IsValid(screen) ?
                    screen.Y_Relative + screen.ZonePlayer.Y_Relative + screen.ZonePlayer.ScoreOpponent.Y_Relative
                    : 0
            };
        }

        public static Position GetPosition_ZoneOpponent_NameOpponent(Screen screen)
        {
            return new Position()
            {
                X = IsValid(screen) ?
                    screen.X_Relative + screen.ZoneOpponent.X_Relative + screen.ZoneOpponent.NameOpponent.X_Relative
                    : 0,
                Y = IsValid(screen) ?
                    screen.Y_Relative + screen.ZoneOpponent.Y_Relative + screen.ZoneOpponent.NameOpponent.Y_Relative
                    : 0
            };
        }

        public static Position GetPosition_ZoneOpponent_NamePlayer(Screen screen)
        {
            return new Position()
            {
                X = IsValid(screen) ?
                    screen.X_Relative + screen.ZoneOpponent.X_Relative + screen.ZoneOpponent.NamePlayer.X_Relative
                    : 0,
                Y = IsValid(screen) ?
                    screen.Y_Relative + screen.ZoneOpponent.Y_Relative + screen.ZoneOpponent.NamePlayer.Y_Relative
                    : 0
            };
        }

        public static Position GetPosition_ZonePlayer_NamePlayer(Screen screen)
        {
            return new Position()
            {
                X = IsValid(screen) ?
                    screen.X_Relative + screen.ZonePlayer.X_Relative + screen.ZonePlayer.NamePlayer.X_Relative
                    : 0,
                Y = IsValid(screen) ?
                    screen.Y_Relative + screen.ZonePlayer.Y_Relative + screen.ZonePlayer.NamePlayer.Y_Relative
                    : 0
            };
        }

        public static Position GetPosition_ZonePlayer_NameOpponent(Screen screen)
        {
            return new Position()
            {
                X = IsValid(screen) ?
                    screen.X_Relative + screen.ZonePlayer.X_Relative + screen.ZonePlayer.NameOpponent.X_Relative
                    : 0,
                Y = IsValid(screen) ?
                    screen.Y_Relative + screen.ZonePlayer.Y_Relative + screen.ZonePlayer.NameOpponent.Y_Relative
                    : 0
            };
        }

    }
}