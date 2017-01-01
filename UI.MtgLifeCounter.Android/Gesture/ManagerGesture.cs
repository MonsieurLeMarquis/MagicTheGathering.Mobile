using Android.App;
using Android.Views;
using UI.MtgLifeCounter.Android.Components.Menu;

namespace UI.MtgLifeCounter.Android.Gesture
{
    public class ManagerGesture
    {

        public GestureDetector GestureDetector { get; set; }
        public GestureListener GestureListener { get; set; }

        public ManagerGesture(Activity activity)
        {
            GestureListener = new GestureListener();
            GestureListener.LeftEvent += GestureLeft; 
            GestureListener.RightEvent += GestureRight;
            GestureListener.DownEvent += GestureDown;
            GestureListener.UpEvent += GestureUp;
            GestureListener.SingleTapEvent += SingleTap;
            GestureDetector = new GestureDetector(activity, GestureListener);
        }

        protected void GestureLeft()
        {
            var test = "";
        }

        protected void GestureRight()
        {
            var test = "";
        }

        protected void GestureUp()
        {
            var test = "";
        }

        protected void GestureDown()
        {
            var test = "";
        }

        protected void SingleTap()
        {
            var test = "";
        }

    }
}