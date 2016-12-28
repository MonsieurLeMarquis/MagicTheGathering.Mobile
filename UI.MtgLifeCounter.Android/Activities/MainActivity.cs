using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using UI.MtgLifeCounter.Android;
using UI.MtgLifeCounter.Android.Components.Menu;
using System;
using Android.Graphics;
using Android.Views.Animations;
using System.Collections.Generic;
using UI.MtgLifeCounter.Android.Fragments;
using Common.Android.Activities;
using Android.Content.PM;
using Business.MtgLifeCounter.Objects;
using Business.MtgLifeCounter.Managers;
using UI.MtgLifeCounter.Android.Drawings;

namespace UI.MtgLifeCounter.Android.Activities
{
	
	[Activity (Label = "MtgLifeCounter", MainLauncher = false, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : BaseActivityMenu, GestureDetector.IOnGestureListener
    {

        private GestureDetector _gestureDetector;

        private FrameLayout _frameLayout;

        private Screen _screen;


        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            ManagerActivity.SetFullScreen(this);
            SetContentView (Resource.Layout.Activity_Main);
			InitializeMenu (ResourcesMenu.ListMenuItems(this));
            _gestureDetector = new GestureDetector(this);


            _frameLayout = FindViewById<FrameLayout>(Resource.Id.frame_container);

            var textView = Common.Android.Drawing.ManagerDrawing.DrawTextView(this);
            textView = Common.Android.Drawing.ManagerDrawing.SetText(textView, "TEST", 20, new Color(255, 255, 255));
            Common.Android.Drawing.ManagerDrawing.ShowTextView(textView, 200, 200, 200, 200, _frameLayout);

            _screen = ManagerWidgets.CreateWidgets(this);
            ManagerDrawing.DrawScreen(_screen);

        }

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

    }
}


