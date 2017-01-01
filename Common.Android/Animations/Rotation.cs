using Android.Views.Animations;
using Android.Widget;

namespace Common.Android.Animations
{
    public class Rotation
    {

        public static void RotateTextView(TextView textView, int width, int height, float angle, int duration = 0, int repeatCount = 0)
        {
            var animation = new RotateAnimation(0.0f, angle, height / 2, width / 2);
            animation.Duration = duration;
            animation.RepeatCount = repeatCount;
            animation.FillAfter = true; // keep rotation after animation
            textView.Animation = animation;
        }

    }
}