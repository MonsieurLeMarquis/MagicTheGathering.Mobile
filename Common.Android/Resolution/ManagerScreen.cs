using Android.App;

namespace Common.Android.Resolution
{

    public class ManagerScreen
    {

        public static int PixelsHeight(Activity activity)
        {
            return activity.Resources.DisplayMetrics.HeightPixels;
        }

        public static int PixelsWidth(Activity activity)
        {
            return activity.Resources.DisplayMetrics.HeightPixels;
        }

        public static int DpHeight(Activity activity)
        {
            return PixelToDp(PixelsHeight(activity), activity);
        }

        public static int DpWidth(Activity activity)
        {
            return PixelToDp(PixelsWidth(activity), activity);
        }

        public static float Density(Activity activity)
        {
            return activity.Resources.DisplayMetrics.Density;
        }

        private static int PixelToDp(int pixel, Activity activity)
        {
            return (int) (pixel / Density(activity));
        }

    }

}