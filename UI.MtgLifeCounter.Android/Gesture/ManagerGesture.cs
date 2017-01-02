using Android.App;
using Android.Views;

namespace UI.MtgLifeCounter.Android.Gesture
{
    public class ManagerGesture
    {

        public GestureDetector GestureDetector { get; set; }
        public GestureListener GestureListener { get; set; }

        public ManagerGesture(Activity activity, System.Action gestureLeft, System.Action gestureRight, System.Action gestureUp, System.Action gestureDown, System.Action singleTap)
        {
            GestureListener = new GestureListener();
            GestureListener.LeftEvent += gestureLeft; 
            GestureListener.RightEvent += gestureRight;
            GestureListener.DownEvent += gestureDown;
            GestureListener.UpEvent += gestureUp;
            GestureListener.SingleTapEvent += singleTap;
            GestureDetector = new GestureDetector(activity, GestureListener);
        }

    }
}