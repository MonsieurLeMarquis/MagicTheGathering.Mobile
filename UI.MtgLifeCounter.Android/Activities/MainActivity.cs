using Android.App;
using Android.OS;
using UI.MtgLifeCounter.Android.Components.Menu;
using Common.Android.Activities;
using Android.Content.PM;
using Common.Android.Fragments;
using UI.MtgLifeCounter.Android.Fragments;

namespace UI.MtgLifeCounter.Android.Activities
{

    [Activity (Label = "MtgLifeCounter", MainLauncher = false, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait, Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen")]
	public class MainActivity : GestureActivity
    {

        protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
            ManagerActivity.SetFullScreen(this);
            SetContentView (Resource.Layout.Activity_Main);
            InitializeMenu(ResourcesMenu.ListMenuItems(this));

            var action = new MenuItemAction
            {
                TypeAction = MenuItemAction.TYPE_ACTION.LOAD_FRAGMENT,
                Screen = typeof(MainFragment)
            };
            ManagerFragment.Launch(base.FragmentManager, (Fragment)action.GetScreenInstance(), Resource.Id.frame_container);
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

    }
}


