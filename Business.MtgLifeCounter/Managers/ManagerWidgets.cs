using Android.App;
using Business.MtgLifeCounter.Constants;
using Business.MtgLifeCounter.Objects;
using Common.Android.Resolution;

namespace Business.MtgLifeCounter.Managers
{
    public class ManagerWidgets
    {

        public static Screen CreateWidgets(Activity activity)
        {
            var height = ManagerScreen.PixelsHeight(activity);
            var width = ManagerScreen.PixelsWidth(activity);
            return new Screen()
            {
                ZonePlayer = CreateZonePlayer(activity, height / 2, width, false),
                ZoneOpponent = CreateZonePlayer(activity, height / 2, width, true)
            };
        }

        private static ZonePlayer CreateZonePlayer(Activity activity, int height, int width, bool opponent)
        {
            return new ZonePlayer()
            {
                Width = width,
                Height = height,
                X_Relative = 0,
                Y_Relative = opponent ? 0 : height,
                ScoreOpponent = CreateScore(activity, height, width, opponent, true),
                ScorePlayer = CreateScore(activity, height, width, opponent, false)
            };
        }

        private static Score CreateScore(Activity activity, int height, int width, bool zoneOpponent, bool scoreOpponent)
        {
            var size = ManagerSize.GetOptimalSize(Const.SCORE_SIZE_SCREEN_PERCENTAGE, height, width);
            var margin_x = ((width / 2) - size) / 2;
            var margin_y = (height - size) / 2;
            return new Score()
            {
                Width = size,
                Height = size,
                X_Relative = (zoneOpponent == scoreOpponent) ? margin_x : (width / 2) + margin_x,
                Y_Relative = zoneOpponent ? margin_y : (height / 2) + margin_y
            };
        }

    }
}