using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using UI.MtgLifeCounter.Android.Components.Menu;
using Common.Android.Activities;
using Android.Content.PM;
using Business.MtgLifeCounter.Objects;
using Business.MtgLifeCounter.Managers;
using UI.MtgLifeCounter.Android.Drawings;
using Common.Android.Resolution;

namespace UI.MtgLifeCounter.Android.Activities
{
	
	[Activity (Label = "MtgLifeCounter", MainLauncher = false, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait, Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]
	public class MainActivity : BaseActivityMenu//, GestureDetector.IOnGestureListener
    {

        /*
        private GestureDetector _gestureDetector;
        */

        private FrameLayout _frameLayout;
        private Screen _screen;


        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            ManagerActivity.SetFullScreen(this);
            SetContentView (Resource.Layout.Activity_Main);
			InitializeMenu (ResourcesMenu.ListMenuItems(this));

            /*
            _gestureDetector = new GestureDetector(this);
            */

            _frameLayout = FindViewById<FrameLayout>(Resource.Id.frame_main);

            var imageOpponent = Common.Android.Drawing.ManagerDrawing.DrawImageView(Resource.Drawable.wallpaper_opponent, this);
            var imagePlayer = Common.Android.Drawing.ManagerDrawing.DrawImageView(Resource.Drawable.wallpaper_player, this);
            Common.Android.Drawing.ManagerDrawing.ShowImageView(imageOpponent, ManagerResolution.PixelsWidth(this), ManagerResolution.PixelsHeight(this) / 2, 0, 0, _frameLayout);
            Common.Android.Drawing.ManagerDrawing.ShowImageView(imagePlayer, ManagerResolution.PixelsWidth(this), ManagerResolution.PixelsHeight(this) / 2, 0, ManagerResolution.PixelsHeight(this) / 2, _frameLayout);
            
            _screen = ManagerWidgets.CreateWidgets(this);
            ManagerDrawing.DrawScreen(_screen, _frameLayout, this);

        }

        #region GESTURE LISTENER

        /*
        
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

        */

        #endregion

    }
}


