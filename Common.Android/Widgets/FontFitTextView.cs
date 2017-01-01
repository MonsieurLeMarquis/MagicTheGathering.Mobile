using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Widget;
using Java.Lang;

namespace Common.Android.Widgets
{
    public class FontFitTextView : TextView
    {

        public int FONT_SIZE = 10;
        public double PERCENT_SIZE = 0.8d;
        public int ZONE_HEIGHT = 100;
        public int ZONE_WIDTH = 100;
        public Context _context;

        public FontFitTextView(Context context, int height, int width, int fontSize = 100, double percentSize = 0.75d) : base(context)
        {
            FONT_SIZE = fontSize;
            PERCENT_SIZE = percentSize;
            ZONE_HEIGHT = height;
            ZONE_WIDTH = width;
            _context = context;
            initialise();
        }

        /*
        public FontFitTextView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            _context = context;
            initialise();
        }
        */

        private void initialise()
        {
            mTestPaint = new Paint();
            mTestPaint.Set(Paint);
            //max size defaults to the initially specified text size unless it is too small
        }

        /* Re size the font so the specified text fits in the text box
         * assuming the text box is the specified width.
         */
        private void refitText(string text, int textWidth)
        {

            if (textWidth <= 0)
                return;
            int targetWidth = (int) (textWidth * PERCENT_SIZE);
            int sizeTemp = 1;
            FONT_SIZE = 1;

            mTestPaint.Set(Paint);
            mTestPaint.TextSize = sizeTemp;

            while (targetWidth > (mTestPaint.MeasureText(text) * _context.Resources.DisplayMetrics.Density))
            {
                FONT_SIZE = sizeTemp;
                sizeTemp += 1;
                mTestPaint.TextSize = sizeTemp;
            }

            // Ajustement pour les textes affichés dans un rectangle
            if (text.Length < (ZONE_WIDTH / ZONE_HEIGHT))
            {
                FONT_SIZE = FONT_SIZE * ZONE_HEIGHT / ZONE_WIDTH;
            }

            // Use lo so that we undershoot rather than overshoot
            this.SetTextSize(ComplexUnitType.Sp, FONT_SIZE);

        }

        // Re size the font so the specified text fits in the text box
        // assuming the text box is the specified width.
        /*
        public int calculateFontSize(string text, int textWidth)
        {

            if (textWidth <= 0)
                return 0;
            int targetWidth = (int)(textWidth * 0.75f);
            int sizeTemp = 1;
            FONT_SIZE = 1;

            mTestPaint.Set(Paint);

            while (targetWidth > mTestPaint.MeasureText(text))
            {
                FONT_SIZE = sizeTemp;
                sizeTemp += 1;
                mTestPaint.TextSize = sizeTemp;
            }
            // Use lo so that we undershoot rather than overshoot
            this.SetTextSize(ComplexUnitType.Sp, FONT_SIZE);

            return FONT_SIZE;

        }
        */

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            int parentWidth = MeasureSpec.GetSize(widthMeasureSpec);
            int height = MeasuredHeight;
            refitText(Text, parentWidth);
            this.SetMeasuredDimension(parentWidth, height);
        }
        
        protected override void OnTextChanged(ICharSequence text, int start, int before, int after)
        {
            refitText(text.ToString(), Width);
        }
        
        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            if (w != oldw)
            {
                refitText(Text, w);
            }
        }

        //Attributes
        private Paint mTestPaint;
}
}