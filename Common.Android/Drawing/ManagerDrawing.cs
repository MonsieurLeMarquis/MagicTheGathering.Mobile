using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;

namespace Common.Android.Drawing
{
    public class ManagerDrawing
    {
            
        public static TextView DrawTextView(Activity activity)
        {
            TextView textView = new TextView(activity);
            var background = new ShapeDrawable();
            textView.Background = background;
            textView.Gravity = GravityFlags.CenterVertical | GravityFlags.CenterVertical;            
            return textView;
        }

        public static TextView SetText(TextView textView, string text, int fontSize, Color fontColor)
        {
            textView.Text = text;
            textView.TextSize = fontSize;
            textView.SetTextColor(fontColor);
            return textView;
        }

        public static void ShowTextView(TextView textView, int width, int height, int x, int y, FrameLayout frameLayout)
        {
            var layoutParams = new FrameLayout.LayoutParams(width, height)
            {
                LeftMargin = x,
                TopMargin = y,
                Gravity = GravityFlags.Top | GravityFlags.Left,
                Height = height,
                Width = width
            };
            textView.LayoutParameters = layoutParams;
            frameLayout.AddView(textView);
            /*
	            params.leftMargin = x;
	            params.topMargin = y;  	
	            params.gravity = Gravity.TOP | Gravity.LEFT;
	            params.setMargins(x, y, 0, 0);
                bBouton.setLayoutParams(params);
                ((FrameLayout)activity.findViewById(R.id.mainLayout)).addView(bBouton);
            */
        }

    }
}