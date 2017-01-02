using Android.App;
using Business.MtgLifeCounter.Constants;
using Business.MtgLifeCounter.Widgets;
using Common.Android.Drawing;
using Common.Android.Resolution;

namespace Business.MtgLifeCounter.Managers
{
    public class ManagerWidgets
    {

        public static Screen CreateWidgets(Activity activity)
        {
            var height = ManagerResolution.PixelsHeight(activity);
            var width = ManagerResolution.PixelsWidth(activity);
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
                ScorePlayer = CreateScore(activity, height, width, opponent, false),
                NameOpponent = CreatePlayerName(activity, height, width, opponent, true),
                NamePlayer = CreatePlayerName(activity, height, width, opponent, false)
            };
        }

        private static Score CreateScore(Activity activity, int height, int width, bool zoneOpponent, bool scoreOpponent)
        {
            var size = ManagerSize.GetOptimalSize(Const.SCORE_SIZE_SCREEN_PERCENTAGE, height, width);
            var margin_x = (width - (size * 2)) / 3;
            var margin_y = (height - size) / 2;
            return new Score()
            {
                Width = size,
                Height = size,
                X_Relative = (zoneOpponent == scoreOpponent) ? margin_x : size + (margin_x * 2),
                Y_Relative = margin_y,
                Widget = ManagerDrawing.DrawFontFitTextView(size, size, activity)
            };
        }

        private static PlayerName CreatePlayerName(Activity activity, int height, int width, bool zoneOpponent, bool scoreOpponent)
        {
            var sizeScore = ManagerSize.GetOptimalSize(Const.SCORE_SIZE_SCREEN_PERCENTAGE, height, width);
            var heightName = (height - sizeScore) / 4;
            var margin_x = (width - (sizeScore * 2)) / 3;
            var margin_y = ((height - sizeScore) / 2) - heightName;
            return new PlayerName()
            {
                Width = sizeScore,
                Height = heightName,
                X_Relative = (zoneOpponent == scoreOpponent) ? margin_x : sizeScore + (margin_x * 2),
                Y_Relative = zoneOpponent ? margin_y : ((height - sizeScore) / 2) + sizeScore,
                Widget = ManagerDrawing.DrawFontFitTextView(heightName, sizeScore, activity)
            };
        }

    }
}