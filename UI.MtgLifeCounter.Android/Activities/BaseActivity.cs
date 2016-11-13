using Android.App;
using Android.OS;
using Common.Android.Activities;
using Android.Views;
using Java.Lang;
using Android.Widget;

namespace UI.MtgLifeCounter.Android.Activities
{
	
    public class BaseActivity : Activity//, GestureDetector.IOnGestureListener
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //ManagerActivity.SetFullScreen(this);
        }

        protected override void OnResume()
        {
            base.OnResume();
            ManagerActivity.ActivateKeepScreenOn(this);
        }

        protected override void OnPause()
        {
            base.OnPause();
            ManagerActivity.DisactivateKeepScreenOn(this);
        }

        /*
        #region GESTURE LISTENER

        public bool OnDown(MotionEvent e)
        {
            Toast.MakeText(this, "TEST", ToastLength.Long).Show();
            return false;
        }

        public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            return false;
        }

        public void OnLongPress(MotionEvent e)
        {
        }

        public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
            return false;
        }

        public void OnShowPress(MotionEvent e)
        {
        }

        public bool OnSingleTapUp(MotionEvent e)
        {
            return false;
        }

        #endregion
        */

    }
}


