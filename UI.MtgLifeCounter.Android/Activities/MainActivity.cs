using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using UI.MtgLifeCounter.Android.Components.Menu;
using Common.Android.Activities;
using Android.Content.PM;
using Business.MtgLifeCounter.Widgets;
using Business.MtgLifeCounter.Managers;
using UI.MtgLifeCounter.Android.Drawings;
using Common.Android.Resolution;
using Common.Android.Gesture;
using Game = Business.MtgLifeCounter.Game;
using Business.MtgLifeCounter.History;

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
        private Game.Score _score;
        private HistoryAllGames _history;

        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            ManagerActivity.SetFullScreen(this);
            SetContentView (Resource.Layout.Activity_Main);

            _score = new Game.Score() { Player = 20, Opponent = 20 };
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
            _screen = ManagerWidgets.CreateWidgets(this);
            _imageOpponent = Common.Android.Drawing.ManagerDrawing.DrawImageView(Resource.Drawable.wallpaper_opponent, this);
            _imagePlayer = Common.Android.Drawing.ManagerDrawing.DrawImageView(Resource.Drawable.wallpaper_player, this);
        }

        private void InitializeGesture()
        {
            _managerGesture = new ManagerGesture(this, GameGestureLeft, GameGestureRight, GameGestureUp, GameGestureDown, GameSingleTap);
        }

        #endregion

        #region DRAW SCREEN

        public void DrawScreen()
        {
            Common.Android.Drawing.ManagerDrawing.ShowImageView(_imageOpponent, ManagerResolution.PixelsWidth(this), ManagerResolution.PixelsHeight(this) / 2, 0, 0, _frameLayout);
            Common.Android.Drawing.ManagerDrawing.ShowImageView(_imagePlayer, ManagerResolution.PixelsWidth(this), ManagerResolution.PixelsHeight(this) / 2, 0, ManagerResolution.PixelsHeight(this) / 2, _frameLayout);
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
            var typeScore = ManagerScreenScore.GetTypeScore(_screen, gestureListener.LastMove);
            if (typeScore == ManagerScreenScore.TypeScore.NONE)
            {
                return;
            }
            switch (typeScore)
            {
                case ManagerScreenScore.TypeScore.ZONE_OPPONENT_SCORE_OPPONENT:
                    ManagerScore.ScoreDouble(_score, ManagerScore.TypePlayer.OPPONENT, _history);
                    break;
                case ManagerScreenScore.TypeScore.ZONE_OPPONENT_SCORE_PLAYER:
                    ManagerScore.ScoreDouble(_score, ManagerScore.TypePlayer.PLAYER, _history);
                    break;
                case ManagerScreenScore.TypeScore.ZONE_PLAYER_SCORE_PLAYER:
                    ManagerScore.ScoreHalf(_score, ManagerScore.TypePlayer.PLAYER, _history);
                    break;
                case ManagerScreenScore.TypeScore.ZONE_PLAYER_SCORE_OPPONENT:
                    ManagerScore.ScoreHalf(_score, ManagerScore.TypePlayer.OPPONENT, _history);
                    break;
            }
            ManagerDrawing.RefreshScores(_screen, _score);
        }

        protected void GameGestureRight()
        {
            var typeScore = ManagerScreenScore.GetTypeScore(_screen, gestureListener.LastMove);
            if (typeScore == ManagerScreenScore.TypeScore.NONE)
            {
                return;
            }
            switch (typeScore)
            {
                case ManagerScreenScore.TypeScore.ZONE_OPPONENT_SCORE_OPPONENT:
                    ManagerScore.ScoreHalf(_score, ManagerScore.TypePlayer.OPPONENT, _history);
                    break;
                case ManagerScreenScore.TypeScore.ZONE_OPPONENT_SCORE_PLAYER:
                    ManagerScore.ScoreHalf(_score, ManagerScore.TypePlayer.PLAYER, _history);
                    break;
                case ManagerScreenScore.TypeScore.ZONE_PLAYER_SCORE_PLAYER:
                    ManagerScore.ScoreDouble(_score, ManagerScore.TypePlayer.PLAYER, _history);
                    break;
                case ManagerScreenScore.TypeScore.ZONE_PLAYER_SCORE_OPPONENT:
                    ManagerScore.ScoreDouble(_score, ManagerScore.TypePlayer.OPPONENT, _history);
                    break;
            }
            ManagerDrawing.RefreshScores(_screen, _score);
        }

        protected void GameGestureUp()
        {
            var typeScore = ManagerScreenScore.GetTypeScore(_screen, gestureListener.LastMove);
            if (typeScore == ManagerScreenScore.TypeScore.NONE)
            {
                return;
            }
            switch (typeScore)
            {
                case ManagerScreenScore.TypeScore.ZONE_OPPONENT_SCORE_OPPONENT:
                    ManagerScore.ScoreDown(_score, ManagerScore.TypePlayer.OPPONENT, _history, 5);
                    break;
                case ManagerScreenScore.TypeScore.ZONE_OPPONENT_SCORE_PLAYER:
                    ManagerScore.ScoreDown(_score, ManagerScore.TypePlayer.PLAYER, _history, 5);
                    break;
                case ManagerScreenScore.TypeScore.ZONE_PLAYER_SCORE_PLAYER:
                    ManagerScore.ScoreUp(_score, ManagerScore.TypePlayer.PLAYER, _history, 5);
                    break;
                case ManagerScreenScore.TypeScore.ZONE_PLAYER_SCORE_OPPONENT:
                    ManagerScore.ScoreUp(_score, ManagerScore.TypePlayer.OPPONENT, _history, 5);
                    break;
            }
            ManagerDrawing.RefreshScores(_screen, _score);
        }

        protected void GameGestureDown()
        {
            var typeScore = ManagerScreenScore.GetTypeScore(_screen, gestureListener.LastMove);
            if (typeScore == ManagerScreenScore.TypeScore.NONE)
            {
                return;
            }
            switch (typeScore)
            {
                case ManagerScreenScore.TypeScore.ZONE_OPPONENT_SCORE_OPPONENT:
                    ManagerScore.ScoreUp(_score, ManagerScore.TypePlayer.OPPONENT, _history, 5);
                    break;
                case ManagerScreenScore.TypeScore.ZONE_OPPONENT_SCORE_PLAYER:
                    ManagerScore.ScoreUp(_score, ManagerScore.TypePlayer.PLAYER, _history, 5);
                    break;
                case ManagerScreenScore.TypeScore.ZONE_PLAYER_SCORE_PLAYER:
                    ManagerScore.ScoreDown(_score, ManagerScore.TypePlayer.PLAYER, _history, 5);
                    break;
                case ManagerScreenScore.TypeScore.ZONE_PLAYER_SCORE_OPPONENT:
                    ManagerScore.ScoreDown(_score, ManagerScore.TypePlayer.OPPONENT, _history, 5);
                    break;
            }
            ManagerDrawing.RefreshScores(_screen, _score);
        }

        protected void GameSingleTap()
        {
            var typeScore = ManagerScreenScore.GetTypeScore(_screen, gestureListener.LastMove);
            if (typeScore == ManagerScreenScore.TypeScore.NONE)
            {
                return;
            }
            switch (typeScore)
            {
                case ManagerScreenScore.TypeScore.ZONE_OPPONENT_SCORE_OPPONENT:
                    if (ManagerScreenScore.GestureInScoreTop(_screen, gestureListener.LastMove))
                    {
                        ManagerScore.ScoreDown(_score, ManagerScore.TypePlayer.OPPONENT, _history);
                    }
                    else if (ManagerScreenScore.GestureInScoreBottom(_screen, gestureListener.LastMove))
                    {
                        ManagerScore.ScoreUp(_score, ManagerScore.TypePlayer.OPPONENT, _history);
                    }
                    break;
                case ManagerScreenScore.TypeScore.ZONE_OPPONENT_SCORE_PLAYER:
                    if (ManagerScreenScore.GestureInScoreTop(_screen, gestureListener.LastMove))
                    {
                        ManagerScore.ScoreDown(_score, ManagerScore.TypePlayer.PLAYER, _history);
                    }
                    else if (ManagerScreenScore.GestureInScoreBottom(_screen, gestureListener.LastMove))
                    {
                        ManagerScore.ScoreUp(_score, ManagerScore.TypePlayer.PLAYER, _history);
                    }
                    break;
                case ManagerScreenScore.TypeScore.ZONE_PLAYER_SCORE_PLAYER:
                    if (ManagerScreenScore.GestureInScoreTop(_screen, gestureListener.LastMove))
                    {
                        ManagerScore.ScoreUp(_score, ManagerScore.TypePlayer.PLAYER, _history);
                    }
                    else if (ManagerScreenScore.GestureInScoreBottom(_screen, gestureListener.LastMove))
                    {
                        ManagerScore.ScoreDown(_score, ManagerScore.TypePlayer.PLAYER, _history);
                    }
                    break;
                case ManagerScreenScore.TypeScore.ZONE_PLAYER_SCORE_OPPONENT:
                    if (ManagerScreenScore.GestureInScoreTop(_screen, gestureListener.LastMove))
                    {
                        ManagerScore.ScoreUp(_score, ManagerScore.TypePlayer.OPPONENT, _history);
                    }
                    else if (ManagerScreenScore.GestureInScoreBottom(_screen, gestureListener.LastMove))
                    {
                        ManagerScore.ScoreDown(_score, ManagerScore.TypePlayer.OPPONENT, _history);
                    }
                    break;
            }
            ManagerDrawing.RefreshScores(_screen, _score);
        }

        #endregion

    }
}


