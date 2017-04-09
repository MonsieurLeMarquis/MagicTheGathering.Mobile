using Android.App;
using Business.MtgLifeCounter.Configuration;
using Business.MtgLifeCounter.Constants;
using Common.Android.Resolution;

namespace Business.MtgLifeCounter.Managers
{
    public class ManagerSize
    {

        public static int GetOptimalSize(double sizePercentage, Activity activity)
        {
            return GetOptimalSize(sizePercentage, ManagerResolution.PixelsHeight(activity), ManagerResolution.PixelsWidth(activity));
        }

        public static int GetOptimalSize(double sizePercentage, int height, int width)
        {
            sizePercentage = sizePercentage > 1 ? 1 : sizePercentage;
            sizePercentage = sizePercentage < 0 ? 0 : sizePercentage;
            var sizeHeight = (int)(height * sizePercentage);
            var sizeWidth = (int)(width * sizePercentage);
            return sizeHeight < sizeWidth ? sizeHeight : sizeWidth;
        }

        public static int GetOptimalFontSize(string text, int width, Activity activity)
        {
            var CALIBRAGE_TEXT_LENGTH_MAX = Const.CALIBRAGE_TEXT_LENGTH_MAX;
            var CALIBRAGE_TEXT_LENGTH_MIN = Const.CALIBRAGE_TEXT_LENGTH_MIN;
            var CalibrageTextSizeMax  = Config.CalibrageTextSizeMax;
            var CalibrageTextSizeMin = Config.CalibrageTextSizeMin;
            var CALIBRAGE_TEXT_ZONE_SIZE = Const.CALIBRAGE_TEXT_ZONE_SIZE;
            double textLengthDiff = Const.CALIBRAGE_TEXT_LENGTH_MAX - Const.CALIBRAGE_TEXT_LENGTH_MIN;
            double textSizeDiff = Config.CalibrageTextSizeMax - Config.CalibrageTextSizeMin;
            double x = textSizeDiff / textLengthDiff;
            double delta = Config.CalibrageTextSizeMax - (x * Const.CALIBRAGE_TEXT_LENGTH_MAX);
            double coeff = (double)width / (double)Const.CALIBRAGE_TEXT_ZONE_SIZE;
            double fontSize = (int)((x * text.Length + delta) * coeff);
            //fontSize /= (double)ManagerResolution.Density(activity);
            return (int)fontSize;
        } 

    }
}