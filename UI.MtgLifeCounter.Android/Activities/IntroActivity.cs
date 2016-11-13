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
            //ManagerActivity.SetFullScreen(this);
            SetContentView (Resource.Layout.Activity_Intro);
            ActionBar.SetIcon(Resource.Color.transparent);

            Button button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += delegate {
				ManagerActivity.Launch(this, typeof(MainActivity));
			};

            Button btnFullscreen = FindViewById<Button>(Resource.Id.btnFullscreen);
            Button btnHideNavigation = FindViewById<Button>(Resource.Id.btnHideNavigation);
            Button btnImmersive = FindViewById<Button>(Resource.Id.btnImmersive);
            Button btnImmersiveSticky = FindViewById<Button>(Resource.Id.btnImmersiveSticky);
            Button btnLayoutFlags = FindViewById<Button>(Resource.Id.btnLayoutFlags);
            Button btnLayoutFullscreen = FindViewById<Button>(Resource.Id.btnLayoutFullscreen);
            Button btnLayoutHideNavigation = FindViewById<Button>(Resource.Id.btnLayoutHideNavigation);
            Button btnLayoutStable = FindViewById<Button>(Resource.Id.btnLayoutStable);
            Button btnLowProfile = FindViewById<Button>(Resource.Id.btnLowProfile);
            Button btnVisible = FindViewById<Button>(Resource.Id.btnVisible);

            btnFullscreen.Click += BtnFullscreen_Click;
            btnHideNavigation.Click += BtnHideNavigation_Click;
            btnImmersive.Click += BtnImmersive_Click;
            btnImmersiveSticky.Click += BtnImmersiveSticky_Click;
            btnLayoutFlags.Click += BtnLayoutFlags_Click;
            btnLayoutFullscreen.Click += BtnLayoutFullscreen_Click;
            btnLayoutHideNavigation.Click += BtnLayoutHideNavigation_Click;
            btnLayoutStable.Click += BtnLayoutStable_Click;
            btnLowProfile.Click += BtnLowProfile_Click;
            btnVisible.Click += BtnVisible_Click;

        }

        private void BtnFullscreen_Click(object sender, EventArgs e)
        {
            Test((int)SystemUiFlags.Fullscreen);
        }

        private void BtnHideNavigation_Click(object sender, EventArgs e)
        {
            Test((int)SystemUiFlags.HideNavigation);
        }

        private void BtnImmersive_Click(object sender, EventArgs e)
        {
            Test((int)SystemUiFlags.Immersive);
        }

        private void BtnImmersiveSticky_Click(object sender, EventArgs e)
        {
            Test((int)SystemUiFlags.ImmersiveSticky);
        }

        private void BtnLayoutFlags_Click(object sender, EventArgs e)
        {
            Test((int)SystemUiFlags.LayoutFlags);
        }

        private void BtnLayoutFullscreen_Click(object sender, EventArgs e)
        {
            Test((int)SystemUiFlags.LayoutFullscreen);
        }

        private void BtnLayoutHideNavigation_Click(object sender, EventArgs e)
        {
            Test((int)SystemUiFlags.LayoutHideNavigation);
        }

        private void BtnLayoutStable_Click(object sender, EventArgs e)
        {
            Test((int)SystemUiFlags.LayoutStable);
        }

        private void BtnLowProfile_Click(object sender, EventArgs e)
        {
            Test((int)SystemUiFlags.LowProfile);
        }

        private void BtnVisible_Click(object sender, EventArgs e)
        {
            Test((int)SystemUiFlags.Visible);
        }


        private void Test (int flag)
        {
            var uiOptions = (int)Window.DecorView.SystemUiVisibility;
            /*
            var newUiOptions = (int)uiOptions;
            newUiOptions |= flag;
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)newUiOptions;
            */
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)flag;
            Toast.MakeText(this, flag.ToString(), ToastLength.Short).Show();
        }

    }
}


