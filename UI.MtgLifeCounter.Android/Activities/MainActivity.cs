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
using static Business.MtgLifeCounter.Enumerations.Enum;
using System;
using Android.Views.Animations;
using Business.MtgLifeCounter.Gesture;

namespace UI.MtgLifeCounter.Android.Activities
{
	
	[Activity (Label = "MtgLifeCounter", MainLauncher = false, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait, Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]
	public class MainActivity : BaseActivityMenu
    {
 
        // Widgets     
        private FrameLayout _frameLayout;
        private ImageView _imageOpponent;
        private ImageView _imagePlayer;
        private Animation _animationScoreTopYou;
        private Animation _animationScoreTopOpponent;
        private Animation _animationScoreBottomYou;
        private Animation _animationScoreBottomOpponent;
        // Listener
        private AndroidGesture.ManagerGesture _managerGesture;
        // Business
        private Screen _screen;
        private Game.Score _score;
        private HistoryAllGames _history;
        // Setup
        private bool _enableGesture = true;
        private bool _enableAnimation = true;

        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            ManagerActivity.SetFullScreen(this);
            SetContentView (Resource.Layout.Activity_Main);

            _score = new Game.Score() { LifePoints_Player = 20, LifePoints_Opponent = 20, PoisonCounters_Player = 0, PoisonCounters_Opponent = 0 };
            _history = new HistoryAllGames();

            InitializeMenu();
            InitializeGesture();
            InitializeAnimation();
            InitializeScreen();
            DrawScreen();
            
            ScreenReference = _screen;
            HistoryReference = _history;
        }

        protected override void OnResume()
        {
            base.OnResume();
            ManagerDrawing.RefreshScores(_screen, _score);
        }

        #region INITIALIZATION

        private void InitializeMenu()
        {
            InitializeMenu(ResourcesMenu.ListMenuItems(this));
        }

        private void InitializeAnimation()
        {
            _animationScoreTopYou = AnimationUtils.LoadAnimation(this, Resource.Animation.change_score_inverse_life);
            _animationScoreTopOpponent = AnimationUtils.LoadAnimation(this, Resource.Animation.change_score_inverse_life);
            _animationScoreBottomYou = AnimationUtils.LoadAnimation(this, Resource.Animation.change_score_life);
            _animationScoreBottomOpponent = AnimationUtils.LoadAnimation(this, Resource.Animation.change_score_life);
        }

        private void InitializeScreen()
        {
            _frameLayout = FindViewById<FrameLayout>(Resource.Id.frame_main);
            _screen = GameManagers.ManagerWidgets.CreateWidgets(this);
            _imageOpponent = AndroidDrawing.ManagerDrawing.DrawImageView(Resource.Drawable.wallpaper_opponent, this);
            _imagePlayer = AndroidDrawing.ManagerDrawing.DrawImageView(Resource.Drawable.wallpaper_player, this);
            _frameLayout.ViewTreeObserver.GlobalLayout += InitializeTexts;
        }

        private void InitializeTexts (object sender, EventArgs arg)
        {
            ManagerDrawing.RefreshAll(_screen, _score);
            _frameLayout.ViewTreeObserver.GlobalLayout -= InitializeTexts;
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
            if (_enableGesture)
            {
                var reportGesture = GameManagers.ManagerGesture.GameGestureSwipe(_screen, gestureListener.LastMove, _score, _history, TypeGesture.SWIPE_LEFT);
                RefreshScore(reportGesture);
            }
        }

        protected void GameGestureRight()
        {
            if (_enableGesture)
            {
                var reportGesture = GameManagers.ManagerGesture.GameGestureSwipe(_screen, gestureListener.LastMove, _score, _history, TypeGesture.SWIPE_RIGHT);
                RefreshScore(reportGesture);
            }
        }

        protected void GameGestureUp()
        {
            if (_enableGesture)
            {
                var reportGesture = GameManagers.ManagerGesture.GameGestureSwipe(_screen, gestureListener.LastMove, _score, _history, TypeGesture.SWIPE_UP);
                RefreshScore(reportGesture);
            }
        }

        protected void GameGestureDown()
        {
            if (_enableGesture)
            {
                var reportGesture = GameManagers.ManagerGesture.GameGestureSwipe(_screen, gestureListener.LastMove, _score, _history, TypeGesture.SWIPE_DOWN);
                RefreshScore(reportGesture);
            }
        }

        protected void GameSingleTap()
        {
            if (_enableGesture)
            {
                var reportGesture = GameManagers.ManagerGesture.GameGestureSingleTap(_screen, gestureListener.LastMove, _score, _history);
                RefreshScore(reportGesture);
            }
        }

        #endregion

        #region REFRESH

        protected void RefreshScore(GestureReport gestureReport)
        {
            if (gestureReport.TypeScore != TypeScore.NONE)
            {
                ManagerDrawing.RefreshScores(_screen, _score);
                if (gestureReport.TypeScore == TypeScore.ZONE_OPPONENT_SCORE_OPPONENT || gestureReport.TypeScore == TypeScore.ZONE_PLAYER_SCORE_OPPONENT)
                {
                    AnimationPointsOpponent();
                }
                if (gestureReport.TypeScore == TypeScore.ZONE_OPPONENT_SCORE_PLAYER || gestureReport.TypeScore == TypeScore.ZONE_PLAYER_SCORE_PLAYER)
                {
                    AnimationPointsYou();
                }
            }
        }

        #endregion

        #region ANIMATIONS

        private void AnimationPointsYou()
        {
            if (_enableAnimation)
            {
                AnimationPoints(_animationScoreTopYou, _animationScoreBottomYou, _screen.ZoneOpponent.ScorePlayer.Widget, _screen.ZonePlayer.ScorePlayer.Widget);
            }
        }

        private void AnimationPointsOpponent()
        {
            if (_enableAnimation)
            {
                AnimationPoints(_animationScoreTopOpponent, _animationScoreBottomOpponent, _screen.ZoneOpponent.ScoreOpponent.Widget, _screen.ZonePlayer.ScoreOpponent.Widget);
            }
        }

        private void AnimationPoints(Animation animationTop, Animation animationBottom, TextView scoreTop, TextView scoreBottom)
        {
            animationTop.Reset();
            animationBottom.Reset();
            scoreTop.ClearAnimation();
            scoreBottom.ClearAnimation();
            scoreTop.StartAnimation(animationTop);
            scoreBottom.StartAnimation(animationBottom);
        }

        #endregion

    }
}


