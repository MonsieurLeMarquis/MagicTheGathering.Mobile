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

        public string REFERENCE_CHAR = "X";

        public int _previousSizeFont = 0;
        public string _previousText = "";

        public FontFitTextView(Context context, int height, int width, int fontSize = 100, double percentSize = 0.75d) : base(context)
        {
            FONT_SIZE = fontSize;
            PERCENT_SIZE = percentSize;
            ZONE_HEIGHT = height;
            ZONE_WIDTH = width;
            _context = context;
            initialise();
        }

        private void initialise()
        {
            mTestPaint = new Paint();
            mTestPaint.Set(Paint);
            //max size defaults to the initially specified text size unless it is too small
        }
        
        private void refitText(string text, int textWidth)
        {

            if (!string.IsNullOrEmpty(text))
            {
                // Treatment only if text change
                if(text != _previousText)
                {

                    if (!IsTextCalibrage(text))
                    {
                        // First : recall function with ref text
                        _previousText = text;
                        Text = ConvertTextToTextReference(text);
                    }
                    else
                    {
                        // Second : calibrage text size with ref text
                        calibrateTextSize(text, ZONE_WIDTH);
                        Text = _previousText;
                    }

                }
                else
                {
                    // Third : set the right font size
                    SetTextSize(ComplexUnitType.Sp, _previousSizeFont);
                }
                
            }

        }

        protected void calibrateTextSize(string text, int textWidth)
        {
            if (textWidth <= 0)
                return;
            int targetWidth = (int)(textWidth * PERCENT_SIZE);
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

            _previousSizeFont = FONT_SIZE;

            // Use lo so that we undershoot rather than overshoot
            SetTextSize(ComplexUnitType.Sp, FONT_SIZE);

            /*
            Rect result = new Rect();
            string test = "test";
            mTestPaint.GetTextBounds(test, 0, test.Length, result);

            var testX = result.Width() * _context.Resources.DisplayMetrics.Density;
            var textY = result.Height() * _context.Resources.DisplayMetrics.Density;
            */

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

        protected string ConvertTextToTextReference(string text)
        {
            var result = "";
            for (var index = 0; index < text.Length; index++)
            {
                result += REFERENCE_CHAR;
            }
            return result;
        }

        protected bool IsTextCalibrage(string text)
        {
            return !string.IsNullOrEmpty(text) && text.Replace(REFERENCE_CHAR, "").Length == 0;
        }

        //Attributes
        private Paint mTestPaint;
}
}