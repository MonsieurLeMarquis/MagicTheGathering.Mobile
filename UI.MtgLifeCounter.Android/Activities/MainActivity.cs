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
using UI.MtgLifeCounter.Android.Gesture;

namespace UI.MtgLifeCounter.Android.Activities
{
	
	[Activity (Label = "MtgLifeCounter", MainLauncher = false, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait, Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]
	public class MainActivity : BaseActivityMenu
    {
      
        private FrameLayout _frameLayout;
        private ManagerGesture _managerGesture;
        private Screen _screen;
        private ImageView _imageOpponent;
        private ImageView _imagePlayer;

        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            ManagerActivity.SetFullScreen(this);
            SetContentView (Resource.Layout.Activity_Main);
            InitializeMenu();
            InitializeGesture();
            InitializeScreen();
            DrawScreen();
        }

        #region INITIALIZATION

        private void InitializeMenu()
        {
            InitializeMenu(ResourcesMenu.ListMenuItems(this));
        }

        private void InitializeScreen()
        {
            _frameLayout = FindViewById<FrameLayout>(Resource.Id.frame_main);
            _screen = ManagerWidgets.CreateWidgets(this);
            _imageOpponent = Common.Android.Drawing.ManagerDrawing.DrawImageView(Resource.Drawable.wallpaper_opponent, this);
            _imagePlayer = Common.Android.Drawing.ManagerDrawing.DrawImageView(Resource.Drawable.wallpaper_player, this);
        }

        private void InitializeGesture()
        {
            _managerGesture = new ManagerGesture(this);
        }

        #endregion

        #region DRAW SCREEN

        public void DrawScreen()
        {
            Common.Android.Drawing.ManagerDrawing.ShowImageView(_imageOpponent, ManagerResolution.PixelsWidth(this), ManagerResolution.PixelsHeight(this) / 2, 0, 0, _frameLayout);
            Common.Android.Drawing.ManagerDrawing.ShowImageView(_imagePlayer, ManagerResolution.PixelsWidth(this), ManagerResolution.PixelsHeight(this) / 2, 0, ManagerResolution.PixelsHeight(this) / 2, _frameLayout);
            ManagerDrawing.DrawScreen(_screen, _frameLayout, this);
        }

        #endregion

        #region GESTURE LISTENER

        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            _managerGesture.GestureDetector.OnTouchEvent(ev);
            return base.DispatchTouchEvent(ev);
        }        

        #endregion

    }
}


