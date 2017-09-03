using Android.OS;
using Android.Views;
using UI.MtgLifeCounter.Android.Components.Menu;
using AndroidGesture = Common.Android.Gesture;
using static Business.MtgLifeCounter.Enumerations.Enum;
using UI.MtgLifeCounter.Android.Fragments;
using Business.MtgLifeCounter.Context;
using Business.MtgLifeCounter.Managers;

namespace UI.MtgLifeCounter.Android.Activities
{

    public class GestureActivity : BaseActivityMenu
    {

        private AndroidGesture.ManagerGesture _managerGesture;
        private bool _enableGesture = true;

        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            InitializeGesture();
        }

        private void InitializeGesture()
        {
            _managerGesture = new AndroidGesture.ManagerGesture(this, GameGestureLeft, GameGestureRight, GameGestureUp, GameGestureDown, GameSingleTap);
        }
        
        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            _managerGesture.GestureDetector.OnTouchEvent(ev);
            return base.DispatchTouchEvent(ev);
        }
   
        protected bool IsActionMenu()
        {
            return MtgLifeCounterContext.Screen != null && ManagerScreenScore.GetTypeScore(MtgLifeCounterContext.Screen, _managerGesture.GestureListener.LastMove) == TypeScore.NONE;
        }

        protected void GameGestureLeft()
        {
            if (IsActionMenu())
            {
                GestureMenuGestureLeft();
            }
            else
            {
                ApplyGesture();
            }
        }

        protected void GameGestureRight()
        {
            if (IsActionMenu())
            {
                GestureMenuGestureRight();
            }
            else
            {
                ApplyGesture();
            }
        }

        protected void GameGestureUp()
        {
            if (!IsActionMenu())
            {
                ApplyGesture();
            }
        }

        protected void GameGestureDown()
        {
            if (!IsActionMenu())
            {
                ApplyGesture();
            }
        }

        protected void GameSingleTap()
        {
            if (IsActionMenu())
            {
                GestureMenuSingleTap();
            }
            else
            {
                ApplyGesture();
            }
        }

        protected void ApplyGesture()
        {
            if (CurrentFragment == typeof(MainFragment))
            {
                var reportGesture = MainFragment.ApplyGesture(_managerGesture.GestureListener.LastMove);
                MainFragment.RefreshScore(reportGesture);
            }
        }

    }
}


