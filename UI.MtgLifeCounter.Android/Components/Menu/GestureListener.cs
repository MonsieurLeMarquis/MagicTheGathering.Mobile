using System;
using Android.Views;

namespace UI.MtgLifeCounter.Android.Components.Menu
{

	public class GestureListener: Java.Lang.Object, GestureDetector.IOnGestureListener
	{

        private class Move
        {

            private MotionEvent start { get; set; }
            private MotionEvent end { get; set; }
            private float velocityX { get; set; }
            private float velocityY { get; set; }

            private const int MOVE_LENGTH_MIN = 200;
            private const int MOVE_RATIO_X_Y_MIN = 10;
            private const int SWIPE_THRESHOLD_VELOCITY = 200;

            public Move(MotionEvent meStart, MotionEvent meEnd, float fVelocityX, float fVelocityY)
            {
                start = meStart;
                end = meEnd;
                velocityX = fVelocityX;
                velocityY = fVelocityY;
            }

            public float DiffX
            {
                get
                {
                    return start != null && end != null ? end.GetX() - start.GetX() : 0f;
                }
            }

            public float DiffY
            {
                get
                {
                    return start != null && end != null ? end.GetY() - start.GetY() : 0f;
                }
            }

            public bool IsLine
            {
                get
                {
                    return DiffX >= MOVE_LENGTH_MIN | DiffY >= MOVE_LENGTH_MIN;
                }
            }

            public bool IsVertical
            {
                get
                {
                    return IsLine & ((DiffY / DiffX) > MOVE_RATIO_X_Y_MIN);
                }
            }

            public bool IsHorizontal
            {
                get
                {
                    return IsLine & ((DiffX / DiffY) > MOVE_RATIO_X_Y_MIN);
                }
            }

            public bool IsValidVelocityX
            {
                get
                {
                    return velocityX >= SWIPE_THRESHOLD_VELOCITY;
                }
            }

            public bool IsValidVelocityY
            {
                get
                {
                    return velocityY >= SWIPE_THRESHOLD_VELOCITY;
                }
            }

            public bool IsValid
            {
                get
                {
                    return IsLine & ((IsVertical & IsValidVelocityY) | (IsHorizontal & IsValidVelocityY));
                }
            }

            public bool MoveRight
            {
                get
                {
                    return IsValid ? IsHorizontal & DiffX > 0 : false;
                }
            }

            public bool MoveLeft
            {
                get
                {
                    return IsValid ? IsHorizontal & DiffX < 0 : false;
                }
            }

            public bool MoveUp
            {
                get
                {
                    return IsValid ? IsVertical & DiffY > 0 : false;
                }
            }

            public bool MoveDown
            {
                get
                {
                    return IsValid ? IsVertical & DiffY < 0 : false;
                }
            }


        }

        public event Action LeftEvent;
        public event Action RightEvent;
        public event Action UpEvent;
        public event Action DownEvent;
        public event Action SingleTapEvent;
		static int SWIPE_MAX_OFF_PATH = 250;
		static int SWIPE_MIN_DISTANCE = 100;
		static int SWIPE_THRESHOLD_VELOCITY = 200;

		public GestureListener()
		{
		}

		public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			try
			{

                var move = new Move(e1, e2, velocityX, velocityY);

                if (move.MoveRight)
                {
                    RightEvent();
                }
                else if (move.MoveLeft)
                {
                    LeftEvent();
                }
                else if (move.MoveUp)
                {
                    UpEvent();
                }
                else if (move.MoveDown)
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
			SingleTapEvent ();
			Console.WriteLine ( "Single tap up" );
			return true;
		}

	}

}