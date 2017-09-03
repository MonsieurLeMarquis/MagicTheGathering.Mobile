using Android.Widget;
using Android.OS;
using Android.Views;
using GameManagers = Business.MtgLifeCounter.Managers;
using UI.MtgLifeCounter.Android.Drawings;
using Game = Business.MtgLifeCounter.Game;
using Business.MtgLifeCounter.History;
using static Business.MtgLifeCounter.Enumerations.Enum;
using System;
using Android.Views.Animations;
using Business.MtgLifeCounter.Gesture;
using Common.Android.Gesture;
using UI.MtgLifeCounter.Android.Activities;
using Business.MtgLifeCounter.Context;
using Common.Android.Resolution;
using AndroidDrawing = Common.Android.Drawing;

namespace UI.MtgLifeCounter.Android.Fragments
{
    public class MainFragment : BaseFragment
    {

        // Listener
        private bool _enableAnimation = true;

        // Widgets     
        private FrameLayout _frameLayout;
        private ImageView _imageOpponent;
        private ImageView _imagePlayer;
        private Animation _animationScoreTopYou;
        private Animation _animationScoreTopOpponent;
        private Animation _animationScoreBottomYou;
        private Animation _animationScoreBottomOpponent;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) 
		{
			MyView = inflater.Inflate(Resource.Layout.Fragment_Main, container, false);
			MyActivity = Activity;

            MtgLifeCounterContext.Score = new Game.Score() { LifePoints_Player = 20, LifePoints_Opponent = 20, PoisonCounters_Player = 0, PoisonCounters_Opponent = 0 };
            MtgLifeCounterContext.History = new HistoryAllGames();
            
            InitializeAnimation();
            InitializeScreen();
            DrawScreen();

            RegisterFragment();

            return MyView;
        }

        #region INITIALIZATION

        private void RegisterFragment()
        {
            ((MainActivity)MyActivity).MainFragment = this;
        }

        private void InitializeAnimation()
        {
            _animationScoreTopYou = AnimationUtils.LoadAnimation(MyActivity, Resource.Animation.change_score_inverse_life);
            _animationScoreTopOpponent = AnimationUtils.LoadAnimation(MyActivity, Resource.Animation.change_score_inverse_life);
            _animationScoreBottomYou = AnimationUtils.LoadAnimation(MyActivity, Resource.Animation.change_score_life);
            _animationScoreBottomOpponent = AnimationUtils.LoadAnimation(MyActivity, Resource.Animation.change_score_life);
        }

        private void InitializeScreen()
        {
            _frameLayout = MyActivity.FindViewById<FrameLayout>(Resource.Id.frame_main);
            MtgLifeCounterContext.Screen = GameManagers.ManagerWidgets.CreateWidgets(MyActivity);
            /*
            _imageOpponent = AndroidDrawing.ManagerDrawing.DrawImageView(Resource.Drawable.wallpaper_opponent, MyActivity);
            _imagePlayer = AndroidDrawing.ManagerDrawing.DrawImageView(Resource.Drawable.wallpaper_player, MyActivity);
            */
            _frameLayout.ViewTreeObserver.GlobalLayout += InitializeTexts;
        }

        private void InitializeTexts(object sender, EventArgs arg)
        {
            ManagerDrawing.RefreshAll(MtgLifeCounterContext.Screen, MtgLifeCounterContext.Score);
            _frameLayout.ViewTreeObserver.GlobalLayout -= InitializeTexts;
        }

        #endregion

        #region DRAW SCREEN

        public void DrawScreen()
        {
            /*
            AndroidDrawing.ManagerDrawing.ShowImageView(_imageOpponent, ManagerResolution.PixelsWidth(MyActivity), ManagerResolution.PixelsHeight(MyActivity) / 2, 0, 0, _frameLayout);
            AndroidDrawing.ManagerDrawing.ShowImageView(_imagePlayer, ManagerResolution.PixelsWidth(MyActivity), ManagerResolution.PixelsHeight(MyActivity) / 2, 0, ManagerResolution.PixelsHeight(MyActivity) / 2, _frameLayout);
            */        
            ManagerDrawing.DrawScreen(MtgLifeCounterContext.Screen, MtgLifeCounterContext.Score, _frameLayout, MyActivity);
        }

        #endregion

        #region GESTURE LISTENER

        public GestureReport ApplyGesture(Move move)
        {
            return GameManagers.ManagerGesture.GameGesture(MtgLifeCounterContext.Screen, move, MtgLifeCounterContext.Score, MtgLifeCounterContext.History);
        }

        #endregion

        #region REFRESH

        public void RefreshScore(GestureReport gestureReport)
        {
            ManagerDrawing.RefreshScores(MtgLifeCounterContext.Screen, MtgLifeCounterContext.Score);
            if (gestureReport.TypeScore != TypeScore.NONE)
            {
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
                AnimationPoints(_animationScoreTopYou, _animationScoreBottomYou, MtgLifeCounterContext.Screen.ZoneOpponent.ScorePlayer.Widget, MtgLifeCounterContext.Screen.ZonePlayer.ScorePlayer.Widget);
            }
        }

        private void AnimationPointsOpponent()
        {
            if (_enableAnimation)
            {
                AnimationPoints(_animationScoreTopOpponent, _animationScoreBottomOpponent, MtgLifeCounterContext.Screen.ZoneOpponent.ScoreOpponent.Widget, MtgLifeCounterContext.Screen.ZonePlayer.ScoreOpponent.Widget);
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

