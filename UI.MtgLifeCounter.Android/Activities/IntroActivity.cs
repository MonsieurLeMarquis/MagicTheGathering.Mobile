using Android.App;
using Android.Widget;
using Android.OS;
using Common.Android.Activities;
using Android.Content.PM;
using System;
using Android.Views;

namespace UI.MtgLifeCounter.Android.Activities
{
	
	[Activity (Label = "MtgLifeCounter", MainLauncher = true, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class IntroActivity : BaseActivity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            ManagerActivity.SetFullScreen(this);
            SetContentView (Resource.Layout.Activity_Intro);

            Button button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += delegate {
				ManagerActivity.Launch(this, typeof(MainActivity));
			};
        }
        
    }
}


