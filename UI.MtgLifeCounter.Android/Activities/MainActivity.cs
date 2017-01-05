using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using UI.MtgLifeCounter.Android.Components.Menu;
using Common.Android.Activities;
using Android.Content.PM;
using Business.MtgLifeCounter.Widgets;
using GameManagers = Business.MtgLifeCounter.Managers;
using UI.MtgLifeCounter.Android.Drawings;
using Common.Android.Resolution;
using AndroidGesture = Common.Android.Gesture;
using Game = Business.MtgLifeCounter.Game;
using Business.MtgLifeCounter.History;
using AndroidDrawing = Common.Android.Drawing;

namespace UI.MtgLifeCounter.Android.Activities
{
	
	[Activity (Label = "MtgLifeCounter", MainLauncher = false, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait, Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]
	public class MainActivity : BaseActivityMenu
    {
      
        private FrameLayout _frameLayout;
        private AndroidGesture.ManagerGesture _managerGesture;
        private Screen _screen;
        private ImageView _imageOpponent;
        private ImageView _imagePlayer;
        private Game.Score _score;
        private HistoryAllGames _history;

        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            ManagerActivity.SetFullScreen(this);
            SetContentView (Resource.Layout.Activity_Main);

            _score = new Game.Score() { LifePoints_Player = 20, LifePoints_Opponent = 20, PoisonCounters_Player = 0, PoisonCounters_Opponent = 0 };
            _history = new HistoryAllGames();

            InitializeMenu();
            InitializeGesture();
            InitializeScreen();
            DrawScreen();

            ScreenReference = _screen;
            HistoryReference = _history;
        }

        #region INITIALIZATION

        private void InitializeMenu()
        {
            InitializeMenu(ResourcesMenu.ListMenuItems(this));
        }

        private void InitializeScreen()
        {
            _frameLayout = FindViewById<FrameLayout>(Resource.Id.frame_main);
            _screen = GameManagers.ManagerWidgets.CreateWidgets(this);
            _imageOpponent = AndroidDrawing.ManagerDrawing.DrawImageView(Resource.Drawable.wallpaper_opponent, this);
            _imagePlayer = AndroidDrawing.ManagerDrawing.DrawImageView(Resource.Drawable.wallpaper_player, this);
        }

        private void InitializeGesture()
        {
            _managerGesture = new AndroidGesture.ManagerGesture(this, GameGestureLeft, GameGestureRight, GameGestureUp, GameGestureDown, GameSingleTap);
        }

        #endregion

        #region DRAW SCREEN

        public void DrawScreen()
        {
            AndroidDrawing.ManagerDrawing.ShowImageView(_imageOpponent, ManagerResolution.PixelsWidth(this), ManagerResolution.PixelsHeight(this) / 2, 0, 0, _frameLayout);
            AndroidDrawing.ManagerDrawing.ShowImageView(_imagePlayer, ManagerResolution.PixelsWidth(this), ManagerResolution.PixelsHeight(this) / 2, 0, ManagerResolution.PixelsHeight(this) / 2, _frameLayout);
            ManagerDrawing.DrawScreen(_screen, _score, _frameLayout, this);
        }

        #endregion

        #region GESTURE LISTENER

        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            _managerGesture.GestureDetector.OnTouchEvent(ev);
            return base.DispatchTouchEvent(ev);
        }

        protected void GameGestureLeft()
        {
            if (GameManagers.ManagerGesture.GameGestureLeft(_screen, gestureListener.LastMove, _score, _history))
            {
                ManagerDrawing.RefreshScores(_screen, _score);
            }
        }

        protected void GameGestureRight()
        {
            if (GameManagers.ManagerGesture.GameGestureRight(_screen, gestureListener.LastMove, _score, _history))
            {
                ManagerDrawing.RefreshScores(_screen, _score);
            }
        }

        protected void GameGestureUp()
        {
            if (GameManagers.ManagerGesture.GameGestureUp(_screen, gestureListener.LastMove, _score, _history))
            {
                ManagerDrawing.RefreshScores(_screen, _score);
            }
        }

        protected void GameGestureDown()
        {
            if (GameManagers.ManagerGesture.GameGestureDown(_screen, gestureListener.LastMove, _score, _history))
            {
                ManagerDrawing.RefreshScores(_screen, _score);
            }
        }

        protected void GameSingleTap()
        {
            if (GameManagers.ManagerGesture.GameSingleTap(_screen, gestureListener.LastMove, _score, _history))
            {
                ManagerDrawing.RefreshScores(_screen, _score);
            }
        }

        #endregion

    }
}


