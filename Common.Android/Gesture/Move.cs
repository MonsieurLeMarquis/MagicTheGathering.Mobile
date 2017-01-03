using Android.Views;
using Java.Lang;

namespace Common.Android.Gesture
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

        public Move()
        {
            start = null;
            end = null;
            velocityX = 0;
            velocityY = 0;
        }

        public Move(MotionEvent move)
        {
            start = move;
            end = move;
            velocityX = 0;
            velocityY = 0;
        }

        public Move(MotionEvent meStart, MotionEvent meEnd, float fVelocityX, float fVelocityY)
        {
            start = meStart;
            end = meEnd;
            velocityX = fVelocityX;
            velocityY = fVelocityY;
        }

        private float X(MotionEvent motion)
        {
            return motion != null ? motion.GetX() : 0;
        }

        private float Y(MotionEvent motion)
        {
            return motion != null ? motion.GetY() : 0;
        }

        public float CenterX
        {
            get
            {
                return (X(start) + X(end)) / 2;
            }
        }

        public float CenterY
        {
            get
            {
                return (Y(start) + Y(end)) / 2;
            }
        }

        public float DiffX
        {
            get
            {
                return start != null && end != null ? X(end) - X(start) : 0f;
            }
        }

        public float DiffY
        {
            get
            {
                return start != null && end != null ? Y(end) - Y(start) : 0f;
            }
        }

        public bool IsPoint
        {
            get
            {
                return DiffX == 0 && DiffY == 0 && velocityX == 0 && velocityY == 0;
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