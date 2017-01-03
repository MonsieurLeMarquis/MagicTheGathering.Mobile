using System;
using Android.Views;

namespace Common.Android.Gesture
{

	public class GestureListener: Java.Lang.Object, GestureDetector.IOnGestureListener
	{

        public event Action LeftEvent;
        public event Action RightEvent;
        public event Action UpEvent;
        public event Action DownEvent;
        public event Action SingleTapEvent;
        public Move LastMove { get; set; }
		//static int SWIPE_MAX_OFF_PATH = 250;
		//static int SWIPE_MIN_DISTANCE = 100;
		//static int SWIPE_THRESHOLD_VELOCITY = 200;

		public GestureListener()
		{
            LastMove = new Move();
		}

		public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			try
			{

                LastMove = new Move(e1, e2, velocityX, velocityY);

                if (LastMove.MoveRight)
                {
                    RightEvent();
                }
                else if (LastMove.MoveLeft)
                {
                    LeftEvent();
                }
                else if (LastMove.MoveUp)
                {
                    UpEvent();
                }
                else if (LastMove.MoveDown)
                {
                    DownEvent();
                }
                /*
                // TODO : ajouter UpEvent et DownEvent
				if ( Math.Abs ( e1.GetY () - e2.GetY () ) > SWIPE_MAX_OFF_PATH )
					return false;
				// right to left swipe
				if ( e1.GetX () - e2.GetX () > SWIPE_MIN_DISTANCE && Math.Abs ( velocityX ) > SWIPE_THRESHOLD_VELOCITY && LeftEvent != null )
				{
					RightEvent ();
				}
				else if ( e2.GetX () - e1.GetX () > SWIPE_MIN_DISTANCE && Math.Abs ( velocityX ) > SWIPE_THRESHOLD_VELOCITY && RightEvent != null )
				{
					if(e1.GetX()<100)
						LeftEvent ();
				}
                */
            }
			catch ( Exception e )
			{
				Console.WriteLine ( "Failed to work" +e.Message);
			}
			return false;
		}

		public bool OnDown(MotionEvent e)
		{
			return true;
		}

		public void OnLongPress(MotionEvent e) {}

		public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
		{
			return true;
		}

		public void OnShowPress(MotionEvent e)
		{

		}

		public bool OnSingleTapUp(MotionEvent e)
        {
            LastMove = new Move(e);
            SingleTapEvent ();
			Console.WriteLine ( "Single tap up" );
			return true;
		}

	}

}