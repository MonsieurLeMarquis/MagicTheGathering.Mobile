using Android.Views;
using Java.Lang;

namespace UI.MtgLifeCounter.Android.Gesture
{
    public class Move
    {

        private MotionEvent start { get; set; }
        private MotionEvent end { get; set; }
        private float velocityX { get; set; }
        private float velocityY { get; set; }

        private const int MOVE_LENGTH_MIN = 200;
        private const int MOVE_RATIO_X_Y_MIN = 4;
        private const int SWIPE_THRESHOLD_VELOCITY = 100;

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
                return Math.Abs(DiffX) >= MOVE_LENGTH_MIN | Math.Abs(DiffY) >= MOVE_LENGTH_MIN;
            }
        }

        public bool IsVertical
        {
            get
            {
                return IsLine & (Math.Abs(DiffY / DiffX) > MOVE_RATIO_X_Y_MIN);
            }
        }

        public bool IsHorizontal
        {
            get
            {
                return IsLine & (Math.Abs(DiffX / DiffY) > MOVE_RATIO_X_Y_MIN);
            }
        }

        public bool IsValidVelocityX
        {
            get
            {
                return Math.Abs(velocityX) >= SWIPE_THRESHOLD_VELOCITY;
            }
        }

        public bool IsValidVelocityY
        {
            get
            {
                return Math.Abs(velocityY) >= SWIPE_THRESHOLD_VELOCITY;
            }
        }

        public bool IsValid
        {
            get
            {
                return IsLine & ((IsVertical & IsValidVelocityY) | (IsHorizontal & IsValidVelocityX));
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
                return IsValid ? IsVertical & DiffY < 0 : false;
            }
        }

        public bool MoveDown
        {
            get
            {
                return IsValid ? IsVertical & DiffY > 0 : false;
            }
        }


    }
}