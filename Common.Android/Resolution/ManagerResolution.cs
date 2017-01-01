using Android.App;
using Android.Graphics;

namespace Common.Android.Resolution
{

    public class ManagerResolution
    {

        private static Point GetRealScreenSize(Activity activity)
        {
            var size = new Point();
            activity.WindowManager.DefaultDisplay.GetRealSize(size);
            return size;
        }

        public static int PixelsHeight(Activity activity)
        {
            return GetRealScreenSize(activity).Y;
        }

        public static int PixelsWidth(Activity activity)
        {
            return GetRealScreenSize(activity).X;
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