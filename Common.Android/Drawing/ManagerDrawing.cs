using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using Common.Android.Widgets;

namespace Common.Android.Drawing
{
    public class ManagerDrawing
    {

        #region TEXTVIEW

        public static FontFitTextView DrawFontFitTextView(int height, int width, Activity activity)
        {
            var textView = new FontFitTextView(activity, height, width);
            var background = new ShapeDrawable();
            textView.Background = background;
            textView.Gravity = GravityFlags.CenterVertical | GravityFlags.CenterHorizontal;
            return textView;
        }

        public static TextView DrawTextView(Activity activity)
        {
            var textView = new TextView(activity);
            var background = new ShapeDrawable();
            textView.Background = background;
            textView.Gravity = GravityFlags.CenterVertical | GravityFlags.CenterHorizontal;
            return textView;
        }

        public static void SetText(TextView textView, string text, int fontSize = 0)
        {
            if (textView != null)
            {
                textView.Text = text;
                if (!(textView is FontFitTextView) && fontSize > 0)
                {
                    textView.TextSize = fontSize;
                }
            }
        }

        public static void SetFontColor(TextView textView, Color fontColor)
        {
            if (textView != null && fontColor != null)
            {
                textView.SetTextColor(fontColor);
            }
        }

        public static void SetFont(TextView textView, string font, Activity activity)
        {
            var typeFace = Typeface.CreateFromAsset(activity.Assets, font);
            textView.Typeface = typeFace;
        }

        public static void ShowTextView(TextView textView, int height, int width, int x, int y, FrameLayout frameLayout)
        {
            if (textView != null && frameLayout != null)
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
            }
        }

        public static void SetTheme(TextView textView, ThemeDrawable theme)
        {
            var shape = new GradientDrawable();
            shape.SetShape(theme.ShapeType);
            shape.SetCornerRadii(new float[] 
                {
                    theme.CornerRadius,
                    theme.CornerRadius,
                    theme.CornerRadius,
                    theme.CornerRadius,
                    theme.CornerRadius,
                    theme.CornerRadius,
                    theme.CornerRadius,
                    theme.CornerRadius
                }
            );
            shape.SetColor(theme.BackgroundColor);
            shape.SetStroke(theme.BorderSize, theme.BorderColor);
            shape.SetAlpha(theme.Alpha);
            textView.Background = shape;
        }

        #endregion

        #region IMAGEVIEW

        public static ImageView DrawImageView(int image, Activity activity)
        {
            ImageView imageView = new ImageView(activity);
            imageView.SetImageResource(image);
            return imageView;
        }

        public static void ShowImageView(ImageView imageView, int width, int height, int x, int y, FrameLayout frameLayout)
        {
            var layoutParams = new FrameLayout.LayoutParams(width, height)
            {
                LeftMargin = x,
                TopMargin = y,
                Gravity = GravityFlags.Top | GravityFlags.Left,
                Height = height,
                Width = width,
            };
            imageView.LayoutParameters = layoutParams;
            frameLayout.AddView(imageView);            
        }

        #endregion

    }
}