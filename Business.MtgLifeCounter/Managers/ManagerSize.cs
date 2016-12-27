using Android.App;
using Common.Android.Resolution;

namespace Business.MtgLifeCounter.Managers
{
    public class ManagerSize
    {

        public static int GetOptimalSize(double sizePercentage, Activity activity)
        {
            return GetOptimalSize(sizePercentage, ManagerScreen.PixelsHeight(activity), ManagerScreen.PixelsWidth(activity));
        }

        public static int GetOptimalSize(double sizePercentage, int height, int width)
        {
            sizePercentage = sizePercentage > 1 ? 1 : sizePercentage;
            sizePercentage = sizePercentage < 0 ? 0 : sizePercentage;
            var sizeHeight = (int)(height * sizePercentage);
            var sizeWidth = (int)(width * sizePercentage);
            return sizeHeight < sizeWidth ? sizeHeight : sizeWidth;
        }

    }
}