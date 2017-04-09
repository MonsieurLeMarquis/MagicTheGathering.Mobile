using Common.Android.Drawing;
using Business.MtgLifeCounter.Constants;
using Business.MtgLifeCounter.Configuration;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Common.Android.Activities;
using Android.Widget;
using System;
using Common.Android.Widgets;

namespace UI.MtgLifeCounter.Android.Activities
{
	
	[Activity (Label = "MtgLifeCounter", MainLauncher = true, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait, Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]
    public class IntroActivity : BaseActivity
	{

        private FontFitTextView textCalibrageMin;
        private FontFitTextView textCalibrageMax;

        protected override void OnCreate (Bundle savedInstanceState)
		{

			base.OnCreate (savedInstanceState);
            ManagerActivity.SetFullScreen(this);
            SetContentView (Resource.Layout.Activity_Intro);

            //CalibrageConfiguration();

            LaunchApplication();

            /*
            Button button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += delegate {
				ManagerActivity.Launch(this, typeof(MainActivity));
			};
            */
            
        }
        
        private void CalibrageConfiguration()
        {
            var frame = FindViewById<FrameLayout>(Resource.Id.frame_main);
            
            textCalibrageMin = ManagerDrawing.DrawFontFitTextView(Const.CALIBRAGE_TEXT_ZONE_SIZE, Const.CALIBRAGE_TEXT_ZONE_SIZE, this);
            ManagerDrawing.SetText(textCalibrageMin, Const.CALIBRAGE_TEXT(Const.CALIBRAGE_TEXT_LENGTH_MIN));
            ManagerDrawing.SetTheme(textCalibrageMin, Drawings.Themes.Score);
            ManagerDrawing.ShowTextView(textCalibrageMin, Const.CALIBRAGE_TEXT_ZONE_SIZE, Const.CALIBRAGE_TEXT_ZONE_SIZE, Const.CALIBRAGE_TEXT_ZONE_SIZE * -1, Const.CALIBRAGE_TEXT_ZONE_SIZE * -1, frame);
            //ManagerDrawing.ShowTextView(textCalibrageMin, Const.CALIBRAGE_TEXT_ZONE_SIZE, Const.CALIBRAGE_TEXT_ZONE_SIZE, 0, 0, frame);

            textCalibrageMax = ManagerDrawing.DrawFontFitTextView(Const.CALIBRAGE_TEXT_ZONE_SIZE, Const.CALIBRAGE_TEXT_ZONE_SIZE, this);
            ManagerDrawing.SetText(textCalibrageMax, Const.CALIBRAGE_TEXT(Const.CALIBRAGE_TEXT_LENGTH_MAX));
            ManagerDrawing.SetTheme(textCalibrageMax, Drawings.Themes.Score);
            ManagerDrawing.ShowTextView(textCalibrageMax, Const.CALIBRAGE_TEXT_ZONE_SIZE, Const.CALIBRAGE_TEXT_ZONE_SIZE, Const.CALIBRAGE_TEXT_ZONE_SIZE * -1, Const.CALIBRAGE_TEXT_ZONE_SIZE * -1, frame);
            //ManagerDrawing.ShowTextView(textCalibrageMax, Const.CALIBRAGE_TEXT_ZONE_SIZE, Const.CALIBRAGE_TEXT_ZONE_SIZE, 0, 0, frame);

            Handler handler = new Handler();
            Action myAction = () =>
            {
                Config.CalibrageTextSizeMin = (int)textCalibrageMin.TextSize;
                Config.CalibrageTextSizeMax = (int)textCalibrageMax.TextSize;
            };
            handler.PostDelayed(myAction, 1000);
        }
                
        private void LaunchApplication()
        {
            Handler handler = new Handler();
            Action myAction = () =>
            {
                ManagerActivity.Launch(this, typeof(MainActivity));
            };
            handler.PostDelayed(myAction, 3000);
        }

    }
}


