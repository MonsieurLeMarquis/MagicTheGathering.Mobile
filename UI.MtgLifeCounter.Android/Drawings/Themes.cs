using Android.Graphics;
using Android.Graphics.Drawables;
using Common.Android.Drawing;

namespace UI.MtgLifeCounter.Android.Drawings
{
    public class Themes
    {

        public static ThemeDrawable Score
        {
            get
            {
                return new ThemeDrawable()
                {
                    Alpha = 128,
                    BackgroundColor = new Color(128, 128, 128),
                    BorderColor = new Color(255, 255, 255),
                    BorderSize = 10,
                    CornerRadius = 20,
                    ShapeType = ShapeType.Rectangle
                };
            }
        }

        public static ThemeDrawable PlayerName
        {
            get
            {
                return new ThemeDrawable()
                {
                    Alpha = 0,
                    BackgroundColor = new Color(0, 0, 0),
                    BorderColor = new Color(0, 0, 0),
                    BorderSize = 0,
                    CornerRadius = 0,
                    ShapeType = ShapeType.Rectangle
                };
            }
        }

    }
}