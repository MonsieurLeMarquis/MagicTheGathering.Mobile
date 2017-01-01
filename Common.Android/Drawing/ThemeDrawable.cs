using Android.Graphics;
using Android.Graphics.Drawables;

namespace Common.Android.Drawing
{
    public class ThemeDrawable
    {
        public ShapeType ShapeType { get; set; }
        public int BorderSize { get; set; }
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }
        public int Alpha { get; set; }
        public int CornerRadius { get; set; }
    }
}